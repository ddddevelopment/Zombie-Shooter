using UnityEngine;

public class JumpInputReader : IInputReader
{
    private IJumper _jumper;
    private KeyCode _jumpKey;

    public JumpInputReader(IJumper jumper, KeyCode jumpKey)
    {
        _jumper = jumper;
        _jumpKey = jumpKey;
    }

    public void ReadInput()
    {
        if (Input.GetKeyDown(_jumpKey))
        {
            _jumper.Jump();
        }
    }
}

