using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class InputHandler : MonoBehaviour
{
    public static event Action<float> OnmoveAD;
    public static event Action<float> OnmoveJL;
    public static event Action<float> OnmoveUpDown;
    public static event Action<float> OnmoveHB;

    public float ADValue, JLValue, UpDownValue, HBValue;

    void Start()
    {
        
    }


    public void GetInputAD(InputAction.CallbackContext context)
    {
        ADValue=context.ReadValue<Vector2>().x;
    }

    public void GetInputJL(InputAction.CallbackContext context)
    {
        JLValue=context.ReadValue<Vector2>().x;
    }
    public void GetInputUpDown(InputAction.CallbackContext context)
    {
        UpDownValue=context.ReadValue<Vector2>().y;
    }

    public void GetInputHB(InputAction.CallbackContext context)
    {
        HBValue=context.ReadValue<Vector2>().y;
    }


    void Update()
    {
        
        OnmoveAD?.Invoke(ADValue);
        OnmoveJL?.Invoke(JLValue);
        OnmoveUpDown?.Invoke(UpDownValue);
        OnmoveHB?.Invoke(HBValue);
    }
}
