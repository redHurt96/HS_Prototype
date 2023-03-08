using System.Collections.Generic;
using System.Linq;
using Prototype.Logic.Construction;
using UnityEngine;

namespace Prototype.Logic.Items
{
    [CreateAssetMenu(menuName = "Create ConstructionDesignsStorage", fileName = "ConstructionDesignsStorage", order = 0)]
    public class ConstructionDesignsStorage : SingletonScriptableObject<ConstructionDesignsStorage>
    {
        [SerializeField] private List<ConstructionDesign> _designs = new();

        public static IEnumerable<string> AllDesigns =>
            Instance
                ._designs
                .Select(x => x.Name);

        public static ConstructionDesign Get(string itemName) =>
            Instance
                ._designs
                .First(x => x.Name == itemName);
    }
}