using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Fantasista.CharacterSystem
{
    public class CharacterMovement : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private NavMeshAgent agent;

        private static readonly int ForwardSpeed = Animator.StringToHash("ForwardSpeed");

        private void Start()
        {
            agent.updatePosition = false;
        }

        private void OnAnimatorMove()
        {
            transform.position = agent.nextPosition;
        }

        private void Update()
        {
            if (Input.GetMouseButton(0))
            {
                var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out var hit))
                {
                    MoveTo(hit.point);
                }
            }

            if (agent.pathPending)
                return;

            if (agent.remainingDistance <= 1.0f)
            {
                //Debug.Log($"Remaining Distance: {agent.remainingDistance}");
            }

            var speed = agent.desiredVelocity.magnitude;
            animator.SetFloat(ForwardSpeed, speed, 0.175f, Time.deltaTime);
        }

        public void MoveTo(Vector3 destination)
        {
            agent.destination = destination;
        }
    }
}