using UnityEngine;

public class AttackInputReader : IInputReader
{
    private IAttacker _attacker;

    public AttackInputReader(IAttacker attacker)
    {
        _attacker = attacker;
    }

    public void ReadInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _attacker.Attack();
        }
    }
}

