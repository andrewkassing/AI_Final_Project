using System;
using CrashKonijn.Goap.Behaviours;
using GOAP.Config;
using GOAP.Keys;
using Sensors;
using UnityEngine;

namespace GOAP.Behaviors
{
    [RequireComponent(typeof(AgentBehaviour))]
    public class CatBrain : MonoBehaviour
    {
        [SerializeField] private ThirstBehavior thirst;
        [SerializeField] private SleepBehavior sleep;
        [SerializeField] private BioSignsSO bioSigns;
        [SerializeField] private PlayerSensor playerSensor;

        private AgentBehaviour agentBehavior;
        private bool playerIsInRange;

        private void Awake()
        {
            agentBehavior = GetComponent<AgentBehaviour>();
        }

        private void Start()
        {
            agentBehavior.SetGoal<WanderGoal>(false);
        }

        private void OnEnable()
        {
            playerSensor.OnPlayerEnter += PlayerSensorOnPlayerEnter;
            playerSensor.OnPlayerExit += PlayerSensorOnPlayerExit;
        }

        private void OnDisable()
        {
            playerSensor.OnPlayerEnter -= PlayerSensorOnPlayerEnter;
            playerSensor.OnPlayerExit -= PlayerSensorOnPlayerExit;
        }

        private void Update()
        {
            SetGoal();
        }

        private void SetGoal()
        {
            if (playerIsInRange)
            {
                agentBehavior.SetGoal<FleeFromPlayer>(true);
            }
            else if (thirst.Thirst > bioSigns.maxThirst)
            {
                agentBehavior.SetGoal<DrinkGoal>(true);
            }
            else if ((sleep.Sleep > bioSigns.maxSleepiness && agentBehavior.CurrentGoal is DrinkGoal && thirst.Thirst <= bioSigns.acceptableThirstLimit)
                || sleep.Sleep > bioSigns.maxSleepiness && agentBehavior.CurrentGoal is WanderGoal)
            {
                agentBehavior.SetGoal<SleepGoal>(true);
            }
            else if ((thirst.Thirst <= 0 && agentBehavior.CurrentGoal is DrinkGoal)
                || (sleep.Sleep <= 0 && agentBehavior.CurrentGoal is SleepGoal))
            {
                agentBehavior.SetGoal<WanderGoal>(false);
            }
        }

        private void PlayerSensorOnPlayerEnter(Transform player)
        {
            playerIsInRange = true;
        }

        private void PlayerSensorOnPlayerExit(Vector3 lastKnownPosition)
        {
            playerIsInRange = false;

            if (thirst.Thirst <= bioSigns.maxThirst)
            {
                agentBehavior.SetGoal<WanderGoal>(false);
            }
        }
    }
}