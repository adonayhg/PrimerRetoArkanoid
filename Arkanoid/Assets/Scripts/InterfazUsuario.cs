using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterfazUsuario : MonoBehaviour
{

    [SerializeField] GameObject menu;
    [SerializeField] GameObject botonJugar;
    [SerializeField] GameObject botonOpciones;
    [SerializeField] GameObject popUpOpciones;
    [SerializeField] GameObject botonesMenu;


    void Start()
    {
        menu.SetActive(true);
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
}
