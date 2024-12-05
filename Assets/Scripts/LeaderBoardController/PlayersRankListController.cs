using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayersRankListController : MonoBehaviour
{
    [SerializeField] private GameObject Content;

    [SerializeField] private PlayerRank form;

    [SerializeField] private List<PlayerRank> playersRankList = new List<PlayerRank>();

    [SerializeField] private Color currentUserColor;

    public void AddPlayerRankIntoLeaderBoard(PlayerRankData playerData, int index)
    {
        bool isPlayerRankInSpecifiedIndexNull = playersRankList.Count > index && playersRankList[index] == null;

        bool isPlayerRankIndexOutRange = playersRankList.Count <= index;

        if (isPlayerRankInSpecifiedIndexNull || isPlayerRankIndexOutRange) 
        {
            PlayerRank newPlayer = Instantiate(form);

            newPlayer.transform.parent = Content.transform;

            newPlayer.gameObject.SetActive(true);

            SetSpecialColorForCurrentUser(newPlayer, playerData);

            if (isPlayerRankIndexOutRange) { 
                playersRankList.Add(newPlayer);
            }
            else
            {
                playersRankList[index] = newPlayer;
            }

            

            
        }

        playersRankList[index].SetPlayerRank(playerData.Id, playerData.Point);

    }

    private void SetSpecialColorForCurrentUser(PlayerRank playerRank, PlayerRankData playerRankData)
    {
        if (playerRankData.Id == InstanceUserGeneralInfors.Instance.UserId) {
            Debug.Log("set color for current user !");
            playerRank.GetComponent<Image>().color = currentUserColor;
        }
    }
    
}
