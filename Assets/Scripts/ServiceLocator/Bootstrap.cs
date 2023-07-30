using UnityEngine;


namespace ServiceLocator
{
    public class Bootstrap : MonoBehaviour
    {
        private void Start()
        {
            // register services
            var sceneManager = new SceneManager();
            ServiceLocator.RegisterRoot(sceneManager);

            sceneManager.LoadScene(StringConstants.MAIN_MENU_SCENE_NAME);
        }
    }
}

