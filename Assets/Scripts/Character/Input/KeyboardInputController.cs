using UnityEngine;
using UnityInput = UnityEngine.Input;

namespace Homepath.Character.Input
{
    public class KeyboardInputController : MonoBehaviour, IInputController
    {
        [SerializeField]
        private LayerMask floorMask;
        
        public Vector3 MovementPoint { get; private set; }

        private Camera mainCamera;

        private void Awake()
        {
            mainCamera = Camera.main;
        }

        private void Update()
        {
            if (UnityInput.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                Ray mouseRay = mainCamera.ScreenPointToRay(UnityInput.mousePosition);
                if (Physics.Raycast(mouseRay, out hit, 10.0f, floorMask))
                {
                    MovementPoint = hit.point;
                }
            }
        }
    }

}