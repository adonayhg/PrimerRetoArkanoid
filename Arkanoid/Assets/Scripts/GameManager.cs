using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [SerializeField] GameObject pantallaGameOver;

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
            pantallaGameOver.SetActive(true);
        }
        Time.timeScale = 0f;
    }

    public void ReiniciarNivel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void CerrarJuego()
    {
        Application.Quit();
    }
}
