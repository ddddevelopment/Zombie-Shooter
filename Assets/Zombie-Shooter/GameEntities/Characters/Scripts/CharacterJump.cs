using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterJump : MonoBehaviour, IJumper
{
    private const float GRAVITY = -12f;

    [SerializeField] private int _jumpForce = 3;
    [SerializeField] private Transform _groundCheckerPoint;
    [SerializeField] private LayerMask _groundMask;

    private CharacterController _characterController;
    private float _velocityY;

    private void FixedUpdate()
    {
        DoGravity();
    }

    public void Initialize()
    {
        _characterController = GetComponent<CharacterController>();
    }

    public void Jump()
    {
        if (IsOnGround()) _velocityY = Mathf.Sqrt(_jumpForce * -2 * GRAVITY);
    }

    private void DoGravity()
    {
        _velocityY += GRAVITY * Time.fixedDeltaTime;
        _characterController.Move(Vector3.up * _velocityY * Time.fixedDeltaTime);
    }

    private bool IsOnGround()
    {
        return Physics.CheckSphere(_groundCheckerPoint.position, 0.4f, _groundMask);
    }
}
