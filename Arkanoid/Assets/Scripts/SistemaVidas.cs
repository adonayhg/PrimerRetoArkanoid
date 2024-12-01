using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SistemaVidas : MonoBehaviour
{
        [SerializeField] private int vidas = 3;
        [SerializeField] private TMPro.TextMeshProUGUI textoVidas;
        [SerializeField] private GameManager gameManager;

        void OnEnable()
        {
            Pelota.OnVidaPerdida += RestarVida;
        }

        void OnDisable()
        {
            Pelota.OnVidaPerdida -= RestarVida;
        }

        void Start()
        {
            ActualizarTextoVidas();
        }

        private void RestarVida()
        {
            vidas--;
            ActualizarTextoVidas();

            if (vidas <= 0)
            {
                gameManager.MostrarGameOver();

            }
        }
        private void ActualizarTextoVidas()
        {
            if (textoVidas != null)
            {
                    textoVidas.text = "Vidas: " + vidas;
            }
        }

    }
