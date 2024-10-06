using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class Item : MonoBehaviour, IPointerClickHandler
{

    [SerializeField] private ObjectData itemData;

    [SerializeField] private TextMeshProUGUI quantitiesDisplay;

    [SerializeField] private Image itemSpriteDisplay;

    private int quantities = 1;
    public int Quantities { get { return quantities; } }
    public void OnPointerClick(PointerEventData eventData)
    {
        ItemClickedEvents();
    }

    private void Start()
    {
        if(itemSpriteDisplay != null && itemData != null)
        {
            itemSpriteDisplay.sprite = itemData.sprite;
        }
    }

    public Item GetClone() { 

           GameObject _item = Instantiate(gameObject);

           _item.SetActive(true);

           _item.transform.localScale = transform.localScale;

           return _item.GetComponent<Item>();
    }

    public string GetItemId()
    {
        return itemData.name;
    }

    public Sprite GetItemSprite() { 
        return itemData.sprite;
    }

    public abstract void ItemClickedEvents();

    public void InscreaseQuantitiesItem(int numbers) { 

        for(int i = 0; i < numbers; i++)
        {
            this.quantities++;
        }

        if(this.quantities > 0 && quantitiesDisplay != null)
        {
            quantitiesDisplay.text = "X" + quantities;
        }

    }

    public void DescreaseQuantitiesItem(int numbers)
    {

        for (int i = 0; i < numbers; i++)
        {
            this.quantities--;
        }

        if (quantities < 0) quantities = 0;

        if (this.quantities > 0 && quantitiesDisplay != null)
        {
            quantitiesDisplay.text = "X " + quantities;
        }

    }
}
