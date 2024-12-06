using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.AssemblyQualifiedNameParser;
using UnityEngine;

public class GachaTicketOwnedDisplay : MonoBehaviour, IOnGachaTicketsChange
{
    // Start is called before the first frame update
    [SerializeField] private TextMeshProUGUI quantitiesGachaTicketsOwned;

    [SerializeField] private GachaTicketsChangeScriptableObject ticketsChangeScriptableObject;

    public void OnGachaTicketsChange(int quantities)
    {
        Debug.Log("display quantities gacha ticket : " + quantities);
        quantitiesGachaTicketsOwned.text = quantities.ToString();
    }

    public void OnSubscribe()
    {
        ticketsChangeScriptableObject.AddListener(this);
    }

    public void OnUnsubscribe() {

        ticketsChangeScriptableObject.RemoveListener(this);
    }

    private void Awake()
    {
        OnSubscribe();
    }

  
    private void OnEnable()
    {
        OnSubscribe();
    }

    private void OnDisable()
    {
        OnUnsubscribe();  
    }


    void OnDestroy()
    {
        OnUnsubscribe();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
