using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonEventsFactory : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject progressScene;

    [SerializeField] private ProgressBarController progressBarController;


    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void MoveToSpecifiedScene(int indexScene){

        AsyncOperation progressController = SceneManager.LoadSceneAsync(indexScene);

        progressScene.SetActive(true);


        StartCoroutine(LoadingSceneIEnumrator(progressController));

        
    }

    private IEnumerator LoadingSceneIEnumrator(AsyncOperation progressController)
    {

        while (!progressController.isDone) {

            const float MAX_PROGRESS_VALUE = 0.9f;

            float currentProgress = Mathf.Clamp01(progressController.progress / MAX_PROGRESS_VALUE);

            progressBarController.DisplayValueOfProgressBar(currentProgress);

            yield return null;

        }
        
        progressScene.SetActive(false);
    }
}
