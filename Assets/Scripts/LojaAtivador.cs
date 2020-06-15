using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LojaAtivador : MonoBehaviour
{
    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
            if (Input.GetButtonDown(other.GetComponent<Move>().playerIndice + "Y") && !Selecionados.LojaAberta && Selecionados.VezLoja == Dados.PlayerIndice.Vazio)
                FindObjectOfType<Loja>().AbrirLoja(other.gameObject);
    }
}