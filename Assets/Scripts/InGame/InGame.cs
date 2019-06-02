using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class InGame : MonoBehaviour {
    [SerializeField] public BlockBreaker.SceneLoaderMenu sceneLoaderMenu;

    // Start is called before the first frame update
    void Start() {
        Debug.Log("In game loaded! Press ESCAPE for return to start menu \n or A to game over menu");
    }

    // Update is called once per frame
    void Update() {
        if (Input.anyKey) {
//        if (!String.IsNullOrEmpty(Input.inputString)) {
//            Debug.Log(Input.inputString);
            if (Input.GetKey(KeyCode.Escape)) {
                sceneLoaderMenu.GetStartScene();
            }

            if (Input.GetKey(KeyCode.A)) {
                sceneLoaderMenu.GetGameOverScene();
            }
        }
    }
}