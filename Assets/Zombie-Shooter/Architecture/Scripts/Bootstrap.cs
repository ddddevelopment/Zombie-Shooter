using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private CharacterHealth _mainCharacterHealth;
    [SerializeField] private CharacterMovementControlled _mainCharacterMovement;
    [SerializeField] private CharacterJump _mainCharacterJump;
    [SerializeField] private CharacterRotation _mainCharacterRotation;
    [SerializeField] private CharacterAttack _mainCharacterAttack;
    [SerializeField] private GameplayInputHandler _input;

    private void Awake()
    {
        _mainCharacterHealth.Initialize();
        _mainCharacterMovement.Initialize();
        _mainCharacterJump.Initialize();
        _input.Initialize();
    }
}
