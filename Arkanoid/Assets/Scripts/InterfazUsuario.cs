using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterfazUsuario : MonoBehaviour
{

    [SerializeField] GameObject menu;
    [SerializeField] GameObject botonJugar;
    [SerializeField] GameObject botonOpciones;
    [SerializeField] GameObject popUpOpciones;
    [SerializeField] GameObject botonesMenu;
    [SerializeField] GameObject arkanoid;
    [SerializeField] Slider sliderMusica;
    [SerializeField] float volumenMusica;
    [SerializeField] GameObject popUpPausa;
    [SerializeField] bool pausaCorriendo;
    [SerializeField] GameObject vidas;
    [SerializeField] GameObject puntos;


    void Start()
    {
        menu.SetActive(true);
        botonesMenu.SetActive(true);
        arkanoid.SetActive(true);
        sliderMusica.value = PlayerPrefs.GetFloat("volumenAudio", 0.5f);
        AudioListener.volume = sliderMusica.value;
        pausaCorriendo = false;
        vidas.SetActive(false);
        puntos.SetActive(false);
    }

    public void ChangeSlider(float valor)
    {
        volumenMusica = valor;
        PlayerPrefs.SetFloat("volumenAudio", volumenMusica);
        AudioListener.volume = sliderMusica.value;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !menu.activeSelf)
        {
            PausarJuego();
        }
    }

    public void Jugar()
    {
        botonesMenu.SetActive(false);
        menu.SetActive(false);
        vidas.SetActive(true);
        puntos.SetActive(true);
    }

    public void Opciones()
    {
        botonesMenu.SetActive(false);
        popUpPausa.SetActive(false);
        popUpOpciones.SetActive(true);

    }

    public void VolverMenu()
    {
        if (popUpOpciones.activeSelf && pausaCorriendo == false)
        {
            popUpOpciones.SetActive(false);
            botonesMenu.SetActive(true);
        }
        if (popUpOpciones.activeSelf && pausaCorriendo == true)
        {
            popUpOpciones.SetActive(false);
            popUpPausa.SetActive(true);
        }
    }

    public void CerrarJuego()
    {
        Application.Quit();
    }

    public void PausarJuego()
    {
        menu.SetActive(true);
        popUpPausa.SetActive(true);
        arkanoid.SetActive(true);
        Time.timeScale = 0f;
        pausaCorriendo = true;
    }

    public void ReanudarJuego()
    {
        menu.SetActive(false);
        popUpPausa.SetActive(false);
        arkanoid.SetActive(false);
        Time.timeScale = 1f;
        pausaCorriendo = false;
    }
}
