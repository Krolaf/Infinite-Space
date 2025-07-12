using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Suivi de caméra")]
    [SerializeField] private Transform target;
    [SerializeField] private float smoothSpeed = 5f;
    [SerializeField] private Vector3 offset = new Vector3(0, 0, -10);

    private void Start()
    {
        if (target == null)
        {
            GameObject playerShip = GameObject.Find("PlayerShip");
            if (playerShip != null)
                target = playerShip.transform;
        }
    }

    private void LateUpdate()
    {
        if (target == null) return;
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;
    }
}
