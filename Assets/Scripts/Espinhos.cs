﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Espinhos : MonoBehaviour
{
    public List<GameObject> Alvos = new List<GameObject>();
    float timer = 0;
    ControledeTrap ctr;
    [System.Serializable]
    public struct Alvo
    {
        public GameObject gbj;
        public bool dano;
    }

    void Awake()
    {
        ctr = GetComponentInParent<ControledeTrap>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Enemy"))
        {
            Alvos.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Enemy"))
        {
            if (Alvos.Contains(other.gameObject))
                Alvos.Remove(other.gameObject);
            if (Alvos.Count == 0)
                timer = 0;
        }
    }

    void OnTriggerStay(Collider col)
    {
        if (Alvos.Count > 0)
            timer += Time.deltaTime;
        else
            return;
        
        if (timer >= ctr.delayDano)
        {
            for (int x = 0; x < Alvos.Count; x++)
            {
                AplicarDano(Alvos[x]);
            }
            timer = 0;
        }
    }

    public void AplicarDano(GameObject alvo)
    {
        var atb = alvo.GetComponent<Atributos>();
        switch (ctr.Tipo)
        {
            case ControledeTrap.TipoDano.Fixo:
                atb.CausarDano(Dados.Armas.Nenhum, (int)ctr.danoFixo);
                break;
            case ControledeTrap.TipoDano.Percentual:
                float dano = ((ctr.danoPercentual / 100) * atb.Vida);
                atb.CausarDano(Dados.Armas.Nenhum, (int)dano);
                break;
        }
    }
}