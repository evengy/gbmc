using Evengy.GridBasedMovementController.Helpers;
using UnityEngine;

namespace Evengy.GridBasedMovementController.Level
{
    public class HiddenPathController : MonoBehaviour
    {
        [SerializeField] float maxElevation;
        [SerializeField] KeyCode revealPath = KeyCode.Space;
        [SerializeField] GameObject revealTileModel;

        TriggerOnTag playerTrigger;

        Vector3 defaultRevealColliderPosition;
        BoxCollider revealCollider;

        void Start()
        {
            playerTrigger = GetComponent<TriggerOnTag>();
            revealCollider = GetComponent<BoxCollider>();
            defaultRevealColliderPosition = new Vector3(revealCollider.center.x, revealCollider.center.y, revealCollider.center.z);
        }

        void Update()
        {
            if (!playerTrigger.IsTriggered) return;

            if (Input.GetKeyDown(revealPath) && !revealTileModel.activeSelf)
            {
                revealTileModel.SetActive(true);
                revealCollider.center = new Vector3(defaultRevealColliderPosition.x, defaultRevealColliderPosition.y + maxElevation, defaultRevealColliderPosition.z);
            }
            else if (Input.GetKeyDown(revealPath) && revealTileModel.activeSelf)
            {
                revealTileModel.SetActive(false);
                revealCollider.center = new Vector3(defaultRevealColliderPosition.x, defaultRevealColliderPosition.y, defaultRevealColliderPosition.z);
            }
        }
    }
}