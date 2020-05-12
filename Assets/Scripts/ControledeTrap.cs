using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControledeTrap : MonoBehaviour
{
    public float tempoAtivo;
    public float tempoDesativado;
    public GameObject espinhos;
    int estado = 1;

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
        print("levantando");
        do
        {
            espinhos.transform.position = new Vector3(espinhos.transform.position.x, espinhos.transform.position.y + .1f, espinhos.transform.position.z);
            yield return new WaitForSeconds(.01f);
        } while (espinhos.transform.position.y < 0);
        yield return new WaitForSeconds(tempoAtivo);
        estado = 2;
    }

    IEnumerator Desativar()
    {
        print("abaixando");
        do
        {
            espinhos.transform.position = new Vector3(espinhos.transform.position.x, espinhos.transform.position.y - .05f, espinhos.transform.position.z);
            yield return new WaitForSeconds(.01f);
        } while (espinhos.transform.position.y > -1.15);
        yield return new WaitForSeconds(tempoDesativado);
        estado = 1;
    }
}