using CrashKonijn.Goap.Behaviours;
using UnityEngine;

namespace GOAP.Behaviors
{
    [RequireComponent(typeof(AgentBehaviour))]
    public class AgentTypeBinder : MonoBehaviour
    {
        [SerializeField] private GoapRunnerBehaviour goapRunner;

        private void Awake()
        {
            AgentBehaviour agent = GetComponent<AgentBehaviour>();
            agent.GoapSet = goapRunner.GetGoapSet("CatSet");
        }
    }
}