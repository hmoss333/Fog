using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public GameObject[] sceneObjects;
    public GameObject currentSceneObject;
    public static Dictionary<string, int> interactedObjects = new Dictionary<string, int>();

    public Player player;
    public float worldWrapOffset; //must be a higher value than the Fog offset (lighting settings)
    bool transitioned = false;
    float xOff;
    float zOff;

    public static bool interacted;
    
    // Use this for initialization
	void Start () {
        interacted = false;
        //CreateNewSceneObject();
    }

    //private void Update()
    //{
    //    if (interacted)
    //    {
    //        if (!AllObjectsInteracted(interactedObjects))
    //            LevelManager.ChangeLevel("Staircase");
    //        else
    //            LevelManager.ChangeLevel("Infinite Terrain");

    //        interacted = false;
    //    }
    //}

    // Update is called once per frame
    void FixedUpdate () {
        //should fade in from black before enabling movement in this scene

        //World Wrap Logic
        if (!transitioned)
        {
            if (player.transform.position.x > worldWrapOffset || player.transform.position.x < -worldWrapOffset)
            {
                player.transform.position = new Vector3(-player.transform.position.x, player.transform.position.y, player.transform.position.z);
                CreateNewSceneObject();
                transitioned = true;
            }
            if (player.transform.position.z > worldWrapOffset || player.transform.position.z < -worldWrapOffset)
            {
                player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -player.transform.position.z);
                CreateNewSceneObject();
                transitioned = true;
            }
        }
        else
        {
            if ((player.transform.position.x < worldWrapOffset || player.transform.position.x > -worldWrapOffset) || (player.transform.position.z < worldWrapOffset || player.transform.position.z > -worldWrapOffset))
            {
                transitioned = false;
            }
        }
    }


    void CreateNewSceneObject()
    {
        Destroy(currentSceneObject);
        currentSceneObject = NewCurrentSceneObject(sceneObjects);
        currentSceneObject = Instantiate(currentSceneObject);
    }
    GameObject NewCurrentSceneObject(GameObject[] listOfObjects)
    {
        GameObject tempObject;

        int randNum;
        randNum = Random.Range(0, listOfObjects.Length);

        tempObject = listOfObjects[randNum];

        return tempObject;
    }

    public static void UpdateObjects(string key, int value)
    {
        if (interactedObjects.ContainsKey(key))
        {
            interactedObjects.Remove(key);
            interactedObjects.Add(key, value);
            Debug.Log("Replaced key");
        }
    }
    bool AllObjectsInteracted(Dictionary<string, int> objectsToCheck)
    {
        for (int i = 0; i < objectsToCheck.Count; i++)
        {
            if (objectsToCheck.ContainsValue(0))
                return false;
        }

        return true;
    }
}
