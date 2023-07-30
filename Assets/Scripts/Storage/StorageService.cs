using System.Collections.Generic;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine;

namespace ServiceLocator
{
    public class StorageService : IService
    {
        [Header("Debugging")]
        [SerializeField] private bool _initializeDataIfNull = false;

        [Header("File Storage Config")]
        [SerializeField] private string _fileName;

        private GameData _gameData;
        private List<IStorage> _dataPersistenceObjects;
        private FileDataHandler _dataHandler;

        private void Awake()
        {
            this._dataHandler = new FileDataHandler(Application.persistentDataPath, _fileName);
        }

        public void NewGame()
        {
            this._gameData = new GameData();
        }

        public void LoadGame()
        {
            this._gameData = _dataHandler.Load();

            if (this._gameData == null && _initializeDataIfNull)
            {
                NewGame();
            }

            if (this._gameData == null)
            {
                return;
            }

            foreach (IStorage dataPersistenceObj in _dataPersistenceObjects)
            {
                dataPersistenceObj.LoadData(_gameData);
            }
        }

        public void SaveGame()
        {
            if (this._gameData == null)
            {
                return;
            }
            foreach (IStorage datePersistenceObj in _dataPersistenceObjects)
            {
                datePersistenceObj.SaveData(ref _gameData);
            }
            _dataHandler.Save(_gameData);
        }

        private void OnApplicationQuit()
        {
            SaveGame();
        }

        public bool HasGameData()
        {
            return _gameData != null;
        }
    }
}

