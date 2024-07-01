using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField] private TMP_Text tiempoText;
    [SerializeField] public float tiempo;

    void Update()
    {
        tiempo -= Time.deltaTime;
        if (tiempoText != null)
        {
            tiempoText.text = "Tiempo: " + tiempo.ToString("f0");

        }
    }
}
