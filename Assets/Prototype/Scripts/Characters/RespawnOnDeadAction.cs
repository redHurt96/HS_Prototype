using UnityEngine;

namespace Prototype.Scripts.Character
{
    public class RespawnOnDeadAction : MonoBehaviour
    {
        [SerializeField] private Health _health;

        private void Start() => 
            _health.OnDead += Respawn;

        private void OnDestroy() => 
            _health.OnDead -= Respawn;

        private void Respawn() => 
            transform.position = Vector3.zero;
    }
}