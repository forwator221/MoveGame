using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ServiceLocator
{
    public class MainMenuServiceLocator : MonoBehaviour, IService
    {
        [Header("Scene Services")]
        //[SerializeField] private 

        private SceneManager _sceneManager;
        private StorageService _storageService;

        private void Awake()
        {
            ServiceLocator.Register(this);

            _sceneManager = ServiceLocator.Get<SceneManager>();
            _storageService = ServiceLocator.Get<StorageService>();
        }

        public void NewGame()
        {
            _storageService.NewGame();
        }
    }
}
