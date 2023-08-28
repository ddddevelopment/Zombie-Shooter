using UnityEngine;

class MovementInputReader : IInputReader
{
    private IMovement _movement;
    private Transform _characterTransform;

    public MovementInputReader(IMovement movement, Transform characterTransform)
    {
        _movement = movement;
        _characterTransform = characterTransform;
    }

    public void ReadInput()
    {
        Vector3 direction = Input.GetAxisRaw("Horizontal") * _characterTransform.right + Input.GetAxisRaw("Vertical") * _characterTransform.forward;
        _movement.Move(direction.normalized);
    }
}

