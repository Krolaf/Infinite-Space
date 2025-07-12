using UnityEngine;
using UnityEngine.InputSystem;

public class ShipController : MonoBehaviour
{
    [Header("Mouvement")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float rotationSpeed = 5f;

    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Vector2 lastMoveDirection;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody2D manquant sur le vaisseau !");
        }
    }

    private void FixedUpdate()
    {
        if (moveInput.magnitude > 0.1f)
        {
            lastMoveDirection = moveInput.normalized;
            rb.linearVelocity = moveInput * moveSpeed;
            float targetAngle = Mathf.Atan2(lastMoveDirection.y, lastMoveDirection.x) * Mathf.Rad2Deg - 90f;
            float currentAngle = transform.eulerAngles.z;
            float newAngle = Mathf.LerpAngle(currentAngle, targetAngle, rotationSpeed * Time.fixedDeltaTime);
            transform.rotation = Quaternion.Euler(0, 0, newAngle);
        }
        else
        {
            rb.linearVelocity = Vector2.zero;
        }
    }

    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }
}
