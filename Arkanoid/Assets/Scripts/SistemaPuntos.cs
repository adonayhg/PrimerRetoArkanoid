using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaPuntos : MonoBehaviour
{
    public static SistemaPuntos instancia;

    [SerializeField] private TMPro.TextMeshProUGUI textoPuntaje;
    private int puntajeActual = 0;

    void Awake()
    {

        if (instancia == null)
        {
            instancia = this;
            //DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AgregarPuntos(int puntos)
    {
        puntajeActual += puntos;
        ActualizarUI();
    }

    private void ActualizarUI()
    {
        if (textoPuntaje != null)
        {
            textoPuntaje.text = "Puntos: " + puntajeActual;
        }
    }

    public int ObtenerPuntaje()
    {
        return puntajeActual;
    }

    public void ReiniciarPuntaje()
    {
        puntajeActual = 0;
        ActualizarUI();
    }
}
