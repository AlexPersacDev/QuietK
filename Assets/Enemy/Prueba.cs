using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    Vector2 movimiento;//variable para el movimienoty del cuerpo
    [SerializeField] Transform zonaInteractuable;
    Animator anim;
    Rigidbody rb;
    public float fuerzaMovimiento;
    float velocidadRotacion;
    bool comienzoARotar;
    float contadorToques;
    [SerializeField] float radioInteraccion;
    [SerializeField] LayerMask queEsInteractuable;
    AudioSource audioSource;
    [SerializeField] GameObject interfaz;

    //public new Vector3 movEmpuje;
    public bool push;
    bool estoyAndando;
    int enteroX;
    int enteroY;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();//consigo el rigidbody del personaje
        anim = GetComponent<Animator>();//consigo el componente animator del personaje
        audioSource = GetComponent<AudioSource>();


    }

    // Update is called once per frame
    void Update()
    {



        rb.AddForce(new Vector3(1, 0, 0).normalized * movimiento.x * fuerzaMovimiento, ForceMode.Force);//recojo el eje x del joystic izquierdo para multiplicarlo por una direccion y velocidad 
        rb.AddForce(new Vector3(0, 0, 1).normalized * movimiento.y * fuerzaMovimiento, ForceMode.Force);//recojo el eje y del joystic izquierdo para multiplicarlo por una direccion y velocidad 



        //  DireccionHaciaLaQueRotar = transform.forward * movimiento.x + transform.right * movimiento.y;


        if (movimiento.x != 0 || movimiento.y != 0)//si los valores del joystic izquierdo son distinto de 0...
        {

            anim.SetBool("Correr", true);
            // OrientarseHaciaEnemigo(DireccionHaciaLaQueRotar, 0.1f);
            comienzoARotar = true;//puedo Rotar
        }
        if (movimiento.x == 0 && movimiento.y == 0)//si el joystic esta a 0...
        {
            // audioSource.Stop();
            anim.SetBool("Correr", false);
            comienzoARotar = false;// dejo de rotar
            //enteroX = Mathf.RoundToInt(movimiento.x);
            //enteroY = Mathf.RoundToInt(movimiento.y);
            //movimiento.x = enteroX;
            //movimiento.y = enteroY;


        }


        //if (movimiento.x > 0)
        //{
        //    movX = movX + 300 * Time.deltaTime;


        //}

        //else if (movimiento.x < 0 )
        //{
        //    movX = movX - 300  * Time.deltaTime;

        //}
        //if (movimiento.y > 0)
        //{
        //    movY = movY + 300 * Time.deltaTime;
        //}
        //else if (movimiento.y < 0)
        //{
        //    movY = movY - 300 * Time.deltaTime;
        //}

        if (comienzoARotar)//si comienzo a Rotar...
        {
            anim.SetFloat("x", movimiento.x);// las animaciones de x vienen vinculadas al movimiento x
            anim.SetFloat("y", movimiento.y);//las animaciones de la y vienen vinculadeas al movimiento de la y

        }



    }
    void Overlap()//lanzo overlap para encontrar colliders
    {
        Collider[] coll = Physics.OverlapSphere(zonaInteractuable.position, radioInteraccion, queEsInteractuable);
        if (coll.Length > 0)// si encuentro algo en el overlap 
        {

            coll[0].GetComponentInParent<Animator>().SetTrigger("Roto ");//si le doy a rotar algo que se active la niamcion de rotar


        }

    }

    void RotarHaciaObjeto(Vector3 target, float Smoth)
    {

        //Arcotangente,convierte la rotacion en grados ,para saber que rotacion ponerle a mi personaje
        float angulo = Mathf.Atan2(target.x, target.z) * Mathf.Rad2Deg;//el calculo me lo dan en radios ...Y LO TENGO QUE CONVERTIR A RADIANES
        float anguloSuave = Mathf.SmoothDampAngle(transform.eulerAngles.y, angulo, ref velocidadRotacion, Smoth);//vamos a crear una interpolacion entre el angulo al que estamos mirando y al angulo hacia el que vamos a mirar , con una velocidad de rotacion y un  Smootheado


        transform.eulerAngles = new Vector3(0, anguloSuave, 0);
    }


    void OrientarseHaciaEnemigo(Vector3 target, float Smoth)
    {

        //Arcotangente,convierte la rotacion en grados ,para saber que rotacion ponerle a mi personaje
        float angulo = Mathf.Atan2(target.x, target.z) * Mathf.Rad2Deg * -1;//el calculo me lo dan en radios ...Y LO TENGO QUE CONVERTIR A RADIANES
        float anguloSuave = Mathf.SmoothDampAngle(transform.eulerAngles.y, angulo, ref velocidadRotacion, Smoth);//vamos a crear una interpolacion entre el angulo al que estamos mirando y al angulo hacia el que vamos a mirar , con una velocidad de rotacion y un  Smootheado


        transform.eulerAngles = new Vector3(0, anguloSuave, 0);

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Piece"))
        {
            if (collision.gameObject.GetComponent<Rigidbody>().velocity.y < 0)// si esta cayendo 
            {
                //interfaz.GetComponent<Pausa>().Muerte();
                Destroy(gameObject);

            }
        }
    }
    void sonidoPisadas()
    {
        audioSource.Play();

    }


}
