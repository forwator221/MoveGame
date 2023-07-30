using UnityEngine;

namespace ServiceLocator
{
    public class Bootstrap : MonoBehaviour
    {
        private void Start()
        {
            var sceneManager = new SceneManager();
            ServiceLocator.RegisterRoot(sceneManager);
            ServiceLocator.RegisterRoot(new StorageService());

            sceneManager.LoadScene(StringConstants.MAIN_MENU_SCENE_NAME);
        }
    }

}
