using UnityEngine;

namespace Prototype.Logic.Forge
{
    public class CanvasRotator : MonoBehaviour
    {
        [SerializeField] private Canvas _canvas;
        
        private Camera _camera;

        private void Start() => 
            _camera ??= Camera.main;

        private void Update() => 
            transform.LookAt(-_camera.transform.position);
    }
}