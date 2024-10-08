using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementController : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector2 lastPosMouse;

    [SerializeField] private float speedCamera;

    [SerializeField] private Transform topLeftLimitPoint;

    [SerializeField] private Transform bottomRightLimitPoint;

    private bool isMouseDowned = false;
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)) {

            isMouseDowned = true;

            lastPosMouse = Input.mousePosition;

        }

        if(Input.GetMouseButtonUp(0)) { 
            isMouseDowned= false;
        }
       
        if(isMouseDowned)
        {
            MoveCamera();
        }
        
    }

    private void MoveCamera() {

        Vector3 vectorMoveUnit = (lastPosMouse - (Vector2)Input.mousePosition).normalized;

        Vector3 newCameraPos = transform.position + vectorMoveUnit * speedCamera * Time.deltaTime;

        float cameraHeightInUnits = Camera.main.orthographicSize * 2;

        SetNewPositionForCamera(newCameraPos, cameraHeightInUnits);


    }

    public void SetNewPositionForCamera(Vector3 newCameraPos, float cameraHeightInUnits) {


        float cameraWidthInUnits = cameraHeightInUnits * Camera.main.aspect;

        Debug.Log("check camera height : " + cameraHeightInUnits + ", camera width : " + cameraWidthInUnits);

        if(newCameraPos.y + cameraHeightInUnits / 2 > topLeftLimitPoint.position.y)
        {
            newCameraPos.y = topLeftLimitPoint.position.y - cameraHeightInUnits/2;
        }

        if (newCameraPos.y - cameraHeightInUnits / 2 < bottomRightLimitPoint.position.y)
        {
            newCameraPos.y = bottomRightLimitPoint.position.y + cameraHeightInUnits / 2;
        }

        if (newCameraPos.x - cameraWidthInUnits / 2 < topLeftLimitPoint.position.x) {

            newCameraPos.x = topLeftLimitPoint.position.x + cameraWidthInUnits / 2;

        }

        if (newCameraPos.x + cameraWidthInUnits / 2 > bottomRightLimitPoint.position.x)
        {

            newCameraPos.x = bottomRightLimitPoint.position.x - cameraWidthInUnits / 2;

        }



        transform.position = newCameraPos;
    }
}
