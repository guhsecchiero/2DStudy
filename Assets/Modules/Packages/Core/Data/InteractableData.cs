using UnityEngine;

namespace Packages.Core.Data
{
    [CreateAssetMenu(menuName = "Game/Interactable Data", fileName = "NewInteractableData")]
    public class InteractableData : ScriptableObject
    {
        public string objectName;
        [TextArea]
        public string description;

        public AudioClip interactionSound;
        public Sprite icon;
        public GameObject itemToGivePrefab; // Optional: spawn this on interaction
    }
}
