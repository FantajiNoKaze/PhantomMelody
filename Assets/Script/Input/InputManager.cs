
using UnityEngine;
using Zenject;

public class InputManager : MonoBehaviour
{
    private readonly IInputData _InputData;
    private InputSignal _Input;

    [Inject]
    public InputManager(IInputData InputData)
    {
        _InputData = InputData;
    }
    void Start()
    {
        Debug.Log("ssss");
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            _Input &= InputSignal.GetKeyDown_Up;
        }
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            _Input &= InputSignal.GetKeyUp_Up;
        }
    }

    void FixedUpdate()
    {
        _InputData.Write(_Input);
        _Input = InputSignal.None;
    }
}