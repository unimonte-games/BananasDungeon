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
    [Space(20)]
    AudioSource Musica;
    AudioSource SFX;
    public AudioClip SomClick;
    public AudioClip SomJogar;

    void Awake()
    {
#if UNITY_WSA
        Sair.SetActive(false);
#endif
        SFX = GameObject.Find("SFX").GetComponent<AudioSource>();
    }

    public void Jogar()
    {
        SceneManager.LoadScene("Selecao");
        SFX.PlayOneShot(SomJogar);
    }

    public void Config()
    {
        print("Chamar configurações");
        SFX.PlayOneShot(SomClick);
    }
    
    public void Sair()
    {
        SFX.PlayOneShot(SomClick);
        Application.Quit();
    }
}