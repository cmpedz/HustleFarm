using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraVisionZoomController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private CinemachineVirtualCamera virtualCamera;

    [SerializeField] private float speedZoom;

    private float distanceZoomEachTime = 1;

    private float targetOrthoSize = 4f;

    private const float MAX_ORTHO_SIZE = 5f;

    private const float MIN_ORTHO_SIZE = 3f;

    void Start()
    {
        virtualCamera.m_Lens.OrthographicSize = targetOrthoSize;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ZoomIn() {
        targetOrthoSize -=  distanceZoomEachTime;

        if (targetOrthoSize < MIN_ORTHO_SIZE) targetOrthoSize = MIN_ORTHO_SIZE;

        virtualCamera.m_Lens.OrthographicSize = targetOrthoSize;
    }

    public void ZoomOut()
    {
        targetOrthoSize += distanceZoomEachTime;

        if (targetOrthoSize > MAX_ORTHO_SIZE) targetOrthoSize = MAX_ORTHO_SIZE;

        virtualCamera.m_Lens.OrthographicSize = targetOrthoSize;
    }


}
