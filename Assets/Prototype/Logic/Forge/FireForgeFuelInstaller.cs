using UnityEngine;

namespace Prototype.Logic.Forge
{
    public class FireForgeFuelInstaller : MonoBehaviour
    {
        [SerializeField] private Forge _forge;

        private void Start() => 
            _forge
                .PutFuel(new() { Count = 1000000, ItemName = "wood"});
    }
}