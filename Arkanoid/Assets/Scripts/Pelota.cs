using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pelota : MonoBehaviour
{
    private Rigidbody pelotaRb;
    [SerializeField] private Vector3 velocidadInicial;
    [SerializeField] private Transform posicionInicial;
    [SerializeField] private float velocidadFija = 10f;
    [SerializeField] GameObject jugador;
    private bool enMovimiento;
    public delegate void VidaPerdida();
    public static event VidaPerdida OnVidaPerdida;

    void Start()
    {
        pelotaRb = GetComponent<Rigidbody>();
        pelotaRb.velocity = Vector3.zero;
        ResetearPelota();
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

    private void ResetearPelota()
    {
        //transform.parent != null;
        transform.position = posicionInicial.position;
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
}

