using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class AnimalDemandAnnocementController : MonoBehaviour
{

    public UnityEvent clickedEvent;

    [SerializeField] private GameObject animal;

    [SerializeField] private SpriteRenderer animalDemandBg;

    [SerializeField] private SpriteRenderer demandFood;



    void OnMouseDown(){
        Debug.Log("mouse down");
        clickedEvent?.Invoke();
    }



    // Update is called once per frame
    void Update()
    {
        if(transform.localScale.x < 0)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x),transform.localScale.y,transform.localScale.z);
        }


        UpdateOrderSpriteRenderer();
    }

    private void UpdateOrderSpriteRenderer()
    {
        this.animalDemandBg.sortingOrder = animal.GetComponent<SpriteRenderer>().sortingOrder + 1;

        this.demandFood.sortingOrder = animal.GetComponent<SpriteRenderer>().sortingOrder + 2;
    }
}
