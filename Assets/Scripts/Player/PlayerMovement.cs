using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    public Transform cameraTransform;
    public float speed = 5f;
    private InputActions inputActions;
    private InputAction movement;
    private Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        inputActions = new InputActions();
        inputActions.Player.Enable();
        movement = inputActions.Player.Movement;

        if (cameraTransform == null)
            Debug.LogWarning("Camera Transform is not set");
    }

    void FixedUpdate()
    {
        Vector2 input = movement.ReadValue<Vector2>().normalized;
        Vector3 moveDirection = cameraTransform.forward * input.y + cameraTransform.right * input.x;
        moveDirection.y = 0f; // Avoid vertical movement by looking up or down
        rb.AddForce(moveDirection.normalized * speed, ForceMode.VelocityChange);
        limitSpeed();
    }

    private void limitSpeed()
    {
        Vector3 velocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);

        if (velocity.magnitude > speed)
        {
            Vector3 limitedVelocity = velocity.normalized * speed;
            rb.linearVelocity = new Vector3(limitedVelocity.x, rb.linearVelocity.y, limitedVelocity.z);
        }
    }
}
