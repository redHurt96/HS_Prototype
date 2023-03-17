using System.Linq;
using UnityEngine;
using static Prototype.Logic.Items.LandSettings;
using static UnityEngine.Mathf;
using static UnityEngine.Physics;
using static UnityEngine.Vector3;

namespace Prototype.Logic.Items
{
    public static class IslandUtilities
    {
        public static float GetOpposite(float origin) =>
            origin switch
            {
                0f => 180f,
                60f => 240f,
                120f => 300f,
                180f => 0f,
                240f => 60f,
                300f => 120f,
                _ => throw new($"Trying to find opposite from wrong direction - {origin}")
            };

        public static Vector3 GetIslandPoint(Vector3 islandOrigin, float direction) =>
            islandOrigin
            + IslandWidth * new Vector3(
                Cos(Deg2Rad * direction), 
                0f,
                Sin(Deg2Rad * direction));

        public static bool HasIslandAtPoint(Vector3 point, out Island island)
        {
            island = null;

            Collider[] colliders = OverlapSphere(point, 1f);
            
            if (colliders.Length == 0)
                return false;
            
            island = colliders
                .FirstOrDefault(x => x.CompareTag("IslandMesh"))
                ?.GetComponentInParent<Island>();

            return island != null;
        }

        public static bool HasIslandBelowPoint(Vector3 point, out Island island, out Vector3 topPoint)
        {
            island = null;
            topPoint = zero;

            RaycastHit[] colliders = RaycastAll(point + up * 50f, down, 200f);

            if (colliders.Length == 0)
                return false;

            island = colliders
                .First()
                .transform
                .GetComponentInParent<Island>();

            topPoint = colliders
                .OrderByDescending(x => x.point.y)
                .First()
                .point;

            return island != null;
        }
    }
}