using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TouchManager : MonoBehaviour
{
    private PlayerInput input;

    private InputAction touchPosition;
    private InputAction touchPress;
    private void Awake()
    {
        input = GetComponent<PlayerInput>();
        touchPress = input.actions["Place"];
        touchPosition = input.actions["TouchPosition"];

    }

    private void OnEnable()
    {
        touchPress.performed += TouchPressed;
    }

    private void OnDisable()
    {
        touchPress.performed -= TouchPressed;
    }

    private void TouchPressed(InputAction.CallbackContext context)
    {
        float value = context.ReadValue<float>();
        Debug.Log(value);

        context.ReadValueAsObject();
    }
}
