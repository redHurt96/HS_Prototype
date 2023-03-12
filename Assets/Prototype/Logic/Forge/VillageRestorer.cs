using System.Collections;
using System.Linq;
using Prototype.Logic.Craft;
using Prototype.Logic.InventoryBehavior;
using Prototype.Logic.Items;
using Unity.Mathematics;
using UnityEngine;
using static Prototype.Logic.Forge.WorldData;
using static Prototype.Logic.Interactables.ResourcesService;
using static UnityEngine.Resources;

namespace Prototype.Logic.Forge
{
    public class VillageRestorer : MonoBehaviour
    {
        [SerializeField] private LandExpander _landExpander;
        [SerializeField] private Village _village;
        [SerializeField] private BotHuntingBehavior _huntingBehavior;
        
        private IEnumerator Start()
        {
            if (!WorldDataHandler.Instance.HasData)
                yield break;

            yield return new WaitUntil(() => _landExpander.Loaded);

            foreach (BuildingData buildingData in WorldDataHandler.Instance.Data.Buildings)
            {
                Building instance = Instantiate(
                    GetBuildingPrefab(buildingData.Name),
                    buildingData.Position,
                    quaternion.identity,
                    _village.BuildingsParent);

                instance.UniqueKey = buildingData.UniqueKey;

                _village.Register(instance);

                if (buildingData.InventoryData != null)
                {
                    instance
                        .GetComponent<Inventory>()
                        .Set(buildingData.InventoryData);
                }
            }
            
            foreach (BotData botData in WorldDataHandler.Instance.Data.Bots)
            {
                Bot bot = Instantiate(Load<Bot>("Bot"), _village.BotsParent);
                bot.Name = botData.Name;

                _huntingBehavior.Hunt(bot);
                
                if (!string.IsNullOrEmpty(botData.BuildingKey))
                    _village.Buildings
                        .First(x => x.UniqueKey == botData.BuildingKey)
                        .GetComponent<ProductionBuildingBotPlace>()
                        .SetBot(bot);
            }
        }
    }
}