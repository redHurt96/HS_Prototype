using UnityEngine;
using UnityEngine.Assertions;

namespace Prototype.Logic.Extensions
{
    public static class ArrayExtensions
    {
        public static T GetRandom<T>(this T[] array)
        {
            Assert.IsNotNull(array);

            return array[Random.Range(0, array.Length)];
        }
    }
}