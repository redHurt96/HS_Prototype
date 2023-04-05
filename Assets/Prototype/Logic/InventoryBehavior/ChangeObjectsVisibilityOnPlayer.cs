using EasyBuildSystem.Examples.Bases.Scripts.FirstPerson;
using Prototype.Logic.Extensions;
using UnityEngine;

namespace Prototype.Logic.InventoryBehavior
{
    public class ChangeObjectsVisibilityOnPlayer : MonoBehaviour
    {
        [SerializeField] private GameObject[] _toActivate;
        [SerializeField] private GameObject[] _toDeactivate;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.HasComponent<Demo_FirstPersonController>())
                return;

            foreach (GameObject o in _toActivate)
                o.SetActive(true);
            
            foreach (GameObject o in _toDeactivate)
                o.SetActive(false);
        }
    }
}