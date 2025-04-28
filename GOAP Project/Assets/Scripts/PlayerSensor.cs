using GOAP;
using UnityEngine;

namespace Sensors
{
    [RequireComponent(typeof(SphereCollider))]
    public class PlayerSensor : MonoBehaviour, IInjectable
    {
        public SphereCollider sphereCollider;
        public delegate void PlayerEnterEvent(Transform player);
        public delegate void PlayerExitEvent(Vector3 lastKnownPosition);

        public event PlayerEnterEvent OnPlayerEnter;
        public event PlayerExitEvent OnPlayerExit;

        private void Awake()
        {
            sphereCollider = GetComponent<SphereCollider>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Player player))
            {
                OnPlayerEnter?.Invoke(player.transform);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out Player player))
            {
                OnPlayerExit?.Invoke(other.transform.position);
            }
        }

        public void Inject(DependencyInjector injector)
        {
            sphereCollider.radius = injector.fleeConfig.sensorRadius;
        }
    }
}