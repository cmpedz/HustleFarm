using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraIconController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform pointFollow;
    void Start()
    {
        transform.position = pointFollow.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = pointFollow.position;
    }
    private void OnEnable()
    {
        transform.position = pointFollow.position;
    }
}
