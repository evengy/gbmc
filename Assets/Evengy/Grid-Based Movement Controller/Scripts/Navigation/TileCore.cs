using UnityEngine;
using Evengy.GridBasedMovementController.Helpers;

namespace Evengy.GridBasedMovementController.Navigation
{
    [RequireComponent(typeof(TileController))]
    public class TileCore : MonoBehaviour
    {
        [SerializeField] TriggerOnTag obstacleTrigger;

        BoxCollider tileCollider;
        Vector3 colliderDefaultSize;
        private void Start()
        {
            tileCollider = GetComponent<BoxCollider>();
            colliderDefaultSize = new Vector3(tileCollider.size.x, tileCollider.size.y, tileCollider.size.z);
        }
        private void Update()
        {
            if (obstacleTrigger.IsTriggered)
            {
                tileCollider.size = Vector3.zero;
            }
            else
            {
                tileCollider.size = colliderDefaultSize;
            }
        }
    }
}