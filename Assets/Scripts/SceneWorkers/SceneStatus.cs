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
        private bool _iMustBeDestroy;

        /** Block before destroy call this method for count destrouded blocs*/
        public void AddToScore(int scoreValue) {
            score += scoreValue;
            _destroyedBlocksCount++;
            Debug.Log(String.Format("{0}/{1}", _destroyedBlocksCount, totalBlocksCount));
            scoreText.text = score.ToString();
            /* check score and if break block == totalBlocks - load next scene*/
            if (_destroyedBlocksCount == totalBlocksCount && sceneLoaderMenu != null && _nextScene != null)
                sceneLoaderMenu.loadTheScene(_nextScene);
        }

        /** use for each Block class for count all blocks in scene*/
        public void AddToTotalScore() {
            totalBlocksCount++;
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
            Debug.Log("Next scene is " + _nextScene.name);
//            Time.timeScale = 3f;
        }

        private void onSceneLoaded(Scene scene, LoadSceneMode mode) {
            Debug.Log("OnSceneLoaded: " + scene.name);
            NextSceneStorage _nStore = FindObjectOfType<NextSceneStorage>();
            if (_nStore != null) {
                _nextScene = _nStore.StoredScene;
                Debug.Log("Next scene is " + _nextScene.name);
            }
            else if (gameObject != null) {
                SceneManager.sceneLoaded -= onSceneLoaded;
                Destroy(gameObject);
                Debug.Log("SceneStatus destroy itself");
            }
        }

        private void reset() {
            Debug.Log("RESET");
            totalBlocksCount = 0;
            score = 0;
            scoreText.text = score.ToString();
        }
    }
}