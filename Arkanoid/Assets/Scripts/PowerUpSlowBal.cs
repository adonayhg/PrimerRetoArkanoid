using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSlowBal : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Jugador"))
        {
            Jugador jugador = other.GetComponent<Jugador>();
            jugador.ActivarPowerUpSlow();

            Destroy(gameObject);
        }
    }
}
