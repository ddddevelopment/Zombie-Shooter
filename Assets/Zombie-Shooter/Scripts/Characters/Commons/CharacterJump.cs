using System.Collections.Generic;
using UnityEngine;

public class CharacterJump : IJumper, IFixedTick
{
	private const float GRAVITY = -12f;

	private int _jumpForce;
	private Transform _groundCheckerPoint;
	private LayerMask _groundMask;

	private CharacterController _characterController;
	private float _velocityY;

	public CharacterJump(CharacterController characterController, int jumpForce, Transform groundCheckerPoint, LayerMask groundMask, List<IFixedTick> fixedTickers)
	{
		_characterController = characterController;
		_jumpForce = jumpForce;
		_groundCheckerPoint = groundCheckerPoint;
		_groundMask = groundMask;
		fixedTickers.Add(this);
	}

	public void FixedTick() => DoGravity();

	public void Jump()
	{
		if (IsOnGround()) _velocityY = Mathf.Sqrt(_jumpForce * -2 * GRAVITY);
	}

	private void DoGravity()
	{
		_velocityY += GRAVITY * Time.fixedDeltaTime;
		_characterController.Move(Vector3.up * _velocityY * Time.fixedDeltaTime);
	}

	private bool IsOnGround() => Physics.CheckSphere(_groundCheckerPoint.position, 0.4f, _groundMask);
}
