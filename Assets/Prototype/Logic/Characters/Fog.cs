using UnityEngine;

namespace Prototype.Logic.Characters
{
    public class Fog : MonoBehaviour
    {
        [SerializeField] private float _damage;
        
        private Mind _mind;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Mind mind))
                _mind = mind;
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out Mind _))
                _mind = null;
        }

        private void OnDisable() => 
            _mind = null;

        private void Update()
        {
            if (_mind != null)
                _mind.TakeDamage(_damage * Time.deltaTime);
        }
    }
}