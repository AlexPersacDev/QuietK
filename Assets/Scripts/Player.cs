using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //CharacterController playerController; 
    Rigidbody rbPlayer;
    [SerializeField] float speed; //velocidad de jugador
    [SerializeField] Transform cameraTransform; 
    Vector3 movDirection;
    Vector3 yMovement;
    float h, v;

    [Header("Jump")]
    [SerializeField] float gravityScale;
    [SerializeField] float jumpForce;
    [SerializeField] Transform playerFoot;
    [SerializeField] float footRad;
    [SerializeField] LayerMask whatIsGround;

    void Start()
    {
        // playerController = GetComponent<CharacterController>();
        rbPlayer = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");
        movDirection = cameraTransform.forward * v + cameraTransform.right * h;
        movDirection.y = 0;
        //GravityAplication();
        PlayerMovement();

    }

    private void FixedUpdate()
    {
        Jump();
    }

    //void GravityAplication()
    //{
    //    yMovement.y += gravityScale * Time.deltaTime; //La gravedad se va incrementando cada frame.

    //    playerController.Move(yMovement * Time.deltaTime); //Muevo al controller en el eje Y basandome en esa gravedad.
    //}

    void PlayerMovement()
    {
        rbPlayer.transform.Translate(movDirection.normalized * Time.deltaTime * speed);
        //float xVelClamped = Mathf.Clamp(rbPlayer.velocity.x, 0, 5);
        //float zVelClamped = Mathf.Clamp(rbPlayer.velocity.z, 0, 5);
        //rbPlayer.AddForce(movDirection * speed, ForceMode.Force);
        //if (v == 0 && h == 0)
        //{
        //    rbPlayer.velocity = new Vector3(0, rbPlayer.velocity.y, 0);
        //}
        //else if (rbPlayer.velocity.x > xVelClamped || rbPlayer.velocity.z > zVelClamped)
        //{
        //    if (rbPlayer.velocity.x > xVelClamped)
        //    {
        //        rbPlayer.velocity = new Vector3(xVelClamped, rbPlayer.velocity.y, rbPlayer.velocity.z);
        //    }
        //    else if (rbPlayer.velocity.z > zVelClamped)
        //    {
        //        rbPlayer.velocity = new Vector3(rbPlayer.velocity.x, rbPlayer.velocity.y, zVelClamped);
        //    }
        //}
    }

    void Jump()
    {
        if (Physics.CheckSphere(playerFoot.position, footRad, whatIsGround))
        {
           // yMovement.y = 0;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rbPlayer.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                //float jump = Mathf.Sqrt(-2 * gravityScale * jumpHeigh);
                //yMovement = new Vector3(0, jump, 0);
            }
        }
    }
}
