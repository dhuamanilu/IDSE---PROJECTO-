using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlDeNave : MonoBehaviour
{
    Rigidbody rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcesarInput();
    }
    private void ProcesarInput()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rigidbody.AddRelativeForce(Vector3.up);

        }
        if (Input.GetKey(KeyCode.D))
        {
            print("Rot derecha");
        }
        else if (Input.GetKey(KeyCode.A))
        {
            print("Rot izquierda");
        }
    }
}
