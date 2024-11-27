using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pelota : MonoBehaviour
{
    private Rigidbody   pelotaRb;
    [SerializeField] private Vector2 velocidad;

    // Start is called before the first frame update
    void Start()
    {
        pelotaRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
