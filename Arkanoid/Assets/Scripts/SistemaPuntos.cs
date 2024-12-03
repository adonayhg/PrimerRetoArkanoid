using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaPuntos : MonoBehaviour
{
    public static SistemaPuntos instancia;

    [SerializeField] private TMPro.TextMeshProUGUI textoPuntaje;
    [SerializeField] GameObject popUpFelicidades;
    [SerializeField] TMPro.TextMeshProUGUI puntos;
    [SerializeField] TMPro.TextMeshProUGUI tiempo;
    private int puntajeActual = 0;
    public int numeroBloques;

    private void Start()
    {
        numeroBloques = GameObject.FindGameObjectsWithTag("Bloque").Length;
    }

    void Awake()
    {

        if (instancia == null)
        {
            instancia = this;
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
    public void DestruirBloques()
    {
        numeroBloques--;
        if (numeroBloques <= 0)
        {
            popUpFelicidades.SetActive(true);
            puntos.text = ObtenerPuntaje().ToString();

        }
    }
}
