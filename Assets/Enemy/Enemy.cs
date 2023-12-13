using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Limites
{
    public float xMin, xMax, zMin, zMax;
}
public class Enemy : MonoBehaviour
{
    [Header("VIDEO YOUTUBE")]
    Rigidbody gravedad;
    public float inclinacion;
    public Limites limites;


    CharacterController controller;
    [SerializeField] float velocidadMovimiento;
    [SerializeField] float velocidadRotacion;
    [SerializeField] Vector3 rotacionMov;
    float h, v;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        gravedad = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        //RotacionEnemigo(rotacionMov, 200);

    }

    void FixedUpdate()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        Vector3 movimiento = new Vector3(h, 0, v);
        gravedad.velocity = movimiento * velocidadMovimiento;

        if (h > 0)
        {
            //gravedad.rotation = Quaternion.Euler(0, 0, gravedad.velocity.);
        }
        if (v > 0)
        {
            Debug.Log(v);
            gravedad.rotation = Quaternion.Euler(0, 0, gravedad.velocity.x * -inclinacion);
        }
        
    }

    void RotacionEnemigo(Vector3 target, float smooth)
    {
        //if (h > 0)
        //{
        //    Debug.Log("ME MUEVO EN H POSITIVO");
        //    //transform.Rotate(rotacionMov * velocidadAngulo * Time.deltaTime);
        //    float angulo = Mathf.Atan2(target.x, target.z) * Mathf.Rad2Deg;
        //     float anguloSuave = Mathf.SmoothDampAngle(transform.eulerAngles.x, angulo, ref velocidadRotacion, smooth);
        //    transform.eulerAngles = new Vector3(angulo, 0, 0);
        //}
        //else if (h < 0)
        //{
        //    Debug.Log("ME MUEVO EN H NEGATIVO");
        //    transform.Rotate(Vector3.forward * velocidadRotacion * Time.deltaTime);
        //}
        //if (v > 0)
        //{
        //    Debug.Log("ME MUEVO EN V POSITIVO");
        //    //transform.Rotate(Vector3.right * velocidadRotacion * Time.deltaTime);
        //    float angulo = Mathf.Atan2(target.x, target.z) * Mathf.Rad2Deg;
        //    float anguloSuave = Mathf.SmoothDampAngle(transform.eulerAngles.x, angulo, ref velocidadRotacion, smooth);
        //    transform.eulerAngles = new Vector3(anguloSuave, 0, 0);
        //}
        //else if (v < 0)
        //{
        //    Debug.Log("ME MUEVO EN V NEGATIVO");
        //    transform.Rotate(Vector3.left * velocidadRotacion * Time.deltaTime);
        //}




       // gravedad.position = new Vector3(Mathf.Clamp(gravedad.position.x, limites))
    }
}
