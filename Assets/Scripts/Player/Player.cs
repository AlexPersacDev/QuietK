using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, Idamagable
{
    Rigidbody rbPlayer;
    [SerializeField] Transform cameraTransform; 

    [Header("Player Stats")]
    [SerializeField] int lifes;
    [SerializeField] int damage;

    [Header("Movement")]
    [SerializeField] float speed; //velocidad de jugador
    [SerializeField] GameObject visualPlayer;
    Vector3 movDirection;
    float h, v;
    Quaternion quaternion;

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
        //quaternion = Quaternion.Euler(new Vector3(-90, 0f, cameraTransform.rotation.y));
        //visualPlayer.transform.rotation = quaternion;
        RortateWithCameraY();
        Debug.Log(quaternion);
        Jump();//salto
        CheckInGround();//chequeo de suelo
    }

    private void FixedUpdate()
    {
        PlayerPhysicMovement();//moviemiento
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

    void RortateWithCameraY()
    {
        visualPlayer.transform.localEulerAngles = new Vector3(-90, 0f, cameraTransform.eulerAngles.y);
    }

    void Idamagable.Damagable()// metodo que da�ar� al jugador
    {
        //se restar�n vidas 
        //se comprobar�n la cantidad de vidas
            //si son mayores a 0
        //se activar� la animaci�n de da�ado cortando cual sea que se est� ejecutando
            //si son menores o iguales a 0
        //se activar� la animaci�n de muerte cortando cual sea que haya ejecutandose
        //   !!!importante desactivar la opci�n de recibir m�s da�o y que los enemigos no sigan atacandote porque ya est�s muerto!!!
    }

    void Atack() //metodo que ejecutar� el ataque
    {
        //booleano que esta activado mientras el jugador se encuentra atacando para la posibilidad de combo
        //int para el conteo de veces que se ha atacado consecutivamente
            //si no se est� atacando 
        //se har� el ataque base
            //si se esta atacando
                //se comprobar� cuantas veces se ha atacado para ejecutar el ataque combo 1 o combo 2
    }

    public void EndAttack()
    {
        //bolleano de ataque a false
        //se resetea el int de conteo de ataques
    }
}
