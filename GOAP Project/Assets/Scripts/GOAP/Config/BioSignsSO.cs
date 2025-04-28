using UnityEngine;

namespace GOAP.Config
{
    [CreateAssetMenu(menuName = "AI/BioSigns Config", fileName = "BioSignsConfig", order = 3)]
    public class BioSignsSO : ScriptableObject
    {
        public float milkSearchRadius = 20f;
        public LayerMask milkLayer;
        public float thirstRestorationRate = 1f;
        public float thirstDepletionRate = 0.25f;
        public float maxThirst = 20;
        public float acceptableThirstLimit = 10;

        public float bedSearchRadius = 20f;
        public LayerMask bedLayer;
        public float sleepinessRestorationRate = 1f;
        public float sleepinessDepletionRate = 0.25f;
        public float maxSleepiness = 20;
        public float acceptableSleepinessLimit = 10;
    }
}