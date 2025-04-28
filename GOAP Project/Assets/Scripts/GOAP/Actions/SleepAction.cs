using CrashKonijn.Goap.Behaviours;
using CrashKonijn.Goap.Classes;
using CrashKonijn.Goap.Classes.References;
using CrashKonijn.Goap.Enums;
using CrashKonijn.Goap.Interfaces;
using GOAP.Behaviors;
using GOAP.Config;
using UnityEngine;

namespace GOAP.Actions
{
    public class SleepAction : ActionBase<SleepAction.Data>, IInjectable
    {
        private BioSignsSO bioSigns;
        private static readonly int SIT = Animator.StringToHash("Sit");

        public override void Created() {}

        public override void Start(IMonoAgent agent, Data data)
        {
            data.Sleep.enabled = false; // Disable Sleep behavior
            data.Timer = 1f;
        }

        public override ActionRunState Perform(IMonoAgent agent, Data data, ActionContext context)
        {
            data.Timer -= context.DeltaTime;
            data.Sleep.Sleep -= context.DeltaTime * bioSigns.sleepinessRestorationRate;
            data.animator.SetBool(SIT, true);
            if (data.Target == null || data.Sleep.Sleep <= 0)
            {
                return ActionRunState.Stop;
            }

            return ActionRunState.Continue;
        }

        public override void End(IMonoAgent agent, Data data)
        {
            data.animator.SetBool(SIT, false);
            data.Sleep.enabled = true; // Re-enable Sleep behavior
        }

        public void Inject(DependencyInjector injector)
        {
            bioSigns = injector.bioSigns;
        }

        public class Data : CommonData
        {
            [GetComponent]
            public SleepBehavior Sleep { get; set; }

            [GetComponent]
            public Animator animator { get; set; }
        }
    }

    
}