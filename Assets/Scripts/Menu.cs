using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Menu : MonoBehaviour
{
    public GameObject btnJogar;
    public GameObject btnConfig;
    public GameObject btnSair;

#if UNITY_WSA
    void Awake()
    {
        Sair.SetActive(false);
    }
#endif

    public void Jogar()
    {
        SceneManager.LoadScene("Selecao");
    }

    public void Config()
    {
        print("Chamar configurações");
    }
    
    public void Sair()
    {
        print("Sair");
        Application.Quit();
    }
}