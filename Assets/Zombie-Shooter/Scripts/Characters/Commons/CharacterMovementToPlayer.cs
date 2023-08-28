using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterMovementToPlayer : IMovement, ITick
{
    private NavMeshAgent _agent;
    private Transform _player;

    public CharacterMovementToPlayer(NavMeshAgent agent, Transform player, List<ITick> tickers)
    {
        _agent = agent;
        _player = player;
        tickers.Add(this);
    }

    public void Move(Vector3 playerPosition)
    {
        _agent.destination = playerPosition;
    }

    public void Tick()
    {
        Move(new Vector3(_player.position.x, 0, _player.position.z));
    }
}
