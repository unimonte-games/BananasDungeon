using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Espinhos : MonoBehaviour
{
    public List<Alvo> Alvos = new List<Alvo>();

    public struct Alvo
    {
        public GameObject gbj;
        public bool dano;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Enemy"))
        {
            Alvo aux = new Alvo();
            aux.gbj = other.gameObject;
            aux.dano = true;
            
            Alvos.Add(aux);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Enemy"))
        {
            for (int x = 0; x < Alvos.Count; x++)
            {
                if (Alvos[x].dano)
                {
                    var aux = Alvos[x];
                    Alvos.Remove(aux);
                    aux.dano = false;
                    Alvos.Add(aux);
                    StartCoroutine(DanoEspinho(aux));
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Enemy"))
        {
            for (int x = 0; x < Alvos.Count; x++)
            {
                if (other.gameObject == Alvos[x].gbj)
                {
                    Alvos.Remove(Alvos[x]);
                    break;
                }
            }
        }        
    }

    IEnumerator DanoEspinho(Alvo alvo)
    {
        var atributos = alvo.gbj.GetComponent<Atributos>();
        if (atributos.Vida > 0)
        {
            CalculoDano(alvo, atributos);
        }
        yield return new WaitForSeconds(transform.GetComponentInParent<ControledeTrap>().delayDano);
        var aux = alvo;
        Alvos.Remove(aux);
        aux.dano = true;
        Alvos.Add(aux);
    }

    public void CalculoDano(Alvo alvo, Atributos atb)
    {
        var ctr = gameObject.transform.GetComponentInParent<ControledeTrap>();
        switch (ctr.Tipo)
        {
            case ControledeTrap.TipoDano.Fixo:
                atb.vidaAtual -= (int)ctr.danoFixo;
                break;
            case ControledeTrap.TipoDano.Percentual:
                print("( ( " + ctr.danoPercentual + " / " + "100" + " ) " +  " * " + atb.Vida + " ) " + " = " + (int)((ctr.danoPercentual / 100) * atb.Vida));
                print("( ( " + (ctr.danoPercentual / 100) +  " * " + atb.Vida + " ) " + " = " + (int)((ctr.danoPercentual / 100) * atb.Vida));
                
                float dano = ((ctr.danoPercentual / 100) * atb.Vida);
                atb.vidaAtual -= (int)dano;
                print((int)((ctr.danoPercentual / 100) * atb.Vida));
                break;
        }
    }
}