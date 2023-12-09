using Evengy.GridBasedMovementController.Navigation;
using UnityEngine;

namespace Evengy.GridBasedMovementController.Player
{
    public partial class PlayerController : MonoBehaviour
    {
        public PlayerController ResetOverrides()
        {
            smoothTransition = defaultTransition;
            movementSpeed = defaultMovementSpeed;
            return this;
        }
        public PlayerController OverrideTransition(bool isSmooth)
        {
            smoothTransition = isSmooth;
            return this;
        }

        public PlayerController OverrideMovementSpeed(float speedOverride)
        {
            movementSpeed = speedOverride;
            return this;
        }

        public PlayerController OverrideTargetTile(TileController tileOverride)
        {
            targetTile = tileOverride;
            return this;
        }
    }
}