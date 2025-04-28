using CrashKonijn.Goap.Behaviours;
using GOAP.Config;
using UnityEngine;

namespace GOAP.Behaviors
{
    public class SleepBehavior : MonoBehaviour
    {
        [field: SerializeField] public float Sleep { get; set; }
        [SerializeField] private BioSignsSO bioSigns;

        private void Awake()
        {
            Sleep = Random.Range(0, bioSigns.maxSleepiness);
        }

        private void Update()
        {
            Sleep += Time.deltaTime * bioSigns.sleepinessDepletionRate;
        }
    }
}