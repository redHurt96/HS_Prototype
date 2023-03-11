using Prototype.Logic.Characters;
using UnityEngine;

namespace Prototype.Logic.InventoryBehavior
{
    public class HealthRestorer : MonoBehaviour
    {
        [SerializeField] private Health _health;
        [SerializeField] private Hunger _hunger;
        [SerializeField] private float _treshold;
        [SerializeField] private float _restorePerSec;

        private void Update()
        {
            if (_hunger.Current > _treshold)
                _health.Add(_restorePerSec * Time.deltaTime);
        }
    }
}