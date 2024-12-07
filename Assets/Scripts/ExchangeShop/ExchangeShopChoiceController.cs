using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ExchangeShopChoiceController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private TextMeshProUGUI gachaTickets;

    [SerializeField] private int gachaTicketsReceived;

    [SerializeField] private Image itemExchangeSprite;

    [SerializeField] private Item itemExchange;

    [SerializeField] private BagMenu userBag;

    private GameNotificationController gameNotificationController;

    private HandleUserInforsData userTickets;


    void Start()
    {
        gachaTickets.text = gachaTicketsReceived.ToString();

        itemExchangeSprite.sprite = itemExchange.GetItemSprite();

        gameNotificationController = FindAnyObjectByType<GameNotificationController>();

        userTickets = FindAnyObjectByType<HandleUserInforsData>();
    }

    public void ExchangeItem()
    {
        if (userBag.HasItem(itemExchange.GetItemId())) {

            userBag.RemoveItem(itemExchange, true);

            userTickets.IncreaseUserTickets(gachaTicketsReceived);
        }
        else
        {
            gameNotificationController.NotifyMessage("Lack of required items ! ", true);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
