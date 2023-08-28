using UnityEngine;

public class BootstrapGameplay : MonoBehaviour
{
    [SerializeField] private MainCharacter _mainCharacter;
    [SerializeField] private Enemy _enemy;
	[SerializeField] private GameplayInputHandler _inputHandler;

	private void Awake()
	{
		_mainCharacter.Initialize();
		_enemy.Initialize();
		_inputHandler.Initialize();
	}
}
