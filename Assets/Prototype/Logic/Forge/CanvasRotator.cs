using UnityEngine;
using static UnityEngine.Camera;

namespace Prototype.Logic.Forge
{
    public class CanvasRotator : MonoBehaviour
    {
        private static Camera _camera;
        
        [SerializeField] private Canvas _canvas;

        private void Start()
        {
            _camera ??= main;
            _canvas.worldCamera = _camera;
        }

        private void Update() => 
            transform.LookAt(_camera.transform.position);
    }
}