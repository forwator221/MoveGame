using System;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class UIWindowService
    {
        private const string PrefabsFilePath = "/UIWindows";

        private static readonly Dictionary<Type, string> PrefabsDictionary = new Dictionary<Type, string>()
        {
            {typeof(MainMenuWindow), "MainMenu/MainMenuWindow" },
            {typeof(SelectLevelWindow), "MainMenu/SelectLevelWindow" },
        };

        public static T ShowDialog<T>() where T : UIWindow
        {
            var go = GetPrefabByType<T>();
            if (go == null)
            {
                Debug.LogError("Show window - object not found");
                return null;
            }

            return GameObject.Instantiate(go, GuiHolder);
        }

        private static T GetPrefabByType<T>() where T : UIWindow
        {
            var prefabName = PrefabsDictionary[typeof(T)];
            if (string.IsNullOrEmpty(prefabName))
            {
                Debug.LogError("Cant find prefab type of " + typeof(T));
            }

            var path = PrefabsFilePath + PrefabsDictionary[typeof(T)];
            var dialog = Resources.Load<T>(path);
            if (dialog == null)
            {
                Debug.LogError("Cant find prefab at path " + path);
            }

            return dialog;
        }

        // link to canvas on scene
        public static Transform GuiHolder
        {
            get { return ServiceLocator.ServiceLocator.Get<UIRoot>().transform; }
        }
    }
}
