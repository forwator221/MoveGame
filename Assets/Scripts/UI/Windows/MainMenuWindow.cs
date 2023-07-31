using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using ServiceLocator;

namespace UI
{
    // main menu UI
    public class MainMenuWindow : UIWindow
    {
        [SerializeField] private Button _continueBtn;
        [SerializeField] private Button _newGameBtn;
        [SerializeField] private Button _selectLevelBtn;
        [SerializeField] private Button _settingsBtn;
        [SerializeField] private Button _exitBtn;

        private StorageService _storageService;
        private SceneManager _sceneManager;

        protected void Awake()
        {
            base.Awake();

            _storageService = ServiceLocator.ServiceLocator.Get<StorageService>();
            _sceneManager = ServiceLocator.ServiceLocator.Get<SceneManager>();

            _continueBtn.onClick.AddListener(OnContiuneBtnClick);
            _newGameBtn.onClick.AddListener(OnNewGameBtnClick);
            _selectLevelBtn.onClick.AddListener(OnSelectLevelBtnClick);
            _settingsBtn.onClick.AddListener(OnSettingsBtnClick);
            _exitBtn.onClick.AddListener(OnExitBtnClick);
        }

        private void OnContiuneBtnClick()
        {
            _sceneManager.LoadScene(StringConstants.GAME_SCENE_NAME);
        }

        private void OnNewGameBtnClick()
        {
            _storageService.NewGame();
            _sceneManager.LoadScene(StringConstants.GAME_SCENE_NAME);
        }

        private void OnSelectLevelBtnClick()
        {
            
        }

        private void OnSettingsBtnClick()
        {

        }

        private void OnExitBtnClick()
        {

        }
    }
}
