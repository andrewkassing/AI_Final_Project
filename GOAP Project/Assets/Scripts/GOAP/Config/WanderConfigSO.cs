using UnityEngine;

namespace GOAP.Config
{
    [CreateAssetMenu(menuName = "AI/Wander Config", fileName = "WanderConfig", order = 2)]
    public class WanderConfigSO : ScriptableObject
    {
        public Vector2 waitRangeBetweenWanders = new(1,5);
        public float wanderRadius = 5f;
    }
}