using CrashKonijn.Goap.Interfaces;
using CrashKonijn.Goap.Behaviours;
using UnityEngine;
using CrashKonijn.Goap.Enums;
using CrashKonijn.Goap.Classes;

namespace GOAP.Actions
{
    public class HasFledAction : ActionBase<CommonData>
    {
        public override void Created() {}

        public override void Start(IMonoAgent agent, CommonData data) {}

        public override ActionRunState Perform(IMonoAgent agent, CommonData data, ActionContext context)
        {
            return ActionRunState.Stop;
        }

        public override void End(IMonoAgent agent, CommonData data) {}
    }
}