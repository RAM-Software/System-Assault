using UnityEngine;

public class CameraTest : MonoBehaviour
{
    public int zoomSpeed = 1;
    public int zoomMax = 25;
    public int zoomMin = 50;

    public float tarVelocity;
    public GameObject target;
    public Vector3 offset;

    private Vector3 targetPos;

    private Camera _cam;

    void Start()
    {
        _cam = GetComponent<Camera>();
        targetPos = transform.position;
    }

    void FixedUpdate()
    {
        if (target)
        {
            Vector3 targetDirection = (target.transform.position - transform.position);
            tarVelocity = targetDirection.magnitude * 5f;
            targetPos = transform.position + (targetDirection.normalized * tarVelocity * Time.deltaTime);
            transform.position = Vector3.Lerp(transform.position, targetPos + offset, 0.25f);
        }

    }

    void LateUpdate()
    {
        ClampCamera();
        CheckZoom();

        Vector3 posNoZ = transform.position;
        posNoZ.z = -10;

        transform.position = posNoZ;


    }

    private void ClampCamera()
    {
        Vector3 clampMovement = transform.position;


        clampMovement.x = Mathf.Clamp(clampMovement.x, 8f, 112);
        clampMovement.y = Mathf.Clamp(clampMovement.y, 6.6f, 100);

        transform.position = clampMovement;
    }

    private void CheckZoom()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0 && Camera.main.orthographicSize > zoomMax)
            Camera.main.orthographicSize -= zoomSpeed;

        if (Input.GetAxis("Mouse ScrollWheel") < 0 && Camera.main.orthographicSize < zoomMin)
            Camera.main.orthographicSize += zoomSpeed;
    }
}