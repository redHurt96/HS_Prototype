using System;
using UnityEngine;

namespace Prototype.Logic.Interactables
{
    public abstract class ObserveBehavior : MonoBehaviour
    {
        public abstract bool IsObserve { get; }
        protected abstract Func<GameObject, bool> IsObserveTarget { get; }

        [SerializeField] private InteractionBehavior _interactionBehavior;

        [Space] 
        [SerializeField] private KeyCode _interactKey = KeyCode.E;

        [SerializeField] private bool _hasAdditionalFunction = false;
        [SerializeField] private KeyCode _additionalKey = KeyCode.G;

        private void Update()
        {
            if (_interactionBehavior.IsObserve
                && IsObserveTarget(_interactionBehavior.ObservedObject))
            {
                SetupObservedObject(_interactionBehavior.ObservedObject);
                ProcessInput();
            }
            else
            {
                ClearObservedObject();
            }
        }

        protected abstract void SetupObservedObject(GameObject target);
        protected abstract void ClearObservedObject();
        protected abstract void Interact(GameObject target);

        protected virtual void AdditionalInteract(GameObject target) => 
            throw new NotImplementedException();
        
        private void ProcessInput()
        {
            if (Input.GetKeyDown(_interactKey))
                Interact(_interactionBehavior.ObservedObject);
            else if (_hasAdditionalFunction && Input.GetKeyDown(_additionalKey))
                AdditionalInteract(_interactionBehavior.ObservedObject);
        }
    }
}