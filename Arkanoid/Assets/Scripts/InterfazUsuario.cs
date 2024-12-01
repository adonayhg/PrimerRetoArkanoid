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



    void Start()
    {
        menu.SetActive(true);
        sliderMusica.value = PlayerPrefs.GetFloat("volumenAudio", 0.5f);
        AudioListener.volume = sliderMusica.value;
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
        
    }

    public void Jugar()
    {
        menu.SetActive(false);

    }

    public void Opciones()
    {
        botonesMenu.SetActive(false);
        popUpOpciones.SetActive(true);

    }

    public void CerrarOpciones()
    {
        popUpOpciones.SetActive(false);
        botonesMenu.SetActive(true);
    }

    public void CerrarJuego()
    {
        Application.Quit();
    }

}
