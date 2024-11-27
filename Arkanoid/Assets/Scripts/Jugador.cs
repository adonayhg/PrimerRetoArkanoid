using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    [SerializeField] float velocidadJugador;
    [SerializeField] float desplazamientoJugadorIzq = 18f;
    [SerializeField] float desplazamientoJugadorDer = -7f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float movimientoInput = Input.GetAxis("Horizontal");
        //transform.position += new Vector3(movimientoInput * velocidadJugador * Time.deltaTime, 0f, 0f);

        Vector3 posiciónJugador = transform.position;
        posiciónJugador.x = Mathf.Clamp(posiciónJugador.x + movimientoInput * velocidadJugador * Time.deltaTime, desplazamientoJugadorDer, desplazamientoJugadorIzq);
        transform.position = posiciónJugador;

    }
}
