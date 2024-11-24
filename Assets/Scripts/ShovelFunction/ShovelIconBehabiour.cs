using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShovelIconBehabiour : MonoBehaviour, IPointerClickHandler
{

    [SerializeField] private string DirtOwnPlantTag;
    private Vector3 GetPlayerMousePointPos()
    {

        return Input.mousePosition;


    }



    private void OnEnable()
    {
        transform.position = GetPlayerMousePointPos();
    }

    private void Update()
    {
        transform.position = GetPlayerMousePointPos();

    }




    public void OnPointerClick(PointerEventData eventData)
    {
        GameObject detectedDirtOwnPlant = DetectDirtOwnPlant();

        if (detectedDirtOwnPlant != null) {

            detectedDirtOwnPlant.GetComponent<PlantSeedsProcessController>().RemoveCurrentOwnPlant();

        }

        gameObject.SetActive(false);
    }

    private GameObject DetectDirtOwnPlant()
    {
        
        PointerEventData pointerEventData = new PointerEventData(EventSystem.current);

        pointerEventData.position = Input.mousePosition;

        List<RaycastResult> results = new List<RaycastResult>();

        EventSystem.current.RaycastAll(pointerEventData, results);

        foreach (RaycastResult result in results)
        {
            string detectedGameObjectTag = result.gameObject.tag;

            Debug.Log("Hit UI Element: " + detectedGameObjectTag);

            if(detectedGameObjectTag == DirtOwnPlantTag)
            {
                return result.gameObject;
            }
        }

        return null;
    }
}
