using System;

[Flags]
public enum InputSignal
{
    None = 0,
    GetKeyDown_Up = 1,
    GetKeyDown_Dowm = 2,
    GetKeyDown_Left = 4,
    GetKeyDown_Right = 8,
    GetKeyUp_Up = 16,
    GetKeyUp_Down = 32,
    GetKeyUp_Left = 64,
    GetKeyUp_Right = 128
}


public interface IInputData
{
    InputSignal Read();
    void Write(InputSignal InputSignal);
}
public class InputData : IInputData
{
    private InputSignal _InputSignal =0;

    public InputSignal Read()
    {
        return _InputSignal;
    }
    public void Write(InputSignal InputSignal)
    {
        _InputSignal = InputSignal;
    }

}