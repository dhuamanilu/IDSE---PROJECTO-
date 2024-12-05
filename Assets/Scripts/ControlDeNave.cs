using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlDeNave : MonoBehaviour
{
    Rigidbody rigidbody;
    Transform transform;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        transform = GetComponent<Transform>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //print("Hola");
        //Debug.Log(Time.deltaTime + "seg. " + (1.0 / Time.deltaTime));
        ProcesarInput();
    }
    private void ProcesarInput()
    {
        Propulsion();
        Rotacion();
    }

    private void Rotacion()
    {
        if (Input.GetKey(KeyCode.D))
        {
            //transform.Rotate(-Vector3.forward);
            var rotarDerecha = transform.rotation;
            rotarDerecha.z -= Time.deltaTime * 1;
            transform.rotation = rotarDerecha;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            //transform.Rotate(Vector3.forward);
            var rotarIzquierda = transform.rotation;
            rotarIzquierda.z += Time.deltaTime * 1;
            transform.rotation = rotarIzquierda;
        }
    }

    private void Propulsion()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            //print("espacio a");
            rigidbody.freezeRotation = true;
            rigidbody.AddRelativeForce(Vector3.up);
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }

        }
        else
        {
            audioSource.Stop();
        }
        rigidbody.freezeRotation = false;
    }
    private void OnCollisionEnter(Collision collision)
    {
        /*if (collision.gameObject.CompareTag("ColisionSegura"))
        {
            print("Colision Segura...");
        }
        else if (collision.gameObject.CompareTag("ColisionPeligrosa"))
        {
            print("Colision Peligrosa...");
        }*/
        switch (collision.gameObject.tag) {
            case "ColisionSegura":
                print("Colision Segura...");
                break;
            case "Combustible":
                print("Combustible...");
                break;
            case "Aterrizaje":
                SceneManager.LoadScene("escena1");
                break;
            default:
                print("Warning");
                break;
        }
    }
}
