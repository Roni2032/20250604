using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    float rotateSpeed;
    [SerializeField]
    float armLength;
    [SerializeField]
    GameObject player;

    Vector2 mouseInput;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    public void OnLook(InputAction.CallbackContext context)
    {
        mouseInput = context.ReadValue<Vector2>();
    }
    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            transform.LookAt(player.transform.position);
        }

        if(Mathf.Abs(mouseInput.x) > 0.01f)
        {
            transform.RotateAround(player.transform.position,Vector3.up, mouseInput.x * rotateSpeed * Time.deltaTime);
        }
        if (Mathf.Abs(mouseInput.y) > 0.01f)
        {
            transform.RotateAround(player.transform.position, Vector3.right, mouseInput.y * rotateSpeed * Time.deltaTime);
        }

        Vector3 direction = transform.position - player.transform.position;
        direction = direction.normalized;

        transform.position = player.transform.position + direction * armLength;
    }
}
