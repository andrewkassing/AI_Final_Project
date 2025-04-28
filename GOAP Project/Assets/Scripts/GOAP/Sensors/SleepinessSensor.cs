using CrashKonijn.Goap.Classes;
using CrashKonijn.Goap.Interfaces;
using CrashKonijn.Goap.Sensors;
using GOAP.Behaviors;
using UnityEngine;

namespace GOAP.Sensors
{
    public class SleepinessSensor : LocalWorldSensorBase
    {
        public override void Created() {}

        public override void Update() {}

        public override SenseValue Sense(IMonoAgent agent, IComponentReference references)
        {
            return new SenseValue(Mathf.CeilToInt(references.GetCachedComponent<SleepBehavior>().Sleep));
        }
    }
}