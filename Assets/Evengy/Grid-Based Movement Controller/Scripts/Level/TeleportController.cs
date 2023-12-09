using Evengy.GridBasedMovementController.Helpers;
using Evengy.GridBasedMovementController.Navigation;
using Evengy.GridBasedMovementController.Player;
using UnityEngine;

namespace Evengy.GridBasedMovementController.Level
{
    [RequireComponent(typeof(TriggerOnTag))]
    public class TeleportController : MonoBehaviour
    {
        [SerializeField] TileController teleportTo;
        [SerializeField] KeyCode beginTeleportation = KeyCode.Space;
        [SerializeField] bool instant;

        bool isReady;
        PlayerController player;
        TriggerOnTag playerTrigger;

        private void Start()
        {
            playerTrigger = GetComponent<TriggerOnTag>();
        }

        void Update()
        {
            if (playerTrigger.IsTriggered) ProcessTeleportation();
        }

        private void ProcessTeleportation()
        {
            if (!isReady && Input.GetKeyDown(beginTeleportation))
            {
                player = playerTrigger.TriggerObject.GetComponent<PlayerController>();
                player.OverrideTransition(!instant).OverrideTargetTile(teleportTo);
                isReady = true;
            }
            if (isReady && !player.IsBusy)
            {
                _ = player.ResetOverrides();
                isReady = false;
            }
        }
    }
}