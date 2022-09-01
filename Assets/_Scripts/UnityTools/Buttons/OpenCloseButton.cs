using UnityEngine;

namespace TwoDoors.GUI.Buttons
{
    /// <summary>
    /// Activates and disactivates GameObjects.
    /// It's also able to add reference only to one object. (Only open or only close)
    /// </summary>
    public class OpenCloseButton : UIButton
    {
        [SerializeField] private GameObject _toOpen;
        [SerializeField] private GameObject _toClose;

        protected override void OnClicked()
        {
            if (_toOpen != null)
                _toOpen.SetActive(true);

            if (_toClose != null)
                _toClose.SetActive(false);
        }
    }
}