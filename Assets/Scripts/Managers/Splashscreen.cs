using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Splashscreen : MonoBehaviour {

    //public Text loadingText;
    //bool fadeText = false;

    public static string sceneToLoad = "MainMenu";

    AsyncOperation ao;

    // Use this for initialization
    void Start () {
        StartCoroutine(LaunchScene(sceneToLoad, 5f));
	}

    // Update is called once per frame
    //void Update()
    //{
    //    if (fadeText)
    //    {
    //        loadingText.color = new Color(loadingText.color.r, loadingText.color.g, loadingText.color.b, loadingText.color.a - Time.deltaTime);
    //        if (loadingText.color.a <= 0.1f)
    //        {
    //            ao.allowSceneActivation = true;
    //        }
    //    }
    //}

    IEnumerator LaunchScene(string sceneToLoad, float waitTime)
    {
        yield return null;
        ao = SceneManager.LoadSceneAsync(sceneToLoad);
        ao.allowSceneActivation = false;

        while (!ao.isDone)
        {
            float progress = Mathf.Clamp01(ao.progress / 0.9f);

            //load completed
            if (ao.progress == 0.9f)
            {
                yield return new WaitForSeconds(0.5f);
                ao.allowSceneActivation = true;
                //fadeText = true;
            }
            yield return null;
        }
    }
}
