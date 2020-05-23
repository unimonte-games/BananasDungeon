using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Espinhos : MonoBehaviour
{
    public List<GameObject> Alvos = new List<GameObject>();

    [System.Serializable]
    public struct Alvo
    {
        public GameObject gbj;
        public bool dano;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Enemy"))
        {
            Alvos.Add(other.gameObject);
            StartCoroutine(DanoEspinho(other.gameObject));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Enemy"))
        {
            if (Alvos.Contains(other.gameObject))
                Alvos.Remove(other.gameObject);
        }
    }

    IEnumerator DanoEspinho(GameObject alvo)
    {
        var atributos = alvo.GetComponent<Atributos>();
        if (atributos.Vida > 0)
        {
            AplicarDano(atributos);
        }
        yield return new WaitForSeconds(transform.GetComponentInParent<ControledeTrap>().delayDano);
        if (Alvos.Contains(alvo))
            StartCoroutine(DanoEspinho(alvo));
    }

    public void AplicarDano(Atributos atb)
    {
        var ctr = gameObject.transform.GetComponentInParent<ControledeTrap>();
        switch (ctr.Tipo)
        {
            case ControledeTrap.TipoDano.Fixo:
                atb.vidaAtual -= (int)ctr.danoFixo;
                break;
            case ControledeTrap.TipoDano.Percentual:
                float dano = ((ctr.danoPercentual / 100) * atb.Vida);
                atb.vidaAtual -= (int)dano;
                break;
        }
    }
}