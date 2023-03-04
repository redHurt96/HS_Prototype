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

        public static bool HasIslandBelowPoint(Vector3 point, out Island island)
        {
            island = null;

            RaycastHit[] colliders = RaycastAll(point + up, down, 20f);

            if (colliders.Length == 0)
                return false;

            island = colliders
                .FirstOrDefault(x => x.transform.CompareTag("IslandMesh"))
                .transform
                .GetComponentInParent<Island>();

            return island != null;
        }
    }
}