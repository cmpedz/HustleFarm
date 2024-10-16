using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectOrderInLayerController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private SpriteRenderer spriteRenderer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int numberExchange = -1000;
        spriteRenderer.sortingOrder = (int) (gameObject.transform.position.y * numberExchange);
    }
}
