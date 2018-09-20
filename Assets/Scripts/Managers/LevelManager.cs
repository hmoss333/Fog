using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

    public static LevelManager instance = null;

    public Image fadeImage;
    public static bool fading = false;
    public static string levelName = "";
    float fadeTime = 0.333f; //For symbolism

    public List<AudioSource> audioSources = new List<AudioSource>();

	// Use this for initialization
	void Start () {
        fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, 1f);
        levelName = SceneManager.GetActiveScene().name;

        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad(this.gameObject);
    }

    //private void OnEnable()
    //{
    //    audioSources.Clear();
    //    audioSources.AddRange(GameObject.FindObjectsOfType<AudioSource>());
    //}

    // Update is called once per frame
    void Update () {
        //Audio Volume Controls
        if (levelName == SceneManager.GetActiveScene().name && audioSources.Count == 0)
        {
            audioSources.Clear();
            audioSources.AddRange(GameObject.FindObjectsOfType<AudioSource>());
        }

        //Fade to black
        if (fading)
        {
            fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, fadeImage.color.a + fadeTime * Time.deltaTime);
            foreach (AudioSource ads in audioSources)
            {
                if (ads && ads.volume > 0)
                    ads.volume -= Time.deltaTime;
            }

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
            foreach (AudioSource ads in audioSources)
            {
                if (ads && ads.volume < 1)
                    ads.volume += Time.deltaTime;
            }
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

        audioSources.Clear();
        SceneManager.LoadSceneAsync(sceneName);
    }
}
