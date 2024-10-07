using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemReceiveNotificationSetUp : MonoBehaviour
{
    [SerializeField] private Image itemIcon;

    [SerializeField] private TextMeshProUGUI quantitiesDisplay;

    [SerializeField] private int quantitiesReceived;
    public int QuantitiesReceived
    {
        get { return quantitiesReceived; }
        set { quantitiesReceived = value; }
    }

    [SerializeField] private Animator animator;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (animator != null)
        {
            
            if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.99) { 
                gameObject.SetActive(false);
            }
        }
        
    }

    public void NotifyItemReceived(Sprite aItemIcon, bool isIncreasingQuantities) {

        this.itemIcon.sprite = aItemIcon;

        string textDisplay = "" + quantitiesReceived;

        if(isIncreasingQuantities) { 
            textDisplay = "+" + textDisplay;
        }
        else
        {
            textDisplay = "-" + textDisplay;
        }

        quantitiesDisplay.text = textDisplay;

        gameObject.SetActive(true); 

    }


}
