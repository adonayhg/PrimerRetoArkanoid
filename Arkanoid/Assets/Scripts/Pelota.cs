using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pelota : MonoBehaviour
{
    private Rigidbody   pelotaRb;
    [SerializeField] private Vector3 velocidadInicial;
    bool enMovimiento;

    // Start is called before the first frame update
    void Start()
    {
        pelotaRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && !enMovimiento)
        {
            transform.parent = null;
            pelotaRb.velocity = velocidadInicial;
            enMovimiento = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bloque1"))
        {
            Destroy(collision.gameObject);
        }
    }
}
