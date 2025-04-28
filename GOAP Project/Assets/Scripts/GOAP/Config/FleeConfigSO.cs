using UnityEngine;

namespace GOAP.Config
{
    [CreateAssetMenu(menuName = "AI/Flee Config", fileName = "FleeConfig", order = 1)]
    public class FleeConfigSO : ScriptableObject
    {
        public float sensorRadius = 4f;
        public LayerMask scaredLayerMask;
        public int fleeCost = 1;
    }
}