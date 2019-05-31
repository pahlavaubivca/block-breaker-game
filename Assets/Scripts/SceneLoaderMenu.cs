using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BlockBreaker {
    [CreateAssetMenu(menuName = "SceneLoaderMenu")]
    public class SceneLoaderMenu : ScriptableObject {
        [SerializeField] SceneAsset StartScene;
        [SerializeField] SceneAsset OptionScene;
        [SerializeField] SceneAsset InGameScene;
        [SerializeField] SceneAsset InGameScene2;
        [SerializeField] SceneAsset GameOverScene;

        public void GetStartScene() {
            loadTheScene(StartScene);
        }

        public void GetOptionScene() {
            loadTheScene(OptionScene);
        }

        public void GetInGameScene() {
            loadTheScene(InGameScene);
        }

        public void GetInGameScene2() {
            loadTheScene(InGameScene2);
        }

        public void GetGameOverScene() {
            loadTheScene(GameOverScene);
        }

        public void loadTheScene(SceneAsset scene) {
            if (scene) {
                SceneManager.LoadScene(scene.name);
            }
            else {
                Debug.Log("Scene {0} not found", scene);
            }
        }
    }
}