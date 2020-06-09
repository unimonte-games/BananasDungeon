using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interruptor : MonoBehaviour
{
    public float intensidadePerto = 20;
    public float intensidadeLonge = 10;
    public GameObject[] Portas;
    Light LuzAlavanca;
    List<Light> LuzPorta =  new List<Light>();
    public Color CorAtivado = Color.white;
    bool estadoInterruptor = false;
    Animator anim;
    AudioSource SFX;
    public AudioClip somAlavanca;

    public enum Alavanca
    {
        Parado = 0,
        Ativar,
        Desativar//caso queiram q seja desativado
    }

    void Awake()
    {
        anim = GetComponent<Animator>();
        SFX  = GameObject.Find("SFX").GetComponent<AudioSource>();

        LuzAlavanca = GetComponentInChildren<Light>();
        for (int x = 0; x < Portas.Length; x++)
        {
            LuzPorta.Add(Portas[x].GetComponentInChildren<Light>());
        }

        LuzAlavanca.color = Color.white;
        LuzAlavanca.intensity = intensidadeLonge;

        for (int x = 0; x < LuzPorta.Count; x++)
        {
            LuzPorta[x].color = CorAtivado;
            LuzPorta[x].intensity = intensidadeLonge;
        }
    }

    void OnTriggerEnter (Collider colisor)
    {
        if (colisor.tag == "Player")
        {
            TrocaIntensidadeAlavanca(intensidadePerto);
        }
    }

    void OnTriggerStay (Collider colisor)
    {
        if (colisor.CompareTag("Player"))
        {
            if (Input.GetButton(colisor.gameObject.GetComponent<Move>().playerIndice.ToString() + "B") &&  !estadoInterruptor)
                AtivarInterruptor();
        }
    }

    void OnTriggerExit (Collider colisor)
    {
        if (colisor.tag == "Player")
        {
            TrocaIntensidadeAlavanca(intensidadeLonge);
        }
    }

    public void AtivarInterruptor()
    {
        print("Ativando interruptor");
        estadoInterruptor = true;
        LuzAlavanca.color = CorAtivado;
        anim.SetInteger("Alavanca", (int)Alavanca.Ativar);
        for (int x = 0; x < Portas.Length; x++)
        {
            Portas[x].GetComponent<Animator>().SetBool("Abrir", true);
            SFX.PlayOneShot(somAlavanca);
        }
    }

    public void TrocaIntensidadeAlavanca(float i)
    {
        LuzAlavanca.intensity = i;
    }
}