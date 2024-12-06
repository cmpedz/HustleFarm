using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerRank : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private TextMeshProUGUI playerId;

    [SerializeField] private TextMeshProUGUI playerPoint;

    public void SetPlayerRank(string playerId, string playerPoint)
    {
        this.playerId.text = playerId;

        float playerPointToFloat = float.Parse(playerPoint);

        string playerPointAfterFixLength = Math.Round(playerPointToFloat, 2).ToString();

        this.playerPoint.text = playerPointAfterFixLength;    
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
