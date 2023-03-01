using UnityEngine;

namespace Prototype.Logic.Characters
{
    public class DestroyOnDeadAction : MonoBehaviour
    {
        [SerializeField] private Health _health;

        private void Start() => 
            _health.OnDead += Destroy;

        private void OnDestroy() => 
            _health.OnDead -= Destroy;

        private void Destroy() =>
            Destroy(gameObject);
    }
}