using CrashKonijn.Goap.Behaviours;
using CrashKonijn.Goap.Classes;
using CrashKonijn.Goap.Interfaces;
using GOAP.Config;

namespace GOAP
{
    public class DependencyInjector : GoapConfigInitializerBase, IGoapInjector
    {
        public FleeConfigSO fleeConfig;
        public WanderConfigSO wanderConfig;
        public BioSignsSO bioSigns;

        public override void InitConfig(GoapConfig config)
        {
            config.GoapInjector = this;
        }

        public void Inject(IActionBase action)
        {
            if (action is IInjectable injectable)
            {
                injectable.Inject(this);
            }
        }

        public void Inject(IGoalBase goal)
        {
            if (goal is IInjectable injectable)
            {
                injectable.Inject(this);
            }
        }

        public void Inject(IWorldSensor worldSensor)
        {
            if (worldSensor is IInjectable injectable)
            {
                injectable.Inject(this);
            }
        }

        public void Inject(ITargetSensor targetSensor)
        {
            if (targetSensor is IInjectable injectable)
            {
                injectable.Inject(this);
            }
        }
    }
}