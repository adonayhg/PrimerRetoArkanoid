using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloques : MonoBehaviour
{
     [SerializeField] int golpesNecesarios = 1;
     private int golpesActuales = 0;

     private Renderer bloqueRenderer;

     [SerializeField] private int puntosPorBloque = 10;
     [SerializeField] private GameObject prefabPowerUp;
     [SerializeField] private GameObject prefabPowerUpInvertido;
    [SerializeField] private GameObject prefabPowerUpSlow;
    [SerializeField] private float probabilidadPowerUp = 0.3f;


    void Start()
     {
             bloqueRenderer = GetComponent<Renderer>();
     }

     private void OnCollisionEnter(Collision collision)
     {
         if (collision.gameObject.CompareTag("Pelota"))
         {
             golpesActuales++; 

             if (golpesActuales >= golpesNecesarios)
             {
                     RecibirGolpe();
                     SistemaPuntos.instancia.AgregarPuntos(puntosPorBloque);
                     SistemaPuntos.instancia.DestruirBloques();
             }
         }
     }

    public void RecibirGolpe()
    {
        golpesActuales++;
        if (golpesActuales >= golpesNecesarios)
        {
            GenerarPowerUp();
            GenerarPowerUpInvertido();
            GenerarPowerUpSlow();
            Destroy(gameObject); 
        }
    }

    private void GenerarPowerUp()
    {
        if (Random.value <= probabilidadPowerUp && prefabPowerUp != null)
        {
            Instantiate(prefabPowerUp, transform.position, Quaternion.identity);
        }
    }

    
    private void GenerarPowerUpInvertido()
    {
        if (Random.value <= probabilidadPowerUp && prefabPowerUp != null)
        {
            Instantiate(prefabPowerUpInvertido, transform.position, Quaternion.identity);
        }
    }
    private void GenerarPowerUpSlow()
    {
        if (Random.value <= probabilidadPowerUp && prefabPowerUp != null)
        {
            Instantiate(prefabPowerUpSlow, transform.position, Quaternion.identity);
        }
    }

}
