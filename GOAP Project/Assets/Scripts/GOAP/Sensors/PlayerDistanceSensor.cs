using CrashKonijn.Goap.Classes;
using CrashKonijn.Goap.Interfaces;
using CrashKonijn.Goap.Sensors;
using GOAP.Config;
using UnityEngine;

namespace GOAP.Sensors
{
    public class PlayerDistanceSensor : LocalWorldSensorBase, IInjectable
    {
        private FleeConfigSO fleeConfig;
        private Collider[] colliders = new Collider[1];

        public override void Created() {}

        public override void Update() {}

        public override SenseValue Sense(IMonoAgent agent, IComponentReference references)
        {
            if (Physics.OverlapSphereNonAlloc(
                    agent.transform.position,
                    fleeConfig.sensorRadius,
                    colliders,
                    fleeConfig.scaredLayerMask) > 0
                && colliders[0].TryGetComponent(out Player player))
            {
                return new SenseValue(Mathf.CeilToInt(Vector3.Distance(agent.transform.position, player.transform.position)));
            }

            return new SenseValue(int.MaxValue);
        }

        public void Inject(DependencyInjector injector)
        {
            fleeConfig = injector.fleeConfig;
        }
    }
}