using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ThirdPersonCharacterTemplate.Scripts.Interactables
{
    public class ConstructionBehavior : MonoBehaviour
    {
        public event Action Updated;

        public List<ConstructionDesign> Designs = new();

        [SerializeField] private Inventory _inventory;

        public bool CanBuild(ConstructionDesign design) =>
            design
                .Materials
                .All(x => _inventory.Contains(x));

        public void Build(ConstructionDesign recipe)
        {
            var building = Instantiate(
                recipe.Target,
                transform.position + transform.forward + Vector3.up,
                Quaternion.identity);

            foreach (Item ingredient in recipe.Materials)
                _inventory.Remove(ingredient);

            Updated?.Invoke();
        }
    }
}