using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleUserInforsData : HandleUserData<UserInfors>
{


    private int userTicket;

    public int UserTicket { get { return userTicket; } }

    public override void HandleDataEvent(UserInfors data)
    {
        

        this.userTicket = data.GachaTickets;
    }


    public void IncreaseUserTickets(int ticket) { 
        this.userTicket += ticket;  
    }

    public void DescreaseUserTickets(int ticket)
    {
        this.userTicket -= ticket;

        if (this.userTicket < 0) {
            this.userTicket = 0;
        }
    }
}
