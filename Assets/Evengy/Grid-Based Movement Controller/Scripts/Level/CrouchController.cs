using Evengy.GridBasedMovementController.Helpers;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Evengy.GridBasedMovementController.Level
{
    public class CrouchController : MonoBehaviour
    {
        [SerializeField] float descension;
        [SerializeField] KeyCode crouch = KeyCode.C;
        
        Vector3 defaultPosition;

        private void Start()
        {
            defaultPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        }

        private void Update()
        {
            if (Input.GetKey(crouch)) { Descent(descension); }
            else { Descent(0); }
        }

        private void Descent(float descension) =>
            transform.position = new Vector3(defaultPosition.x, defaultPosition.y - descension, defaultPosition.z);
    }
}