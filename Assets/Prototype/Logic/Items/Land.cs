using UnityEngine;

namespace Prototype.Logic.Items
{
    public class Land : MonoBehaviour
    {
        public Transform Origin;
        public Transform[] Edges;

        [ContextMenu("Check")]
        private void Check()
        {
            foreach (Transform edge in Edges)
            {
                Debug.Log(Vector3.Distance(edge.position, Origin.position), edge);
            }
        }
    }
}