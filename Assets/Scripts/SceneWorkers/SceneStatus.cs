using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace BlockBreaker {
    public class SceneStatus : MonoBehaviour {
        [SerializeField] public SceneLoaderMenu sceneLoaderMenu;
        [SerializeField] public Text scoreText;
        [SerializeField] public int score;
        [SerializeField] public int totalBlocksCount;
        private int _destroyedBlocksCount;
        private SceneAsset _nextScene;

        /** Block before destroy call this method for count destrouded blocs*/
        public void AddToScore(int scoreValue) {
            score += scoreValue;
            _destroyedBlocksCount++;
            Debug.Log(String.Format("{0}/{1}", _destroyedBlocksCount, totalBlocksCount));
            scoreText.text = score.ToString();
            if (_destroyedBlocksCount == totalBlocksCount)
                getNextLevel();
        }

        /** use for each Block class for count all blocks in scene*/
        public void AddToTotalScore() {
            totalBlocksCount++;
        }

        private void getNextLevel() {
            if (sceneLoaderMenu != null && _nextScene != null) {
                sceneLoaderMenu.loadTheScene(_nextScene);
            }
        }

        private void Awake() {
            int ssCount = FindObjectsOfType<SceneStatus>().Length;
            if (ssCount > 1) {
                gameObject.SetActive(false);
                Destroy(gameObject);
            }
            else
                DontDestroyOnLoad(gameObject);

            reset();
        }

        private void Start() {
            SceneManager.sceneLoaded += onSceneLoaded;
            _nextScene = FindObjectOfType<NextSceneStorage>()?.StoredScene;
            Debug.Log("next sccene is " + _nextScene.name);
        }

        private void onSceneLoaded(Scene scene, LoadSceneMode mode) {
            Debug.Log("OnSceneLoaded: " + scene.name);
            NextSceneStorage _nStore = FindObjectOfType<NextSceneStorage>();
            if (_nStore != null) {
                _nextScene = _nStore.StoredScene;
                Debug.Log("next scene is " + _nextScene.name);
            }
            else {
                Debug.Log("NextSceneStorage not found.");
            }
        }

        private void reset() {
            Debug.Log("reset");
            totalBlocksCount = 0;
            score = 0;
            scoreText.text = score.ToString();
        }
    }
}