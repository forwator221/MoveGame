using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    // parent for all UI windows
    public abstract class UIWindow : MonoBehaviour
    {
        [SerializeField] private Button _outsideArea;
        protected virtual void Awake()
        {
            if (_outsideArea != null)
            {
                _outsideArea.onClick.AddListener(Hide);
            }
        }

        protected void Hide()
        {
            Destroy(gameObject);
        }

        protected void OnDestroy()
        {
            if (_outsideArea != null)
            {
                _outsideArea.onClick.RemoveAllListeners();
            }
        }
    }
}
