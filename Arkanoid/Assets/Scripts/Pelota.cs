using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pelota : MonoBehaviour
{
    private Rigidbody pelotaRb;
    [SerializeField] private Vector3 velocidadInicial;
    [SerializeField] private float velocidadFija = 10f;
    [SerializeField] private int colisiones = 0;
    [SerializeField] private int colisionesBloque2 = 2;

    private bool enMovimiento;

    void Start()
    {
        pelotaRb = GetComponent<Rigidbody>();
        pelotaRb.velocity = Vector3.zero;
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

    /*private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bloque1"))
        {
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Bloque2"))
        {
            colisiones++;
            if (colisiones >= colisionesBloque2)
            {
                Destroy(collision.gameObject);
            }
        }


    }*/

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

