using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VidaArtefacto : MonoBehaviour
{
    [SerializeField] private float Vida;
    public Image Barradevida;
    private void Update()
    {
        Vida = Mathf.Clamp(Vida,0, 100);
        Barradevida.fillAmount = Vida / 100;
    }
}
