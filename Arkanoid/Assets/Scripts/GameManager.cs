using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] InterfazUsuario interfazUsuario;
    [SerializeField] GameObject menu;
    [SerializeField] TMPro.TextMeshProUGUI puntos;
    [SerializeField] TMPro.TextMeshProUGUI tiempo;
    [SerializeField] GameObject pantallaGameOver;
    [SerializeField] private TMPro.TextMeshProUGUI textoPuntajeFinal;

    void Start()
    {
        if(pantallaGameOver != null)
        {
            pantallaGameOver.SetActive(false);

        }
    }

    public void MostrarGameOver()
    {
        if (pantallaGameOver != null)
        {
            puntos.text = SistemaPuntos.instancia.ObtenerPuntaje().ToString();
            pantallaGameOver.SetActive(true);
        }
        Time.timeScale = 0f;
    }

    public void ReiniciarNivel()
    {
        SistemaPuntos.instancia.ReiniciarPuntaje();
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //DontDestroyOnLoad(menu);
        interfazUsuario.Jugar();

    }

    public void CerrarJuego()
    {
        Application.Quit();
    }

    public void MostrarPuntajeFinal()
    {
        if (textoPuntajeFinal != null)
        {
            textoPuntajeFinal.text = SistemaPuntos.instancia.ObtenerPuntaje().ToString();
        }
    }
}
