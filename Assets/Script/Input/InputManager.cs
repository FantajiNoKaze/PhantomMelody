
using UnityEngine;
using VContainer.Unity;

public class InputManager : ITickable, IFixedTickable
{
    private readonly IInputService _InputController;
    private InputSignal _Input;
    public InputManager(IInputService InputController)
    {
        _InputController = InputController;
    }
    void ITickable.Tick()
    {
        if (Input.GetKey(KeyCode.W))
        {
            _Input = InputSignal.GetKeyDown_Up;
        }       
    }
    void IFixedTickable.FixedTick()
    {
        _InputController.Write(_Input);
        _Input = InputSignal.None;
    }
}

