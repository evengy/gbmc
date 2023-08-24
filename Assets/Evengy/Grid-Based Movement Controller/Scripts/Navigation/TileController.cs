using Evengy.GridBasedMovementController.Helpers;
using UnityEngine;

namespace Evengy.GridBasedMovementController.Navigation
{
    public class TileController : MonoBehaviour
    {
        [SerializeField] TriggerOnTag forwardTrigger;
        [SerializeField] TriggerOnTag backTrigger;
        [SerializeField] TriggerOnTag leftTrigger;
        [SerializeField] TriggerOnTag rightTrigger;

        public TileController GetTile(Direction direction)
        {
            switch (direction)
            {
                case Direction.Left: return LeftTile;
                case Direction.Right: return RightTile;
                case Direction.Back: return BackTile;

                default: return ForwardTile;
            }
        }

        TileController ForwardTile => forwardTrigger.IsTriggered ? forwardTrigger.TriggerObject.GetComponent<TileController>() : this;
        TileController BackTile => backTrigger.IsTriggered ? backTrigger.TriggerObject.GetComponent<TileController>() : this;
        TileController LeftTile => leftTrigger.IsTriggered ? leftTrigger.TriggerObject.GetComponent<TileController>() : this;
        TileController RightTile => rightTrigger.IsTriggered ? rightTrigger.TriggerObject.GetComponent<TileController>() : this;
    }
}