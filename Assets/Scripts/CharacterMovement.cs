using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Fantasista.Character.Systems
{
    public class CharacterMovement : MonoBehaviour
    {
        private Animator animator;
        private NavMeshAgent agent;

        private static class AnimatorParameters
        {
            public static readonly int Speed = Animator.StringToHash("Speed");
        }

        private void Awake()
        {
            animator = GetComponent<Animator>();
            agent = GetComponent<NavMeshAgent>();
        }

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
            if (agent.pathPending)
                return;

            var speed = agent.desiredVelocity.magnitude;
            animator.SetFloat(AnimatorParameters.Speed, speed, 0.175f, Time.deltaTime);
        }

        public void MoveTo(Vector3 destination)
        {
            agent.destination = destination;
        }
    }
}