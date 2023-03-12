using System;
using Prototype.Logic.Extensions;
using Prototype.Logic.Interactables;
using UnityEngine;

namespace Prototype.Logic.Forge
{
    public class BotObserveBehavior : ObserveBehavior
    {
        public override bool IsObserve => ObservedBot != null;
        
        [HideInInspector] public Bot ObservedBot;

        [SerializeField] private BotHuntingBehavior _botHuntingBehavior;

        protected override Func<GameObject, bool> IsObserveTarget { get; } = 
            target => target.HasComponent<Bot>();
        
        protected override void SetupObservedObject(GameObject target) => 
            ObservedBot = target.GetComponent<Bot>();

        protected override void ClearObservedObject() => 
            ObservedBot = null;

        protected override void Interact(GameObject target) => 
            _botHuntingBehavior.Hunt(ObservedBot);
    }
}