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

    [SerializeField] private string foodDemandTag;




    // Update is called once per frame
    void Update()
    {
        if(transform.localScale.x < 0)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x),transform.localScale.y,transform.localScale.z);
        }


        UpdateOrderSpriteRenderer();

        FeedAnimal();
    }

    private void FeedAnimal()
    {

        if (Input.GetMouseButtonDown(0)) 
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            if(hit.collider != null)
            {
                if (hit.collider.tag == foodDemandTag && hit.collider.gameObject == gameObject)
                {
                    clickedEvent?.Invoke();

                }
            }
           
        }
    }

    private void UpdateOrderSpriteRenderer()
    {
        this.animalDemandBg.sortingOrder = animal.GetComponent<SpriteRenderer>().sortingOrder + 1;

        this.demandFood.sortingOrder = animal.GetComponent<SpriteRenderer>().sortingOrder + 2;
    }
}
