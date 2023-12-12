using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody rbPlayer;
    [SerializeField] float speed; //velocidad de jugador
    [SerializeField] Transform cameraTransform; 
    Vector3 movDirection;
    float h, v;

    [Header("Jump")]
    [SerializeField] float jumpForce;
    [SerializeField] Transform playerFoot;
    [SerializeField] float footRad;
    [SerializeField] LayerMask whatIsGround;
    int jumpsCount = 0;

    void Start()
    {
        rbPlayer = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");
        movDirection = cameraTransform.forward * v + cameraTransform.right * h;
        //movDirection.y = 0;
        Jump();
        CheckInGround();
    }

    private void FixedUpdate()
    {
        PlayerPhysicMovement();
    }

    void CheckInGround()
    {
        if (Physics.CheckSphere(playerFoot.position, footRad, whatIsGround))
        {
            jumpsCount = 0;
            rbPlayer.mass = 1;
        }
    }
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpsCount < 2)
        {
            rbPlayer.velocity = Vector3.zero;
            jumpsCount++;
            rbPlayer.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    void PlayerPhysicMovement()
    {
        rbPlayer.AddForce(movDirection * speed, ForceMode.Force);
        if (v == 0 && h == 0)
        {
            rbPlayer.velocity = new Vector3(0, rbPlayer.velocity.y, 0);
        }
        if (rbPlayer.velocity.magnitude > speed)
        {
            rbPlayer.velocity = Vector3.ClampMagnitude(rbPlayer.velocity, speed);
        }
    }
}
