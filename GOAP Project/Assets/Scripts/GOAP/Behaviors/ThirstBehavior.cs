using CrashKonijn.Goap.Behaviours;
using GOAP.Config;
using UnityEngine;

namespace GOAP.Behaviors
{
    public class ThirstBehavior : MonoBehaviour
    {
        [field: SerializeField] public float Thirst { get; set; }
        [SerializeField] private BioSignsSO bioSigns;

        private void Awake()
        {
            Thirst = Random.Range(0, bioSigns.maxThirst);
        }

        private void Update()
        {
            Thirst += Time.deltaTime * bioSigns.thirstDepletionRate;
        }
    }
}