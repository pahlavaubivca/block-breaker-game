using System;
using System.Collections;
using System.Collections.Generic;
using BlockBreaker;
using UnityEngine;

public class Block : MonoBehaviour {
    [SerializeField] AudioClip breakSound;

    [SerializeField] int ScoreValue = 1;
    [SerializeField] GameObject breakVFX;
    [SerializeField] int health = 1;
    [SerializeField] Sprite[] damageLevel;

    private SceneStatus _sceneStatus;
    private bool isBreakable;

    private void Start() {
        _sceneStatus = FindObjectOfType<SceneStatus>();
        isBreakable = tag == "Breakable";
        if (_sceneStatus != null && isBreakable) {
            Color _color = Color.black;
            if (health >= 3)
                _color = Color.red;
            else if (health == 2)
                _color = Color.green;
            else if (health == 1)
                _color = Color.cyan;
            GetComponent<SpriteRenderer>().color = _color;
            _sceneStatus.AddToTotalScore();
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (isBreakable) {
            health--;
            if (health == 0)
                breakBlock();
            else if (damageLevel.Length > 0) {
                changeDamageLevel();
            }
        }
    }

    private void changeDamageLevel() {
        int _demLevel = health - 1;
        if (_demLevel <= damageLevel.Length)
            GetComponent<SpriteRenderer>().sprite = damageLevel[_demLevel];
    }

    private void breakBlock() {
        if (breakSound)
            AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position, 0.5f);
        _sceneStatus.AddToScore(ScoreValue);
        Destroy(gameObject);
        ByDestroy();
    }

    private void ByDestroy() {
        GameObject _destoryVFX = Instantiate(breakVFX, transform.position, transform.rotation);
//        yield return new WaitForSeconds(1);
        Destroy(_destoryVFX, 1f);
    }
}