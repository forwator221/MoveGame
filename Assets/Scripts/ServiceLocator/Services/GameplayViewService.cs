using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ServiceLocator
{
    public class GameplayViewService : MonoBehaviour, IService
    {
        private SceneManager _sceneManager;

        private void Awake()
        {
            ServiceLocator.Register(this);

            _sceneManager = ServiceLocator.Get<SceneManager>();
        }
    }
}
