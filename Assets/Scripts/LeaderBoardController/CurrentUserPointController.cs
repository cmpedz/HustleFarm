using UnityEngine;
using UnityEngine.UI;

public class CurrentUserPointController : Singleton<CurrentUserPointController>
 {
    [SerializeField] private Color currentUserColor;

    [SerializeField] private float currentUserPoint = 0;

    [SerializeField] private PlayerPointChangeScriptableObject playerPointChangeScriptable;

    public void IncreaseCurrentUserPoint(string userId, float pointBonus, float pointBonusRate)
    {
        Debug.Log("point bonus get : " + pointBonus + currentUserPoint * pointBonusRate);

        currentUserPoint += pointBonus + currentUserPoint * pointBonusRate;

        playerPointChangeScriptable.OnPlayerPointChanges(userId, currentUserPoint.ToString());
    }


    public void SetUpDataForCurrentUserPointExhibition(PlayerRank playerRank, PlayerRankData playerRankData)
    {
        if (playerRankData.Id == InstanceUserGeneralInfors.Instance.UserId)
        {
            Debug.Log("set color for current user !");
            playerRank.GetComponent<Image>().color = currentUserColor;

            this.currentUserPoint = float.Parse(playerRankData.Point);
        }
    }


}

