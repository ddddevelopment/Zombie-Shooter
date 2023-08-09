using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterMovementControlled : MonoBehaviour, IMoveable
{
    [SerializeField] private float _moveSpeed = 5;
    
    private CharacterController _characterController;
    private Vector3 _moveDirection;

    private void FixedUpdate()
    {
        MoveInternal();
    }

    public void Initialize()
    {
        _characterController = GetComponent<CharacterController>();
    }

    public void Move(Vector3 direction)
    {
        _moveDirection = direction;
    }

    private void MoveInternal()
    {
        _characterController.Move(_moveDirection * _moveSpeed * Time.fixedDeltaTime);
    }
}