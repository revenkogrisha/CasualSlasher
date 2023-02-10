using UnityEngine;
using UnityEngine.UI;

namespace UnityTools.Buttons
{
    [RequireComponent(typeof(Button))]
    public abstract class UIButton : MonoBehaviour
    {
        [Tooltip("If required (Can be null; no exception)")]
        [SerializeField] protected AudioSource Audio;

        protected Button Button;

        #region MonoBehaviour

        protected void Awake()
        {
            Button = GetComponent<Button>();
        }

        protected void OnEnable()
        {
            Button.onClick.AddListener(PlaySound);
            Button.onClick.AddListener(OnClicked);
        }

        protected void OnDisable()
        {
            Button.onClick.RemoveAllListeners();
        }

        #endregion

        protected abstract void OnClicked();

        private void PlaySound()
        {
            if (Audio != null)
                Audio.Play();
        }
    }
}
