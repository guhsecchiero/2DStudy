using UnityEngine;
using Packages.Core.Interfaces;
using System.Collections.Generic;


namespace Packages.Core.Managers
{
    public class InteractionManager : MonoBehaviour
    {
        [SerializeField] private KeyCode interactionKey = KeyCode.E;
        [SerializeField] private LayerMask interactableLayer;

        private readonly List<IInteractable> nearbyInteractables = new();

        private void Update()
        {
            if (Input.GetKeyDown(interactionKey) && nearbyInteractables.Count > 0)
            {
                // Prioritize the last one entered or sort by distance if needed
                nearbyInteractables[^1].Interact();
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if ((interactableLayer.value & (1 << other.gameObject.layer)) == 0) return;

            var interactable = other.GetComponent<IInteractable>();
            if (interactable != null && !nearbyInteractables.Contains(interactable))
                nearbyInteractables.Add(interactable);
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            var interactable = other.GetComponent<IInteractable>();
            if (interactable != null && nearbyInteractables.Contains(interactable))
                nearbyInteractables.Remove(interactable);
        }
    }
}
