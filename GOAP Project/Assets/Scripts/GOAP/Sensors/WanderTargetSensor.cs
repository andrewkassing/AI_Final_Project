using CrashKonijn.Goap.Classes;
using CrashKonijn.Goap.Interfaces;
using CrashKonijn.Goap.Sensors;
using GOAP.Config;
using UnityEngine;
using UnityEngine.AI;

namespace GOAP.Sensors
{
    public class WanderTargetSensor : LocalTargetSensorBase, IInjectable
    {
        private WanderConfigSO wanderConfig;

        public override void Created() {}
        
        public override void Update() {}

        public override ITarget Sense(IMonoAgent agent, IComponentReference references)
        {
            Vector3 position = GetRandomPosition(agent);
            
            return new PositionTarget(position);
        }

        private Vector3 GetRandomPosition(IMonoAgent agent)
        {
            int count = 0;
            while (count < 5)
            {
                Vector2 random = Random.insideUnitCircle * wanderConfig.wanderRadius;
                Vector3 position = agent.transform.position + new Vector3(random.x, 0, random.y);

                if (NavMesh.SamplePosition(position, out NavMeshHit hit, 1, NavMesh.AllAreas)) // AllAreas bc only 1 type of agent rn
                {
                    return hit.position;
                }

                count++;
            }

            return agent.transform.position;
        }

        public void Inject(DependencyInjector injector)
        {
            wanderConfig = injector.wanderConfig;
        }
    }
}