using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TouchManager : MonoBehaviour
{
    private PlayerInput input;

    private InputAction touchPosition;
    private InputAction touchPress;

    private Camera mainCamera;
    private void Awake()
    {
        input = GetComponent<PlayerInput>();
        touchPress = input.actions["Place"];
        touchPosition = input.actions["TouchPosition"];
        mainCamera = Camera.main;

    }

    //Detects if touch is pressed down
    private void OnEnable()
    {
        touchPress.performed += TouchPressed;
    }

    //Detects when touch is released
    private void OnDisable()
    {
        touchPress.performed -= TouchPressed;
    }

    //Raycast to detect touch location
    private void DetectObject()
    {
        Ray ray = mainCamera.ScreenPointToRay(touchPosition.ReadValue<Vector2>());
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.tag != ("Untouchable"))
            {
                ITap tap = hit.collider.GetComponent<ITap>();
                if (tap != null)
                {
                    tap.onTapAction();
                }
                Debug.Log("Hit: " + hit.collider.tag);
            }
        }
    }

    //What to do when touch is pressed
    private void TouchPressed(InputAction.CallbackContext context)
    {
        DetectObject();
    }
}
