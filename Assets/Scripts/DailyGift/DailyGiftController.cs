using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DailyGiftController : MonoBehaviour
{
    // Start is called before the first frame update

    private const int MAX_GACHA_TICKETS_HAS = 10;

    [SerializeField] private HandleUserInforsData usersTicket;


    public void ReceiveDailyGift()
    {
        usersTicket.IncreaseUserTickets(MAX_GACHA_TICKETS_HAS);


    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
