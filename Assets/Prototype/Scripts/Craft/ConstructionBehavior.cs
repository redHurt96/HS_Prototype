﻿using System;
using System.Collections.Generic;
using System.Linq;
using Prototype.Scripts.Interactables;
using Prototype.Scripts.InventoryBehavior;
using UnityEngine;
using static UnityEngine.GameObject;
using static UnityEngine.Quaternion;

namespace Prototype.Scripts.Craft
{
    public class ConstructionBehavior : MonoBehaviour
    {
        public event Action Updated;

        public List<ConstructionDesign> Designs = new();

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
            Instantiate(
                recipe.Target,
                transform.position + transform.forward,
                identity,
                _buildingsParent);

            foreach (Item ingredient in recipe.Materials)
                _inventory.Remove(ingredient);

            Updated?.Invoke();
        }
    }
}