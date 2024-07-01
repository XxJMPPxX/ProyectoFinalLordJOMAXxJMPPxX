using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private GameObject COmoJugar;
    [SerializeField] private GameObject Ajustes;
    [SerializeField] private GameObject Bestiario;
    [SerializeField] private GameObject Ajustesesc;
    [SerializeField] private GameObject BestiarioHash;
    [SerializeField] private GameObject Creditoswaza;
    [SerializeField] private bool veldadomentira;
    [SerializeField] private bool veldadomentira2;
    [SerializeField] private TimeManager tiempo;
    [SerializeField] public VidaArtefacto vida;



    public UnityEvent Perder;
    public UnityEvent Ganar;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }
   


        public void Level0()
    {
       
        Time.timeScale = 1;
        SceneManager.LoadScene("Level0");
    }
    public void Level1()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Level1");
    }
    public void Died()
    {

        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SceneManager.LoadScene("DiedScene");
    }

    public void Menu()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }

    public void SelectLv()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 1;
        SceneManager.LoadScene("Selector de niveles");
    }

    public void QuitarJuego()
    {
        Application.Quit();
    }
    public void Howtoplay()
    {
        veldadomentira = !veldadomentira;
        if (veldadomentira)
        {
            COmoJugar.SetActive(true);
        }
        else
        {
            COmoJugar.SetActive(false);
        }
    }
    public void Ajusteswaza()
    {
        veldadomentira = !veldadomentira;
        if (veldadomentira)
        {
            Ajustes.SetActive(true);
        }
        else
        {
            Ajustes.SetActive(false);
        }
    }
    public void CreditosPE()
    {
        veldadomentira = !veldadomentira;
        if (veldadomentira)
        {
            Creditoswaza.SetActive(true);
        }
        else
        {
            Creditoswaza.SetActive(false);
        }
    }
    public void Bestiariowaza()
    {
        veldadomentira = !veldadomentira;
        if (veldadomentira)
        {
            Bestiario.SetActive(true);
        }
        else
        {
            Bestiario.SetActive(false);
        }
    }
    public void BuscadorHash()
    {
        veldadomentira2 = !veldadomentira2;
        if (veldadomentira2)
        {
            BestiarioHash.SetActive(true);
        }
        else
        {
            BestiarioHash.SetActive(false);
        }
    }
    public void Ajuste(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (!veldadomentira)
            {
                veldadomentira = true;
                Ajustesesc.SetActive(true);
                Time.timeScale = 0;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
    }
    public void Ajusteoff()
    {
        if (veldadomentira)
        {
            veldadomentira = false;
            Ajustesesc.SetActive(false);
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
