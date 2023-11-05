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

    public float clampXMin, clampXMax, clampYMin, clampYMax, clampZMin, clampZMax;
    public float baseZoomOutMin = 1;
    public float baseZoomOutMax = 10;
    private float currentZoomLevel;
    private void Update()
    {
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

                zoom(difference * zoomSpeed);
            }
            else if (Input.GetMouseButton(0))
            {
                Vector3 direction = touchStart - Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Camera.main.transform.position += direction;

                Vector3 clampedPosition = Camera.main.transform.position;

                //clampedPosition.x = Mathf.Clamp(clampedPosition.x, clampXMin, clampXMax);
                //clampedPosition.y = Mathf.Clamp(clampedPosition.y, clampYMin, clampYMax);
                //clampedPosition.z = Mathf.Clamp(clampedPosition.z, clampZMin, clampZMax);
                //Camera.main.transform.position = clampedPosition;
            }
            ClampCamera();
            zoom(Input.GetAxis("Mouse ScrollWheel") * zoomSpeed);
        }
    }

    void zoom(float increment)
    {
        if (gameMode == 1)
        {
            Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - increment, zoomOutMin, zoomOutMax);
           // currentZoomLevel = Mathf.Clamp(Camera.main.orthographicSize, baseZoomOutMin, baseZoomOutMax);
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

    private void ClampCamera()
    {
        Vector3 clampMovement = transform.position;
        float CamSize = Camera.main.orthographicSize;
        float aspect = Camera.main.aspect;


        clampMovement.x = Mathf.Clamp(clampMovement.x, clampXMin + CamSize * aspect, clampXMax - CamSize * aspect);
        clampMovement.y = Mathf.Clamp(clampMovement.y, clampYMin + CamSize, clampYMax - CamSize);
        float halfCamSize = CamSize / 2.0f;
        clampMovement.z = Mathf.Clamp(clampMovement.z, clampZMin + halfCamSize, clampZMax - halfCamSize);


        transform.position = clampMovement;
    }
}

