using Packages.Core.Interfaces;
using Packages.Core.Data;
using UnityEngine;

namespace Packages.Core.Components
{
    public class InteractableComponent : MonoBehaviour, IInteractable
    {
        [SerializeField] private InteractableData data;
        private bool interacted = false;

        public void Interact()
        {
            if (interacted) return;
            interacted = true;

            Debug.Log($"Interacted with {data.objectName}: {data.description}");

            if (data.interactionSound)
                AudioSource.PlayClipAtPoint(data.interactionSound, transform.position);

            if (data.itemToGivePrefab)
                Instantiate(data.itemToGivePrefab, transform.position + Vector3.up, Quaternion.identity);

            // Optional: Destroy(gameObject);
        }

        public InteractableData GetData() => data;
    }
}
