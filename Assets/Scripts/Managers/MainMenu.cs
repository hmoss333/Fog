using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
        PlayerPrefs.SetInt("Bar", 0);
        PlayerPrefs.SetInt("Mirror", 0);
        PlayerPrefs.SetInt("Table", 0);
        PlayerPrefs.SetInt("Chair", 0);

        GameManager.interactedObjects.Clear();
        GameManager.interactedObjects.Add("Bar", PlayerPrefs.GetInt("Bar"));
        GameManager.interactedObjects.Add("Mirror", PlayerPrefs.GetInt("Mirror"));
        GameManager.interactedObjects.Add("Table", PlayerPrefs.GetInt("Table"));
        GameManager.interactedObjects.Add("Chair", PlayerPrefs.GetInt("Chair"));

        Cursor.lockState = CursorLockMode.Confined;
    }

    // Update is called once per frame
    void Update () {
        
    }

    public void StartGame()
    {
        LevelManager.ChangeLevel("Staircase");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
