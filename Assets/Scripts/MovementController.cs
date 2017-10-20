using UnityEngine;

namespace Homepath.Character
{
    [RequireComponent(typeof(IInputController))]
    public class MovementController : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField]
        [Range(0.0f, 30.0f)]
        private float movementSpeed;
    
        private IInputController inputController;

        #region Readonly settings

        private readonly float movementStopThreashold = 0.1f;

        #endregion
        
        private void Awake()
        {
            inputController = GetComponent<IInputController>();
        }

        private void Update()
        {
            Move();
        }

        private void Move()
        {
            if (Vector3.Distance(transform.position, inputController.MovementPoint) > movementStopThreashold)
            {
                transform.Translate((inputController.MovementPoint - transform.position).normalized * movementSpeed *
                                    Time.deltaTime);
            }
        }
    }
}
