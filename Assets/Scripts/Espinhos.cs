using System.Collections;
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
            AplicarDano(other.gameObject);
        }
    }

    public void AplicarDano(GameObject alvo)
    {
        var atb = alvo.GetComponent<Atributos>();
        switch (ctr.Tipo)
        {
            case ControledeTrap.TipoDano.Fixo:
                atb.CausarDano((int)ctr.danoFixo);
                break;
            case ControledeTrap.TipoDano.Percentual:
                float dano = ((ctr.danoPercentual / 100) * atb.Vida);
                atb.CausarDano((int)dano);
                break;
        }
    }
}