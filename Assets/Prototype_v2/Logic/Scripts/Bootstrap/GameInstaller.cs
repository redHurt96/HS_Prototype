using Prototype_v2.Logic.Melee;
using UnityEngine;
using Zenject;

namespace Prototype_v2.Logic.Bootstrap
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private MeleeConfig _meleeConfig;
        
        public override void InstallBindings()
        {
            Container.Bind<MeleeConfig>().FromInstance(_meleeConfig).AsSingle();
        }
    }
}
