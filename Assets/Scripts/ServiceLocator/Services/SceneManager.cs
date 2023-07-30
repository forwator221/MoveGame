using System;
using System.Collections.Generic;


namespace ServiceLocator
{
    public class SceneManager : IService
    {
        public void LoadScene(string sceneName)
        {
            ServiceLocator.CleanServices();
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
        }
    }
}
