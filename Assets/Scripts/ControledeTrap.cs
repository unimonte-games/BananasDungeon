using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControledeTrap : MonoBehaviour
{
    public float tempoAtivo;
    public float tempoDesativado;
    public float velSubida = .1f;
    public float velDescida = .05f;
    public float delayDano = 2f;
    public float danoFixo = 3;
    public float danoPercentual = 0;
    public TipoDano Tipo = TipoDano.Fixo;
    public GameObject espinhos;
    int estado = 1;
    [Space(20)]
    AudioSource SFX;
    public AudioClip TrapAcionando;

    public enum TipoDano
    {
        Percentual, Fixo
    }
    
    void Awake()
    {
        SFX = GameObject.Find("SFX").GetComponent<AudioSource>();
    }

    void Update()
    {
        switch (estado)
        {
            case 1:
                StartCoroutine(Ativar());
                estado = 0;
                break;
            case 2:
                StartCoroutine(Desativar());
                estado = 0;
                break;
        }
    }

    IEnumerator Ativar()
    {
        SFX.PlayOneShot(TrapAcionando);
        do
        {
            espinhos.transform.position = NormalizaSubindo(espinhos.transform.position, velSubida, 0);
            yield return new WaitForSeconds(.01f);
        } while (espinhos.transform.position.y < 0f);
        yield return new WaitForSeconds(tempoAtivo);
        estado = 2;
    }

    IEnumerator Desativar()
    {
        do
        {
            espinhos.transform.position = NormalizaDescendo(espinhos.transform.position, velDescida, -1.15f);
            yield return new WaitForSeconds(.01f);
        } while (espinhos.transform.position.y > -1.15f);
        yield return new WaitForSeconds(tempoDesativado);
        estado = 1;
    }

    Vector3 NormalizaDescendo(Vector3 valor, float variante, float limite)
    {
        var y = valor.y;
        y -= variante;
        y = y < limite ? limite : y;
        return new Vector3 (valor.x, y, valor.z);
    }

    Vector3 NormalizaSubindo(Vector3 valor, float variante, float limite)
    {
        var y = valor.y;
        y += variante;
        y = y > limite ? limite : y;
        return new Vector3 (valor.x, y, valor.z);
    }
}