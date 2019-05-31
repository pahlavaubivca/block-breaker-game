using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace BlockBreaker {
    public class SceneStatus : MonoBehaviour {
        [SerializeField] public SceneLoaderMenu sceneLoaderMenu;
        [SerializeField] public SceneAsset nextScene;
        [SerializeField] public Text scoreText;
        [SerializeField] public int score;
        [SerializeField] public int totalBlocksCount;
        private int destoyedBlocksCount;

        public void addToScore(int scoreValue) {
            score += scoreValue;
            destoyedBlocksCount++;
            Debug.Log(String.Format("{0}/{1}", destoyedBlocksCount, totalBlocksCount));
            scoreText.text = score.ToString();
            if (destoyedBlocksCount == totalBlocksCount)
                getNextLevel();
        }

        public void addToTotalScore() {
            totalBlocksCount++;
        }

        public void getNextLevel() {
            if (sceneLoaderMenu != null && nextScene != null)
                sceneLoaderMenu.loadTheScene(nextScene);
        }

        private void Awake() {
            int ssCount = FindObjectsOfType<SceneStatus>().Length;
            Debug.Log("AWAKE");
            // Debug.Log(currentScore+"|"+score);
            if (ssCount > 1) {
                gameObject.SetActive(false);
                Destroy(gameObject);
            }
            else
                DontDestroyOnLoad(gameObject);

            reset();
        }

        // Start is called before the first frame update
        void Start() {
            startLoagger();
        }

        void reset() {
            Debug.Log("reset");
            totalBlocksCount = 0;
            score = 0;
            scoreText.text = score.ToString();
        }

        void startLoagger() {
            Debug.Log("Selected as next scene is " + nextScene.name);
        }
    }
}