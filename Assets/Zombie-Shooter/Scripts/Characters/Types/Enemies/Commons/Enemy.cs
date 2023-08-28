using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : DefaultCharacter
{
	[SerializeField] private Transform _mainCharacterTransform;

	public CharacterAttack _attack;

	private IWeapon _weapon;
	private NavMeshAgent _agent;

	public override IMovement Movement { get; protected set; }

	public override void Initialize()
	{
		base.Initialize();
		_agent = GetComponent<NavMeshAgent>();
		_attack = new CharacterAttack(_weapon);
		Movement = new CharacterMovementToPlayer(_agent, _mainCharacterTransform, Tickers);
	}
}
