using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController Instance { get; private set; }
    public int gameMode;

    #region MouseMovement

    Vector3 touchStart;
    public float zoomOutMin = 1;
    public float zoomOutMax = 10;
    public float zoomSpeed;
    #endregion

    private bool drag = false;

    public Camera MyCamera { get; private set; }
    public float CurrentZoom
    {
        get => currentZoom;
        private set
        {
            currentZoom = value;
            UpdateCameraTarget();
        }
    }

    [Range(2, 20), Tooltip("Speed in which the camera is moved")]
    public float MovementSpeed = 15f;

    [Range(2, 20), Tooltip("Speed in which the camera zooms")]
    public float ZoomSpeed = 2f;

    [Tooltip("This is the Y offset of our focal point. 0 Means we're looking at the ground.")]
    public float LookOffset;

    [Tooltip("The angle that we want the camera to be at.")]
    public float CameraAngle;

    [Tooltip("The default amount the player is zoomed into the game world.")]
    public float DefaultZoom;

    [Range(10f, 20), Tooltip("The most a player can zoom in to the game world.")]
    public float ZoomMax;

    [Range(.5f, 5), Tooltip("The furthest point a player can zoom back from the game world.")]
    public float ZoomMin;

    private const float ZoomAmount = 0.5f;
    private Vector3 moveTargetPosition;
    private Vector3 zoomTargetPosition;
    private float currentZoom;

    public float clampXMin, clampXMax, clampYMin, clampYMax, clampZMin, clampZMax;


    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        if (gameMode == 0)
        {



            //Set the target position to the current location.
            moveTargetPosition = transform.position;

            //Get a reference to the child camera 
            MyCamera = transform.GetComponentInChildren<Camera>();

            //Set the rotation of the child camera based on property specified in Inspector
            MyCamera.transform.rotation = Quaternion.AngleAxis(CameraAngle, Vector3.right);

            CurrentZoom = DefaultZoom;
            //MyCamera.transform.position = zoomTargetPosition;
        }
    }

    private void Update()
    {
        if (gameMode == 0)
        {


            //Smoothly move the camera
            transform.position = Vector3.Lerp(transform.position, moveTargetPosition, Time.deltaTime * MovementSpeed);

            //Smoothly zoom the camera
            MyCamera.transform.localPosition = Vector3.Lerp(MyCamera.transform.localPosition, zoomTargetPosition, Time.deltaTime * ZoomSpeed);
        }

        if (gameMode == 1)
        {


            if (Input.GetMouseButtonDown(0))
            {
                touchStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
            if (Input.touchCount == 2)
            {
                Touch touchZero = Input.GetTouch(0);
                Touch touchOne = Input.GetTouch(1);

                Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
                Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

                float prevMagnitude = (touchZeroPrevPos - touchOnePrevPos).magnitude;
                float currentMagnitude = (touchZero.position - touchOne.position).magnitude;

                float difference = currentMagnitude - prevMagnitude;

                zoom(difference * 0.01f);
            }
            else if (Input.GetMouseButton(0))
            {
                Vector3 direction = touchStart - Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Camera.main.transform.position += direction;

                Vector3 clampedPosition = Camera.main.transform.position;

                clampedPosition.x = Mathf.Clamp(clampedPosition.x, clampXMin, clampXMax);
                clampedPosition.y = Mathf.Clamp(clampedPosition.y, clampYMin, clampYMax);
                clampedPosition.z = Mathf.Clamp(clampedPosition.z, clampZMin, clampZMax);
                Camera.main.transform.position = clampedPosition;
            }
            zoom(Input.GetAxis("Mouse ScrollWheel") * zoomSpeed);
        }
    }

    /// <summary>
    /// Calculates a new position based on various properties
    /// </summary>
    private void UpdateCameraTarget()
    {
        if (gameMode == 0)
        zoomTargetPosition = (Vector3.up * LookOffset) + (Quaternion.AngleAxis(CameraAngle, Vector3.right) * Vector3.back) * currentZoom;
    }

    /// <summary>
    /// Moves the camera rig to a new position
    /// </summary>
    /// <param name="newPosition">Position that the camera should be moving towards</param>
    public void Move(Vector3 newPosition)
    {
        if (gameMode == 0)

            moveTargetPosition = transform.position + newPosition;
    }

    /// <summary>
    /// Manages the zoom level of the actual camera in increments of half a meter.
    /// </summary>
    /// <param name="zoomOut">Whether the camera should zoom out or in</param>
    public void Zoom(bool zoomOut)
    {

        if (gameMode == 0)
        CurrentZoom = Mathf.Clamp(currentZoom + (zoomOut ? ZoomAmount : -ZoomAmount), ZoomMin, ZoomMax);

    }

    void zoom(float increment)
    {
        if (gameMode == 1)
        {
            Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - increment, zoomOutMin, zoomOutMax);
        }
    }

    public void SetGameMode()
    {
        if (gameMode == 0)
        {
            gameMode = 1;
        }
        else if (gameMode == 1)
        {
            gameMode = 0;
        }
    }
        
}

