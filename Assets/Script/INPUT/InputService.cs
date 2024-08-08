
public interface IInputService
{
    InputSignal Read();
    void Write(InputSignal InputSignal);
}
public class InputService : IInputService
{
    private readonly IInputData _InputData;
    public InputService(IInputData InputData)
    {
        _InputData = InputData;
    }
    public InputSignal Read()
    {
        return _InputData.Read();
    }
    public void Write(InputSignal InputSignal)
    {
        _InputData.Write(InputSignal);
    }
}