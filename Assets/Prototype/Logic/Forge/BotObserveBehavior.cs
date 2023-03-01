using System;
using Prototype.Logic.Interactables;
using UnityEngine;

namespace Prototype.Logic.Forge
{
    public class BotObserveBehavior : ObserveBehavior
    {
        public override bool IsObserve => ObservedBot != null;
        
        [HideInInspector] public GameObject ObservedBot;

        [SerializeField] private BotHuntingBehavior _botHuntingBehavior;

        protected override Func<GameObject, bool> IsObserveTarget { get; } = 
            target => target.CompareTag("Bot");
        
        protected override void SetupObservedObject(GameObject target) => 
            ObservedBot = target;

        protected override void ClearObservedObject() => 
            ObservedBot = null;

        protected override void Interact(GameObject target) => 
            _botHuntingBehavior.Hunt(ObservedBot);
    }
}