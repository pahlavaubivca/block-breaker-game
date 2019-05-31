using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BottomTrigger : MonoBehaviour {
    [SerializeField] private BlockBreaker.SceneLoaderMenu scenes;

    private void OnTriggerEnter2D(Collider2D collider) {
        if (scenes != null) {
            scenes.GetGameOverScene();
        }
    }
}