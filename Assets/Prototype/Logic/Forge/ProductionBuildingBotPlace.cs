using System.Collections;
using Prototype.Logic.Attributes;
using Prototype.Logic.Characters;
using Prototype.Logic.Craft;
using UnityEngine;
using static UnityEngine.Application;
using static UnityEngine.Vector3;

namespace Prototype.Logic.Forge
{
    public class ProductionBuildingBotPlace : MonoBehaviour
    {
        public bool IsEmpty => _bot == null;
        
        [SerializeField] private Transform _botPlace;
        [SerializeField] private float _clickDelay;

        [SerializeField, ReadOnly] private Bot _bot;

        private IProductionBuilding _productionBuilding;

        private IEnumerator Start()
        {
            _productionBuilding = GetComponent<IProductionBuilding>();
            
            yield return new WaitUntil(() => _bot != null);

            while (isPlaying)
            {
                yield return new WaitForSeconds(_clickDelay);
                
                if (_productionBuilding.CanCraft() && _bot != null && _bot.GetComponent<Health>().Current > 0f)
                    _productionBuilding.PerformCraft();
            }
        }

        public void SetBot(Bot bot)
        {
            _bot = bot;
            _bot.transform.position = _botPlace.position + up * .9f;
            _bot.BuildingKey = GetComponent<Building>().UniqueKey;
        }
    }
}