using System;
using CrashKonijn.Goap.Behaviours;
using CrashKonijn.Goap.Classes;
using CrashKonijn.Goap.Classes.Builders;
using CrashKonijn.Goap.Configs.Interfaces;
using CrashKonijn.Goap.Enums;
using CrashKonijn.Goap.Resolver;
using GOAP;
using GOAP.Actions;
using GOAP.Keys;
using GOAP.Sensors;
using UnityEngine;

namespace GOAP.Factories
{
    [RequireComponent(typeof(DependencyInjector))]
    public class GoapSetConfigFactory : GoapSetFactoryBase
    {
        private DependencyInjector injector;

        public override IGoapSetConfig Create()
        {
            injector = GetComponent<DependencyInjector>();
            GoapSetBuilder builder = new ("CatSet");

            BuildGoals(builder);
            BuildActions(builder);
            BuildSensors(builder);

            return builder.Build();
        }

        private void BuildGoals(GoapSetBuilder builder)
        {
            builder.AddGoal<WanderGoal>()
                .AddCondition<IsWandering>(Comparison.GreaterThanOrEqual, 1);
            
            builder.AddGoal<DrinkGoal>()
                .AddCondition<Thirst>(Comparison.SmallerThanOrEqual, 0);

            builder.AddGoal<SleepGoal>()
                .AddCondition<Sleepiness>(Comparison.SmallerThanOrEqual, 0);

            builder.AddGoal<FleeFromPlayer>()
                .AddCondition<IsSafe>(Comparison.GreaterThanOrEqual, 1);
        }

        private void BuildActions(GoapSetBuilder builder)
        {
            builder.AddAction<WanderAction>()
                .SetTarget<WanderTarget>()
                .AddEffect<IsWandering>(EffectType.Increase)
                .SetBaseCost(5)
                .SetInRange(5);
            
            builder.AddAction<DrinkAction>()
                .SetTarget<MilkTarget>()
                .AddEffect<Thirst>(EffectType.Decrease)
                .SetBaseCost(8)
                .SetInRange(.1f);

            builder.AddAction<SleepAction>()
                .SetTarget<BedTarget>()
                .AddCondition<Thirst>(Comparison.SmallerThan, Mathf.FloorToInt(injector.bioSigns.acceptableThirstLimit))
                .AddEffect<Sleepiness>(EffectType.Decrease)
                .SetBaseCost(4)
                .SetInRange(.1f);
            
            builder.AddAction<HasFledAction>()
                .SetTarget<PlayerTarget>()
                .AddEffect<IsSafe>(EffectType.Increase)
                .SetBaseCost(injector.fleeConfig.fleeCost);
        }

        private void BuildSensors(GoapSetBuilder builder)
        {
            builder.AddTargetSensor<WanderTargetSensor>()
                .SetTarget<WanderTarget>();

            builder.AddTargetSensor<MilkTargetSensor>()
                .SetTarget<MilkTarget>();

            builder.AddTargetSensor<PlayerTargetSensor>()
                .SetTarget<PlayerTarget>();
            
            builder.AddTargetSensor<BedTargetSensor>()
                .SetTarget<BedTarget>();
            
            builder.AddWorldSensor<ThirstSensor>()
                .SetKey<Thirst>();
            
            builder.AddWorldSensor<PlayerDistanceSensor>()
                .SetKey<PlayerDistance>();

            builder.AddWorldSensor<SleepinessSensor>()
                .SetKey<Sleepiness>();
        }
    }
}
