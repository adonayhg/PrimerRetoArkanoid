using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpPelotaDestructora : MonoBehaviour
{

    void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Jugador"))
        {
            Jugador jugador = other.GetComponent<Jugador>();
            jugador.ActivarEfectoPowerUp();

            Destroy(gameObject);
        }
    }

    private void DestruirPowerUp()
    {
        Destroy(gameObject);
    }

}
