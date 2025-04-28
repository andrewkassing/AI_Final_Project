using CrashKonijn.Goap.Classes;
using CrashKonijn.Goap.Interfaces;
using CrashKonijn.Goap.Sensors;
using GOAP.Config;
using UnityEngine;

namespace GOAP.Sensors
{
    public class PlayerTargetSensor : LocalTargetSensorBase, IInjectable
    {
        private FleeConfigSO fleeConfig;
        private Collider[] colliders = new Collider[1];

        public override void Created() {}

        public override void Update() {}

        public override ITarget Sense(IMonoAgent agent, IComponentReference references)
        {
            if (Physics.OverlapSphereNonAlloc(
                    agent.transform.position,
                    fleeConfig.sensorRadius,
                    colliders,
                    fleeConfig.scaredLayerMask) > 0
                && colliders[0].TryGetComponent(out Player player))
            {
                float distance = Vector3.Distance(agent.transform.position, player.transform.position);
                Vector3 fleeDir = (agent.transform.position - player.transform.position).normalized;
                Vector3 newPos = agent.transform.position + fleeDir * (fleeConfig.sensorRadius - distance);
                return new PositionTarget(newPos);
            }

            return null;
        }

        public void Inject(DependencyInjector injector)
        {
            fleeConfig = injector.fleeConfig;
        }
    }
}