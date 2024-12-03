using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloques : MonoBehaviour
{
    [SerializeField] int golpesNecesarios = 1;
    private int golpesActuales = 0;
        
    private Renderer bloqueRenderer;

    [SerializeField] private int puntosPorBloque = 10;

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
                    Destroy(gameObject);
                    SistemaPuntos.instancia.AgregarPuntos(puntosPorBloque);
                    SistemaPuntos.instancia.DestruirBloques();
            }
        }
    }
}
