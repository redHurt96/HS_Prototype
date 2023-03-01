using System.Collections;
using ThirdPersonCharacterTemplate.Scripts;
using UnityEngine;

namespace Prototype.Logic.Characters
{
    public class RespawnOnDeadAction : MonoBehaviour
    {
        [SerializeField] private ThirdPersonController _controller;
        [SerializeField] private Health _health;
        [SerializeField] private Hunger _hunger;

        private void Start() => 
            _health.OnDead += Respawn;

        private void OnDestroy() => 
            _health.OnDead -= Respawn;

        private void Respawn() =>
            StartCoroutine(RespawnRoutine());

        private IEnumerator RespawnRoutine()
        {
            _health.Reset();
            _hunger.Reset();

            _controller.enabled = false;

            yield return null;

            transform.position = Vector3.zero;

            yield return null;

            _controller.enabled = true;
        }
    }
}