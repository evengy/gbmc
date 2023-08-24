using Evengy.GridBasedMovementController.Navigation;
using UnityEngine;

namespace Evengy.GridBasedMovementController.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] bool smoothTransition = false;
        [SerializeField] float movementSpeed;
        [SerializeField] float rotationSpeed;
        [SerializeField] float precision;

        [SerializeField] TileController grid;
        TileController targetTile;

        Direction currentDirection;
        Vector3 targetRotation;

        public bool IsBusy => Vector3.Distance(transform.position, targetTile.transform.position) > precision
            || Vector3.Distance(transform.rotation.eulerAngles, targetRotation) > precision;

        private Direction LocalDirection(Direction direction)
            => (Direction)(((int)currentDirection + (int)direction) % (int)Direction.Round);

        private void Start()
        {
            currentDirection = Direction.Forward;
            targetTile = grid;
            targetRotation = Vector3.up * (int)currentDirection;
        }

        private void Update()
        {
            if (!IsBusy) return;
            Move();
            Rotate();
        }

        private void Move() => transform.position = smoothTransition ?
            Vector3.MoveTowards(transform.position, targetTile.transform.position, Time.deltaTime * movementSpeed)
            : targetTile.transform.position;

        private void Rotate() => transform.rotation = smoothTransition ?
            Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(targetRotation), Time.deltaTime * rotationSpeed)
            : Quaternion.Euler(targetRotation);

        public void MoveTowards(Direction direction) => targetTile = IsBusy ? targetTile : targetTile.GetTile(LocalDirection(direction));

        public void RotateTowards(Direction direction)
        {
            if (IsBusy) return;
            currentDirection = LocalDirection(direction);
            targetRotation = Vector3.up * (int)currentDirection;
        }
    }
}