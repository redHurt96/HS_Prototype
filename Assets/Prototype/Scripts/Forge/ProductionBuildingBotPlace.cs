using System.Collections;
using Prototype.Scripts.Attributes;
using UnityEngine;
using static UnityEngine.Application;

namespace Prototype.Scripts.Forge
{
    public class ProductionBuildingBotPlace : MonoBehaviour
    {
        public bool IsEmpty => _bot == null;
        
        [SerializeField] private Transform _botPlace;
        [SerializeField] private float _clickDelay;

        [SerializeField, ReadOnly] private GameObject _bot;

        private IProductionBuilding _productionBuilding;

        private IEnumerator Start()
        {
            _productionBuilding = GetComponent<IProductionBuilding>();
            
            yield return new WaitUntil(() => _bot != null);

            while (isPlaying)
            {
                yield return new WaitForSeconds(_clickDelay);
                
                if (_productionBuilding.CanCraft() && _bot != null)
                    _productionBuilding.PerformCraft();
            }
        }

        public void SetBot(GameObject bot)
        {
            _bot = bot;
            _bot.transform.position = _botPlace.position + Vector3.up * .9f;
        }
    }
}