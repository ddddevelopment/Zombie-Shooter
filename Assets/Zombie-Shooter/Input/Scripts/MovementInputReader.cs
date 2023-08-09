using UnityEngine;

class MovementInputReader : IInputReader
{
    private IMoveable _moveable;
    private Transform _characterTransform;

    public MovementInputReader(IMoveable moveable, Transform characterTransform)
    {
        _moveable = moveable;
        _characterTransform = characterTransform;
    }

    public void ReadInput()
    {
        Vector3 direction = Input.GetAxisRaw("Horizontal") * _characterTransform.right + Input.GetAxisRaw("Vertical") * _characterTransform.forward;
        _moveable.Move(direction.normalized);
    }
}

