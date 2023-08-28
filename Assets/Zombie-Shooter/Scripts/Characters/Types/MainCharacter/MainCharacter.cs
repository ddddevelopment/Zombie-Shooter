using UnityEngine;

public class MainCharacter : DefaultCharacter
{
    [SerializeField] private int _jumpForce;
    [SerializeField] private Transform _groundCheckerPoint;
    [SerializeField] private LayerMask _groundMask;

    private IWeapon _weapon;

	public override IMovement Movement { get; protected set; }
    public CharacterAttack Attack { get; private set; }
    public CharacterJump Jump { get; private set; }
    public CharacterRotation Rotation { get; private set; }

	public override void Initialize()
    {
        base.Initialize();
        Attack = new CharacterAttack(_weapon);
        Movement = new CharacterMovementControlled(CharacterController, FixedTickers);
        Jump = new CharacterJump(CharacterController, _jumpForce, _groundCheckerPoint, _groundMask, FixedTickers);
        Rotation = new CharacterRotation(transform);
    }
}