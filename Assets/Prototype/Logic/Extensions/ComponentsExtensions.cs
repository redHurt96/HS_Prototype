using UnityEngine;

namespace Prototype.Logic.Extensions
{
    public static class ComponentsExtensions
    {
        public static bool HasComponent<T>(this GameObject target) where T : Component => 
            target.GetComponent<T>() != null;
        
        public static bool HasComponent<T>(this Component target) where T : Component => 
            target.GetComponent<T>() != null;
    }
}
