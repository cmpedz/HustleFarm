using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GachaItemController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Image itemDisplay;
    private Sprite itemSprite;
    public Sprite ItemSprite
    {
        get { return itemSprite;} set { itemSprite = value; }
    }
    void Start()
    {
        if (itemDisplay != null && itemSprite != null) { 
            itemDisplay.sprite = itemSprite;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
