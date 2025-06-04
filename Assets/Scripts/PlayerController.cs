using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.Rendering.DebugUI;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float moveSpeed;
    [SerializeField][Min(1.0f)]
    float maxDashRate;
    [SerializeField][Min(0.0f)]
    float maxSpeedSec;

    float dashRate = 1.0f;
    bool isDashing = false;
    Vector2 moveInput;
    Vector3 velocity;

    Rigidbody rb;
    [SerializeField]
    Transform playerCamera;
    public float GetSpeed()
    {
        return moveSpeed;
    }
    public void OnDash(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            isDashing = true;
        }
        else if (context.canceled)
        {
            dashRate = 1.0f;
            isDashing = false;
        }
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }
    void Start()
    {
        Initialize();
    }
    void Initialize()
    {
        velocity = Vector3.zero;
        rb = GetComponent<Rigidbody>();
        dashRate = 1.0f;
    }
    void Update()
    {
        Move();
    }

    void Move()
    {
        Vector3 position = transform.position;

        velocity = new Vector3(moveInput.x, 0.0f, moveInput.y);

        Vector3 camForward = Vector3.Scale(playerCamera.forward, new Vector3(1, 0, 1)).normalized;
        Vector3 camRight = playerCamera.right;

        Vector3 move = camForward * velocity.z + camRight * velocity.x;
        move = move.normalized;

        if (move.magnitude > 0.1f)
        {
            if (isDashing)
            {
                dashRate += (maxDashRate - 1.0f) * Time.deltaTime / maxSpeedSec;
                dashRate = Mathf.Clamp(dashRate, 1.0f, maxDashRate);
                Debug.Log("ダッシュレート: " + dashRate);
            }

            move *= moveSpeed * dashRate * Time.deltaTime;
            
            rb.MovePosition(transform.position + move);

            transform.rotation = Quaternion.LookRotation(move);
        }
    }

}
