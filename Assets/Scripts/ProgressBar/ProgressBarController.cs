using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Slider progressBar;

    [SerializeField] private TextMeshProUGUI progressText;

    private static ProgressBarController instance;
    public static ProgressBarController Instance {  get { return instance; } }

    private ProgressBarController() { }


    void Start()
    {
        if (instance == null) { 
            instance = this; 
            DontDestroyOnLoad(instance);
        }
        else
        {
            if(instance != this) {
                DontDestroyOnLoad(gameObject);
            }
        }
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisplayValueOfProgressBar(float value)
    {
        if (progressBar != null)
        {
            progressBar.value = value;
        }

        if (progressText != null) { 
            progressText.text = (value * 100f) + "%";
        }
    }


}
