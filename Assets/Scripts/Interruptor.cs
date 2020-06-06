using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interruptor : MonoBehaviour
{
    public float intensidadePerto = 20;
    public float intensidadeLonge = 10;
    public GameObject[] Portas;
    List<Light> Luz =  new List<Light>();
    public Color CorAtivado = Color.white;
    bool estadoInterruptor = false;
    Animator anim;

    public enum Alavanca
    {
        Parado = 0,
        Ativar,
        Desativar//caso queiram q seja desativado
    }

    void Awake()
    {
        anim = GetComponent<Animator>();

        Luz.Add(GetComponentInChildren<Light>());
        for (int x = 0; x < Portas.Length; x++)
        {
            Luz.Add(Portas[x].GetComponentInParent<Light>());
        }

        for (int x = 0; x < Luz.Count; x++)
        {
            Luz[x].color = Color.white;
        }
    }

    void OnTriggerEnter (Collider colisor)
    {
        if (colisor.tag == "Player")
        {
            TrocaIntensidade(intensidadePerto);
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
            TrocaIntensidade(intensidadeLonge);
        }
    }

    public void AtivarInterruptor()
    {
        print("Ativando interruptor");
        estadoInterruptor = true;
        for (int x = 0; x < Luz.Count; x++)
        {
            Luz[x].color = CorAtivado;
        }
        anim.SetInteger("Alavanca", (int)Alavanca.Ativar);
        for (int x = 0; x < Portas.Length; x++)
        {
            Portas[x].GetComponent<Animator>().SetBool("Abrir", true);
        }
    }

    public void TrocaIntensidade(float i)
    {
        for (int x = 0; x < Luz.Count; x++)
        {
            Luz[x].intensity = i;
        }
    }
}