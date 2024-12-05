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
        this.playerPoint.text = playerPoint;    
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
