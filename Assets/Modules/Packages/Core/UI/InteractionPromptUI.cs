using UnityEngine;
using TMPro;
using Packages.Core.Interfaces;

namespace Packages.Core.UI
{
    public class InteractionPromptUI : MonoBehaviour, IInteractionPromptUI
    {
        [SerializeField] private GameObject root;
        [SerializeField] private TextMeshProUGUI promptText;

        private void Awake()
        {
            HidePrompt();
        }

        public void ShowPrompt(string message)
        {
            if (promptText != null)
                promptText.text = message;

            root.SetActive(true);
        }

        public void HidePrompt()
        {
            root?.SetActive(false);
        }
    }
}
