using CrashKonijn.Goap.Behaviours;
using CrashKonijn.Goap.Interfaces;
using UnityEngine;
using UnityEngine.AI;

namespace GOAP.Behaviors
{
    [RequireComponent(typeof(NavMeshAgent), typeof(AgentBehaviour), typeof(Animator))]
    public class AgentMoveBehavior : MonoBehaviour
    {
        private NavMeshAgent navMeshAgent;
        private AgentBehaviour agentBehaviour;
        private Animator animator;
        private ITarget currentTarget;
        [SerializeField] private float minMoveDistance = 0.25f;
        private static readonly int WALK = Animator.StringToHash("Walk");

        private Vector3 lastPosition;

        private void Awake()
        {
            navMeshAgent = GetComponent<NavMeshAgent>();
            animator = GetComponent<Animator>();
            agentBehaviour = GetComponent<AgentBehaviour>();
        }

        private void OnEnable()
        {
            agentBehaviour.Events.OnTargetChanged += EventsOnTargetChanged;
            agentBehaviour.Events.OnTargetOutOfRange += EventsOnTargetOutOfRange;
        }

        private void OnDisable()
        {
            agentBehaviour.Events.OnTargetChanged -= EventsOnTargetChanged;
            agentBehaviour.Events.OnTargetOutOfRange -= EventsOnTargetOutOfRange;
        }

        private void EventsOnTargetChanged(ITarget target, bool inRange)
        {
            currentTarget = target;
            lastPosition = currentTarget.Position;
            navMeshAgent.SetDestination(target.Position);
            animator.SetBool(WALK, true);
        }

        private void EventsOnTargetOutOfRange(ITarget target)
        {
            animator.SetBool(WALK, false);
        }

        private void Update()
        {
            if (currentTarget == null)
            {
                return;
            }
            
            if (minMoveDistance <= Vector3.Distance(currentTarget.Position, lastPosition))
            {
                lastPosition = currentTarget.Position;
                navMeshAgent.SetDestination(currentTarget.Position);
            }
            
            animator.SetBool(WALK, navMeshAgent.velocity.magnitude > 0.1f); // Walk only if moving
        }
    }
}