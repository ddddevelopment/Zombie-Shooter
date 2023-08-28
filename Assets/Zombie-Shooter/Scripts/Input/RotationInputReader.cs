using UnityEngine;

public class RotationInputReader : IInputReader
{
    private float _mouseSensitivity;
    private float _rotationX, _rotationY;

    private IRotatable _characterRotatable;
    private Transform _cameraTransform;

    public RotationInputReader(float mouseSensitivity, IRotatable characterRotatable)
    {
        _mouseSensitivity = mouseSensitivity;
        _characterRotatable = characterRotatable;
        _cameraTransform = Camera.main.transform;
    }

    public void ReadInput()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * _mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxisRaw("Mouse Y") * _mouseSensitivity * Time.deltaTime;

        _rotationY += mouseX;
        _rotationX -= mouseY;
        _rotationX = Mathf.Clamp(_rotationX, -90, 90);

        _characterRotatable.Rotate(Quaternion.Euler(0, _rotationY, 0));
        _cameraTransform.localRotation = Quaternion.Euler(_rotationX, 0, 0);
    }
}
