using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class JugadorController : MonoBehaviour
{

    public float velocidad;
    public Text textoContador, textoGanar;
    private Rigidbody rb;
    private int contador;

    void Start ()
    {
        textoGanar.gameObject.SetActive(false);
        rb = GetComponent<Rigidbody>();
        velocidad = 10;
    }

    void ActualizarContador()
    {
        textoContador.text = "Contador: " + contador.ToString();

        if(contador>=12)
        {
            textoGanar.gameObject.SetActive(true);
            textoGanar.text = "¡Ganaste!";
        }
    }

    void Update()
    {
        ActualizarContador();
    }

    void FixedUpdate ()
    {
        float movimientoH = Input.GetAxis("Horizontal");
        float movimientoV = Input.GetAxis("Vertical");

        Vector3 movimiento = new Vector3(movimientoH, 0.0f, movimientoV);
        rb.AddForce(movimiento * velocidad);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag ("Coleccionable"))
        {
            other.gameObject.SetActive (false);
            contador++;
        }
    }
}