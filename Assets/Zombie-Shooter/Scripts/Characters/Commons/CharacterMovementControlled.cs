using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CharacterMovementControlled : IMovement, IFixedTick
{
    [SerializeField] private float _moveSpeed = 5;
    
    private CharacterController _characterController;
    private Vector3 _moveDirection;

    public void FixedTick()
    {
        MoveInternal();
    }

    public CharacterMovementControlled(CharacterController characterController, List<IFixedTick> fixedTicks)
    {
        _characterController = characterController;
        fixedTicks.Add(this);
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