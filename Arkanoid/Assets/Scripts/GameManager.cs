using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    int numeroBloques;
    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Instance = this;
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        numeroBloques = GameObject.FindGameObjectsWithTag("Bloque1").Length;
    }

    public void BloquesDesruidos()
    {
        numeroBloques--;
        if(numeroBloques <= 0)
        {
            SiguienteNivel();
        }
    }

    void SiguienteNivel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void RepetirNivel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
