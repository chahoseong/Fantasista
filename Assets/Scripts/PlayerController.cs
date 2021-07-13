using Fantasista.Character.Systems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fantasista.Character.Controls
{
    public class PlayerController : MonoBehaviour
    {
        private CharacterMovement characterMovement;

        private void Start()
        {
            var pawn = transform.GetChild(0);
            Possess(pawn.gameObject);
        }

        private void Update()
        {
            if (Input.GetMouseButton(0))
            {
                var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if(Physics.Raycast(ray, out var hit))
                    characterMovement.MoveTo(hit.point);
            }
        }

        public void Possess(GameObject character)
        {
            characterMovement = character.GetComponent<CharacterMovement>();
        }
    }
}