using System.Linq;
using CrashKonijn.Goap.Classes;
using CrashKonijn.Goap.Interfaces;
using CrashKonijn.Goap.Sensors;
using GOAP.Config;
using UnityEngine;

namespace GOAP.Sensors
{
    public class MilkTargetSensor : LocalTargetSensorBase, IInjectable
    {
        private BioSignsSO bioSigns;
        private Collider[] colliders = new Collider[5];

        public override void Created() {}

        public override void Update() {}

        public override ITarget Sense(IMonoAgent agent, IComponentReference references)
        {
            Vector3 agentPosition = agent.transform.position;
            int hits = Physics.OverlapSphereNonAlloc(agentPosition, bioSigns.milkSearchRadius, colliders, bioSigns.milkLayer);


            if (hits == 0)
            {
                return null;
            }

            for (int i = colliders.Length - 1; i > hits; i--)
            {
                colliders[i] = null;
            }

            colliders = colliders.OrderBy(collider =>
                collider == null ?
                    float.MaxValue
                    : (collider.transform.position - agent.transform.position).sqrMagnitude
            ).ToArray();

            return new PositionTarget(colliders[0].transform.position);
        }

        public void Inject(DependencyInjector injector)
        {
            bioSigns = injector.bioSigns;
        }
    }
}