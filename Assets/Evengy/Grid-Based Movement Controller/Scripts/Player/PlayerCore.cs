using Evengy.GridBasedMovementController.Navigation;
using UnityEngine;

namespace Evengy.GridBasedMovementController.Player
{
    [RequireComponent(typeof(PlayerController))]
    public class PlayerCore : MonoBehaviour
    {
        [SerializeField] KeyCode moveForward = KeyCode.W;
        [SerializeField] KeyCode moveBack = KeyCode.S;
        [SerializeField] KeyCode moveLeft = KeyCode.A;
        [SerializeField] KeyCode moveRight = KeyCode.D;
        [SerializeField] KeyCode turnLeft = KeyCode.Q;
        [SerializeField] KeyCode turnRight = KeyCode.E;

        PlayerController controller;
        private void Start()
        {
            controller = GetComponent<PlayerController>();
        }
        private void Update()
        {
            if (Input.GetKeyDown(moveForward)) { controller.MoveTowards(Direction.Forward); }
            if (Input.GetKeyDown(moveBack)) { controller.MoveTowards(Direction.Back); }
            if (Input.GetKeyDown(moveLeft)) { controller.MoveTowards(Direction.Left); }
            if (Input.GetKeyDown(moveRight)) { controller.MoveTowards(Direction.Right); }
            if (Input.GetKeyDown(turnLeft)) { controller.RotateTowards(Direction.Left); }
            if (Input.GetKeyDown(turnRight)) { controller.RotateTowards(Direction.Right); }
        }
    }
}