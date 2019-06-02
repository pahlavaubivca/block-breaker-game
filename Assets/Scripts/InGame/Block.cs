using System;
using System.Collections;
using System.Collections.Generic;
using BlockBreaker;
using UnityEngine;

public class Block : MonoBehaviour {
    [SerializeField] AudioClip breakSound;

    [SerializeField] int ScoreValue = 1;
    [SerializeField] GameObject breakVFX;

    private SceneStatus _sceneStatus;

    private void Start() {
        _sceneStatus = FindObjectOfType<SceneStatus>();
        if (_sceneStatus != null)
            _sceneStatus.AddToTotalScore();
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (breakSound)
            AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position, 0.5f);
        _sceneStatus.AddToScore(ScoreValue);
        ByDestroy();
        Destroy(gameObject);
    }

    private void ByDestroy() {
        GameObject _destoryVFX = Instantiate(breakVFX, transform.position, transform.rotation);
    }
}