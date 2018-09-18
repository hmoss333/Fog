using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

    public Image fadeImage;
    public static bool fading = false;
    public static string levelName = "";
    float fadeTime = 0.333f; //For symbolism

	// Use this for initialization
	void Start () {
        fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, 1f);
        levelName = SceneManager.GetActiveScene().name;

        DontDestroyOnLoad(this.gameObject);
    }
	
	// Update is called once per frame
	void Update () {
        //Fade to black
        if (fading)
        {
            fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, fadeImage.color.a + fadeTime * Time.deltaTime);

            if (fadeImage.color.a >= 1f)
            {
                fading = false;
                StartCoroutine(ChangeScene(levelName, 3f));
            }
        }

        //Fade from black
        if (SceneManager.GetActiveScene().name == levelName && fadeImage.color.a > 0.0f)
        {
            fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, fadeImage.color.a - fadeTime * Time.deltaTime);
        }
    }

    public static void ChangeLevel(string name)
    {
        levelName = name;
        fading = true;
    }

    IEnumerator ChangeScene(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);

        SceneManager.LoadSceneAsync(sceneName);
    }
}
