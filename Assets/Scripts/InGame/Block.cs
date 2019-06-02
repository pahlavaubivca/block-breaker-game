using System;
using System.Collections;
using System.Collections.Generic;
using BlockBreaker;
using UnityEngine;

public class Block : MonoBehaviour {
    [SerializeField] AudioClip breakSound;

    [SerializeField] int ScoreValue = 1;

    //todo refactor
    //[SerializeField] SceneStatus sStatus;
    private SceneStatus _sceneStatus;

    private void Start() {
        //todo refactor
        _sceneStatus = FindObjectOfType<SceneStatus>();
//        if (sStatus != null) {
//            _sceneStatus = sStatus;
//            Debug.Log("BLOCK START SSTATUS YOOOOO");
//        }
//        else
//            _sceneStatus = FindObjectOfType<SceneStatus>();

        _sceneStatus.AddToTotalScore();
    }

//    void Awake() {
//        if (sStatus != null) {
//            _sceneStatus = sStatus;
//            Debug.Log("BLOCK START SSTATUS YOOOOO");
//        }
////        else
////            _sceneStatus = FindObjectOfType<SceneStatus>();
//    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (breakSound)
            AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position, 0.5f);
//        if (_sceneStatus == null) {
//            Debug.Log("BLOCK: SceneStatus is null");
//            _sceneStatus = FindObjectOfType<SceneStatus>();
//        }

        _sceneStatus.AddToScore(ScoreValue);
//        if (BlockBreaker.Score != null)
//            BlockBreaker.Score.add();
        Destroy(gameObject);
    }
}