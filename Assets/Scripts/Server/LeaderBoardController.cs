using Mono.Cecil.Cil;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class LeaderBoardController : ServerRequestController, IOnPlayerPointChange
{

    [SerializeField] private PlayersRankListController playersRankList;

    private static readonly string LEADER_BOARD_ROUTE = "LeaderBoardServer";

    private static LeaderBoardController instance;
    public static LeaderBoardController Instance { get { return instance; } }

    [SerializeField] private PlayerPointChangeScriptableObject playerPointChangeScriptableObject;


    private void SubcribesToSubject()
    {
        playerPointChangeScriptableObject.AddListener(this);
    }

    private void UnSubcribesToSubject()
    {
        playerPointChangeScriptableObject.RemoveListener(this);
    }

    private void OnDisable()
    {
        UnSubcribesToSubject();
    }

    private void OnDestroy()
    {
        UnSubcribesToSubject();
    }

    private void Start()
    {

        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            GetPlayersRankList();

            

            SubcribesToSubject();

        }
        else
        {
            if (instance != this) {
                Destroy(gameObject);
            }
            
        }
       
    }

    private void OnEnable()
    {
        GetPlayersRankList();

        SubcribesToSubject();
    }

    public void GetPlayersRankList()
    {
        StartCoroutine(SendGetRequest(LEADER_BOARD_ROUTE));
    }
    protected override void HandleDataRetrievedFromServer(UnityWebRequest request)
    {
        JArray playersRank = JArray.Parse(request.downloadHandler.text);

        int playerRankIndex = 0;

        foreach(var playerRank in playersRank)
        {
            PlayerRankData playerRankData = JsonUtility.FromJson<PlayerRankData>(playerRank.ToString());

            playersRankList.AddPlayerRankIntoLeaderBoard(playerRankData, playerRankIndex);

            playerRankIndex++;

        }

    }

    public void OnPlayerPointChange(string userId, string pointAdd)
    {
        PlayerRankData userPointData = new PlayerRankData() { 
            Id = userId,
            Point = pointAdd
        };

        string userPointDataToJson = JsonUtility.ToJson(userPointData);

        StartCoroutine(SendPostRequest(LEADER_BOARD_ROUTE, userPointDataToJson));
    }
}
