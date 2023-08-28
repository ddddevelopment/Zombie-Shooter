using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MainCharacter))]
public class GameplayInputHandler : MonoBehaviour
{
    [SerializeField] private KeyCode _jumpKey = KeyCode.Space;
    [SerializeField] private float _mouseSensitivity = 100;

    private MainCharacter _player;
    private List<IInputReader> _inputReaders = new List<IInputReader>();
    private IMovement _playerMovement;
    private IJumper _playerJump;
    private IAttacker _playerAttack;
    private IRotatable _playerRotation;

    public void Initialize()
    {
        _player = GetComponent<MainCharacter>();

        _playerMovement = _player.Movement;
        _playerJump = _player.Jump;
        _playerAttack = _player.Attack;
        _playerRotation = _player.Rotation;

        _inputReaders.Add(new MovementInputReader(_playerMovement, transform));
        _inputReaders.Add(new JumpInputReader(_playerJump, _jumpKey));
        _inputReaders.Add(new AttackInputReader(_playerAttack));
        _inputReaders.Add(new RotationInputReader(_mouseSensitivity, _playerRotation));
    }

    private void Update()
    {
        for (int i = 0;  i < _inputReaders.Count; i++)
        {
            _inputReaders[i].ReadInput();
        }
    }
}
