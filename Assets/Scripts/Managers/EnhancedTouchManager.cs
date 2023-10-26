using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using UnityEngine.InputSystem;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;
using TouchPhase = UnityEngine.InputSystem.TouchPhase;


public class EnhancedTouchManager : MonoBehaviour
{
    private PlayerInput input;
    public float touchSpeed = 10f;
    private float lastMultiTouchDistance;


    private void Awake()
    {
        EnhancedTouchSupport.Enable();
        input = GetComponent<PlayerInput>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Touch.activeFingers.Count == 1)
        {
            MoveCamera(Touch.activeTouches[0]);
        }
        else if (Touch.activeTouches.Count == 2)
        {
            ZoomCamera(Touch.activeTouches[0], Touch.activeTouches[1]);
        }
    }

    //Moves the camera when one finger is touching the screen and moving
    private void MoveCamera(Touch touch)
    {
        //Returns if finger is not actively moving
        if (touch.phase != TouchPhase.Moved)
        {
            return;
        }

        //Calculates new camera position
        Vector3 newPosition = new Vector3(-touch.delta.normalized.x, 0, -touch.delta.normalized.y) * Time.deltaTime * touchSpeed;

        
    }    

    private void ZoomCamera(Touch firstTouch, Touch secondTouch)
    {
        //Confirms if this is a first time a second finger has touched the screen
        if (firstTouch.phase == TouchPhase.Began || secondTouch.phase == TouchPhase.Began)
        {
            lastMultiTouchDistance = Vector2.Distance(firstTouch.screenPosition, secondTouch.screenPosition);
        }

        //Returns if both fingers are not actively moving
        if (firstTouch.phase != TouchPhase.Moved || secondTouch.phase != TouchPhase.Moved)
        {
            return;
        }

        //Checks if fingers are pinching together or apart
        float newMultiTouchDistance = Vector2.Distance(firstTouch.screenPosition, secondTouch.screenPosition);

        //Tells Zoom function if zooming in or out

        //Resets lastMultiTouchDistance
        lastMultiTouchDistance = newMultiTouchDistance;
    }
}
