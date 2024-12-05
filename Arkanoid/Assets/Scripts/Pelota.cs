using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pelota : MonoBehaviour
{
    private Rigidbody pelotaRb;
    [SerializeField] private Vector3 velocidadInicial;
    [SerializeField] private Transform posicionInicial;
    [SerializeField] private Transform posicionInicialJugador;
    [SerializeField] private float velocidadFija = 10f;
    [SerializeField] GameObject basejugador;
    [SerializeField] GameObject jugador;
    private bool enMovimiento;
    public delegate void VidaPerdida();
    public static event VidaPerdida OnVidaPerdida;
    private bool modoInverso = false;
    private float tiempoModoInvertido = 0f;
    private bool modoSlow = false;
    private float tiempoModoSlow = 0f;
    [SerializeField] private Jugador jugadorScript;


    void Start()
    {
        pelotaRb = GetComponent<Rigidbody>();
        pelotaRb.velocity = Vector3.zero;
        ResetearPelota();
        modoInverso = false;
        modoSlow = false;
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump") && !enMovimiento)
        {
            transform.parent = null;
            pelotaRb.velocity = velocidadInicial.normalized * velocidadFija;
            enMovimiento = true;
        }

        if (enMovimiento)
        {
            pelotaRb.velocity = pelotaRb.velocity.normalized * velocidadFija;
        }

        if (enMovimiento)
        {
            CambioVelocidad();
        }
        if (enModoDestructivo)
        {
            tiempoModoDestructivo -= Time.deltaTime;
            if (tiempoModoDestructivo <= 0)
            {
                DesactivarModoDestructivo();
            }
        }
        if (modoInverso == true)
        {
            tiempoModoInvertido -= Time.deltaTime;
            if (tiempoModoInvertido <= 0)
            {
                jugadorScript.DesactivarModoInvertido();
            }
        }
        if (modoSlow == true)
        {
            tiempoModoSlow -= Time.deltaTime;
            if (tiempoModoSlow <= 0)
            {
                DesactivarModoSlow();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
    
        if (other.CompareTag("LimiteInferior"))
        {
            enMovimiento = false;
            pelotaRb.velocity = Vector3.zero; 
            ResetearPelota();

            OnVidaPerdida?.Invoke();
        }
    }

    public void ResetearPelota()
    {
        gameObject.transform.parent = basejugador.transform;
        jugador.transform.position = posicionInicialJugador.transform.position;
        transform.position = posicionInicial.transform .position;

    }

    void CambioVelocidad()
    {
        float velocidadDelta = 1f;
        float velocidadMin = 0.2f;

        if (Mathf.Abs(pelotaRb.velocity.x) < velocidadMin)
        {
            velocidadDelta = Random.value < 0.5f ? velocidadDelta : -velocidadDelta;
            pelotaRb.velocity += new Vector3(velocidadDelta, 0f, 0f);
        }

        if (Mathf.Abs(pelotaRb.velocity.y) < velocidadMin)
        {
            velocidadDelta = Random.value < 0.5f ? velocidadDelta : -velocidadDelta;
            pelotaRb.velocity += new Vector3(0f, velocidadDelta, 0f);
        }
    }
    private bool enModoDestructivo = false;
    private float tiempoModoDestructivo = 0f;

    public void ActivarModoDestructivo(float duracion = 10)
    {
        enModoDestructivo = true;
        tiempoModoDestructivo = duracion;
    }

    private void DesactivarModoDestructivo()
    {
        enModoDestructivo = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bloque"))
        {
            if (enModoDestructivo)
            {
                Destroy(collision.gameObject);
            }
        }
    }

    public void ActivarModoInvertido()
    {
        modoInverso = true;
        tiempoModoInvertido = 10;
    }

    public void PowerUpSlow()
    {
        modoSlow = true;
        velocidadFija = 10;
    }
    private void DesactivarModoSlow()
    {
        modoSlow = false;
    }
}