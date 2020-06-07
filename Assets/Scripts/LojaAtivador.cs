using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LojaAtivador : MonoBehaviour
{
    void Start()
    {
        print("Sou eu o zoobomafu!");
    }
    void OnTriggerEnter(Collider other)
    {
            print(other.gameObject.name);
            print(other.gameObject.tag);

        if (other.gameObject.CompareTag("Player"))
        {
            print(other.gameObject.name);
            print(other.gameObject.tag);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetButtonDown(other.GetComponent<Move>().playerIndice + "Y") && !Selecionados.LojaAberta && Selecionados.VezLoja == Dados.PlayerIndice.Vazio)
            {
                Selecionados.VezLoja = other.GetComponent<Move>().playerIndice;
                FindObjectOfType<Loja>().AbrirLoja(other.gameObject);
            }
        }
    }
}