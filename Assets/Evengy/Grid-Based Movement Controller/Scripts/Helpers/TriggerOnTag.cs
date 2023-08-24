using UnityEngine;

namespace Evengy.GridBasedMovementController.Helpers
{
    public class TriggerOnTag : MonoBehaviour
    {
        [SerializeField] private Tag triggerTag;
        public bool IsTriggered => isTriggered;
        public GameObject TriggerObject { get; private set; }

        bool isTriggered;

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag.Equals(triggerTag.ToString()))
            {
                TriggerObject = other.gameObject;
                isTriggered = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.tag.Equals(triggerTag.ToString()))
            {
                TriggerObject = null;
                isTriggered = false;
            }
        }
    }
}