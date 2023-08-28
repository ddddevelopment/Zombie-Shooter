using UnityEngine;

public class CharacterRotation : IRotatable
{
    private Transform _transform;

    public CharacterRotation(Transform transform) 
    {
        _transform = transform;
    }

    public void Rotate(Quaternion rotation)
    {
        _transform.rotation = rotation;
    }
}