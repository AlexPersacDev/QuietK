using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    CharacterController playerController; 
    [SerializeField] float speed; //velocidad de jugador
    [SerializeField] Transform cameraTransform; 
    Vector3 movDirection;
    Vector3 yMovement;
    float h, v;

    [Header("Jump")]
    [SerializeField] float gravitySacle;

    void Start()
    {
        playerController = GetComponent<CharacterController>();

        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");
        movDirection = cameraTransform.forward * v + cameraTransform.right * h;
        movDirection.y = 0;
        CameraRotation();
        PlayerMovement();
    }

    void PlayerMovement()
    {
        playerController.Move(movDirection.normalized * speed * Time.deltaTime);
    }

    void CameraRotation()
    {
        float angle = Mathf.Atan2(movDirection.x, movDirection.z) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0, angle, 0);
    }

    void AplicarGravedad()
    {
        yMovement.y += gravitySacle * Time.deltaTime; //La gravedad se va incrementando cada frame.

        playerController.Move(yMovement * Time.deltaTime); //Muevo al controller en el eje Y basandome en esa gravedad.

    }
}
