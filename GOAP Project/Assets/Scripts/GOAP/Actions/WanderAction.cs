using CrashKonijn.Goap.Interfaces;
using CrashKonijn.Goap.Behaviours;
using UnityEngine;
using CrashKonijn.Goap.Enums;
using CrashKonijn.Goap.Classes;
using GOAP.Config;

namespace GOAP.Actions
{
    public class WanderAction : ActionBase<CommonData>, IInjectable
    {
        private WanderConfigSO wanderConfig;

        public override void Created() {}

        public override void Start(IMonoAgent agent, CommonData data)
        {
            data.Timer = Random.Range(wanderConfig.waitRangeBetweenWanders.x, wanderConfig.waitRangeBetweenWanders.y);
        }

        public override ActionRunState Perform(IMonoAgent agent, CommonData data, ActionContext context)
        {
            data.Timer -= context.DeltaTime;
            
            if (data.Timer > 0)
            {
                return ActionRunState.Continue;
            }
            return ActionRunState.Stop;
        }

        public override void End(IMonoAgent agent, CommonData data) {}

        public void Inject(DependencyInjector injector)
        {
            wanderConfig = injector.wanderConfig;
        }
    }
}