using System.Runtime.ConstrainedExecution;
using UnityEngine;

public class PlayerControllerRb : MonoBehaviour
{
    private float hor;
    public Rigidbody rb;
    private Vector3 velocity;
    private Vector3 startPos;
    private float movSpeed;
    private float jumpHeight = 400f;
    private bool grounded;
    private bool jump;

    private void Start()
    {
        startPos = transform.position;
        Cursor.lockState = CursorLockMode.Locked; // Cursor Locked
        Cursor.visible = false;
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // Movement & Rotation
        hor = Input.GetAxis("Horizontal");
        velocity = Vector3.zero;

        if (transform.position.y < -20) //Respawn by fall
        {
            Respawn();
        }

        CheckGround(); //Check ground for jump

        if (Input.GetKeyDown(KeyCode.Space) && grounded) //Jump
        {
            Jump();
        }
        if (!jump)
        {
            movSpeed = 10f;
        }
        else 
        {
            movSpeed = 2f;
        }
    }

    private void FixedUpdate()
    {

            if (hor != 0)
            {
                Vector3 direction = (transform.right * hor).normalized;
                velocity = direction * movSpeed;
            }
            velocity.y = rb.velocity.y;
            rb.velocity = velocity;
        
    }

    private void Respawn() 
    {
        transform.position = startPos;
    }

    private void CheckGround() 
    {
        RaycastHit hitInfo;
        Debug.DrawRay(transform.position, Vector3.down * 1.3f, Color.blue);
        if (Physics.Raycast(transform.position, -Vector3.up, out hitInfo, 1.3f, LayerMask.GetMask("Ground")))
        {
            grounded = true;
            jump = false;
        }
        else
        {
            grounded = false;
            jump = true;
        }
    }

    private void Jump() 
    {
        rb.AddForce(Vector3.up * jumpHeight);
    }
}
