using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class CharacterMovementToPlayer : MonoBehaviour, IMoveable
{
    private NavMeshAgent _agent;

    public void Initialize()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    public void Move(Vector3 playerPosition)
    {
        _agent.destination = playerPosition;
    }
}
