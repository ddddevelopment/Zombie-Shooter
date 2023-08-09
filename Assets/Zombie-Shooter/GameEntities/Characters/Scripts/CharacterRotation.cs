using UnityEngine;

public class CharacterRotation : MonoBehaviour, IRotatable
{
    public void Rotate(Quaternion rotation)
    {
        transform.rotation = rotation;
    }
}