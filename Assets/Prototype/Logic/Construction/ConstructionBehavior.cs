using System;
using System.Collections.Generic;
using System.Linq;
using Prototype.Logic.Craft;
using Prototype.Logic.Forge;
using Prototype.Logic.InventoryBehavior;
using Prototype.Logic.Items;
using UnityEngine;
using static UnityEngine.GameObject;
using static UnityEngine.Quaternion;

namespace Prototype.Logic.Construction
{
    public class ConstructionBehavior : MonoBehaviour
    {
        public event Action Updated;

        public List<ConstructionDesign> Designs = new();

        [SerializeField] private Village _village;
        [SerializeField] private Inventory _inventory;
        
        private Transform _buildingsParent;

        private void Awake() => 
            _buildingsParent = FindGameObjectWithTag("BuildingsParent").transform;

        public bool CanBuild(ConstructionDesign design) =>
            design
                .Materials
                .All(x => _inventory.Contains(x));

        public void Build(ConstructionDesign recipe)
        {
            Building instance = Instantiate(
                recipe.Target,
                transform.position + transform.forward,
                identity,
                _buildingsParent);

            foreach (ItemCell ingredient in recipe.Materials)
                _inventory.Remove(ingredient);

            if (instance.Name is "storehouse" or "farm") 
                _village.RegisterStorehouse(instance.GetComponent<Inventory>());

            Updated?.Invoke();
        }
    }
}