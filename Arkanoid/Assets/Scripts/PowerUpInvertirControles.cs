using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpInvertirControles : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Jugador"))
        {
            Jugador jugador = other.GetComponent<Jugador>();
            jugador.PowerUpInvertido();

            Destroy(gameObject);
        }
    }

}
