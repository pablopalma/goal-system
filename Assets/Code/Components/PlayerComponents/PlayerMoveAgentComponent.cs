using UnityEngine;
using UnityEngine.AI;

namespace Assets.Code.Components.PlayerComponents
{
    public class PlayerMoveAgentComponent : MonoBehaviour
    {
        private NavMeshAgent _agent;
        private Animator _animator;

        // Variables para detectar clics y movimiento
        [SerializeField] private LayerMask clickableLayer;
        [SerializeField] private float navMeshSampleDistance = 1.0f;
        [SerializeField] private float rotationSpeed = 5.0f; // Velocidad de rotación del jugador

        private void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();
            _animator = GetComponent<Animator>();

            // Desactivar la rotación automática del agente
            _agent.updateRotation = false;
        }

        private void Update()
        {
            // Detectar clic del ratón
            if (Input.GetMouseButtonDown(0)) // Click izquierdo del mouse
            {
                HandleMouseClick();
            }

            // Actualizar el Animator según el estado del agente
            if (_agent.velocity.magnitude > 0.1f)
            {
                _animator.SetBool("Walk", true);

                // Rotar hacia la dirección del movimiento
                RotateTowardsMovementDirection();
            }
            else
            {
                _animator.SetBool("Walk", false);
            }
        }

        private void HandleMouseClick()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, clickableLayer))
            {
                // Intenta encontrar un punto en el NavMesh cercano a donde hicimos clic
                if (NavMesh.SamplePosition(hit.point, out NavMeshHit navMeshHit, navMeshSampleDistance, NavMesh.AllAreas))
                {
                    // Mueve al jugador al punto válido en el NavMesh
                    _agent.SetDestination(navMeshHit.position);
                }
            }
        }

        private void RotateTowardsMovementDirection()
        {
            // Solo rotar si el jugador está en movimiento
            if (_agent.velocity.sqrMagnitude > Mathf.Epsilon)
            {
                // Obtén la dirección del movimiento
                Vector3 direction = _agent.velocity.normalized;

                // Calcula la rotación hacia la dirección del movimiento
                Quaternion targetRotation = Quaternion.LookRotation(direction);

                // Suaviza la rotación
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            }
        }
    }
}
