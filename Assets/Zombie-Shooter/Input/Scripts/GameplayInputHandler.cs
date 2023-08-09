using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterMovementControlled), typeof(CharacterJump), typeof(CharacterAttack)), RequireComponent(typeof(CharacterRotation))]
public class GameplayInputHandler : MonoBehaviour
{
    [SerializeField] private KeyCode _jumpKey = KeyCode.Space;
    [SerializeField] private float _mouseSensitivity = 100;

    private List<IInputReader> _inputReaders = new List<IInputReader>();

    private IMoveable _playerMovement;
    private IJumper _playerJump;
    private IAttacker _playerAttack;
    private IRotatable _playerRotation;

    public void Initialize()
    {
        _playerMovement = GetComponent<CharacterMovementControlled>();
        _playerJump = GetComponent<CharacterJump>();
        _playerAttack = GetComponent<CharacterAttack>();
        _playerRotation = GetComponent<IRotatable>();

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
