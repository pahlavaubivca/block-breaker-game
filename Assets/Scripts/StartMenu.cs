using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour {
    // Start is called before the first frame update
    void Start() {
//        int numOfScenes = SceneManager.sceneCountInBuildSettings;
//        Debug.Log(numOfScenes);
//        for (int i = 0; i < numOfScenes; i++) {
//            Scene selectedScene = SceneManager.GetSceneByBuildIndex(i);
//            Debug.Log(selectedScene.name);
//        }
    }

    // Update is called once per frame
    void Update() {
    }

    public void Exit() {
        Application.Quit();
    }
}