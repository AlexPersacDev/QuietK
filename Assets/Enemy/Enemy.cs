using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    CharacterController controller;
    [SerializeField] float velocidadMovimiento;
    [SerializeField] float angularSpeed;
    [SerializeField] Vector3 rotacionMov;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 direcionGlobalMovimiento = Vector3.forward * v + Vector3.right * h;
        controller.Move(direcionGlobalMovimiento.normalized * velocidadMovimiento * Time.deltaTime);

        if (h > 0)
        {
            Debug.Log("ME MUEVO EN H POSITIVO");
            transform.Rotate(Vector3.back * angularSpeed * Time.deltaTime);
        }
        else if (h < 0)
        {
            Debug.Log("ME MUEVO EN H NEGATIVO");
            transform.Rotate(Vector3.forward * angularSpeed * Time.deltaTime);
        }

        if (v > 0)
        {
            Debug.Log("ME MUEVO EN V POSITIVO");
            transform.Rotate(Vector3.right * angularSpeed * Time.deltaTime);
        }

        //if (h == 0)
        //{

        //}
        
    }
}
