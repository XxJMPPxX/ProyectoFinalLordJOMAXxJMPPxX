using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VidaArtefacto : MonoBehaviour
{
   public float Vida;
    public Image Barradevida;
    public TimeManager tiempo;
    public GameManager eventos;
    

   
    private void Update()
    {
        Vida = Mathf.Clamp(Vida, 0, 100);
        Barradevida.fillAmount = Vida / 100;


        if (Vida <= 0)
        {
            
            eventos.Perder.Invoke(); 
        }


        if (Vida > 0 && tiempo.tiempo <= 0)
        {
            
            eventos.Ganar.Invoke(); 
        }
    }


  
}

