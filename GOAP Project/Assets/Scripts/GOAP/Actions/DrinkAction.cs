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
    public class DrinkAction : ActionBase<DrinkAction.Data>, IInjectable
    {
        private BioSignsSO bioSigns;
        private static readonly int SIT = Animator.StringToHash("Sit");

        public override void Created() {}

        public override void Start(IMonoAgent agent, Data data)
        {
            data.Timer = 1f;
        }

        public override ActionRunState Perform(IMonoAgent agent, Data data, ActionContext context)
        {
            if (data.Thirst.enabled)
                data.Thirst.enabled = false; // Disable Thirst behavior

            data.Timer -= context.DeltaTime;
            data.Thirst.Thirst -= context.DeltaTime * bioSigns.thirstRestorationRate;
            data.animator.SetBool(SIT, true);
            if (data.Target == null || data.Thirst.Thirst <= 0)
            {
                return ActionRunState.Stop;
            }

            return ActionRunState.Continue;
        }

        public override void End(IMonoAgent agent, Data data)
        {
            data.animator.SetBool(SIT, false);
            data.Thirst.enabled = true; // Re-enable Thirst behavior
        }

        public void Inject(DependencyInjector injector)
        {
            bioSigns = injector.bioSigns;
        }

        public class Data : CommonData
        {
            [GetComponent]
            public ThirstBehavior Thirst { get; set; }

            [GetComponent]
            public Animator animator { get; set; }
        }
    }

    
}