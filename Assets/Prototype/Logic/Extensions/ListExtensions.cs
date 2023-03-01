using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace Prototype.Logic.Extensions
{
    public static class ListExtensions
    {
        public static T GetRandom<T>(this List<T> list)
        {
            Assert.IsNotNull(list);

            return list[Random.Range(0, list.Count)];
        }
    }
}