using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControledeCenario : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            int i = GetComponentInParent<Modulo>().indice;
            if (gameObject.name == "Direita")
                ioMapaDireita(i);

            if (gameObject.name == "Esquerda")
                ioMapaEsquerda(i);
        }
    }

    void ioMapaDireita(int i)
    {
        if (i >= 2)
            GeradordeCenario.mapa[i - 2].SetActive(false);
        if (i < 12)
        {
            if (i + 1 > GeradordeCenario.mapa.Count - 1)
            {
                var pos = GetComponentInParent<Transform>().position;
                var gbj = Instantiate(GeradordeCenario.randomdoMapa[i + 1], new Vector3(pos.x + 100, 0, 0), Quaternion.identity);
                gbj.GetComponent<Modulo>().indice = i + 1;
                GeradordeCenario.mapa.Add(gbj);
            }
            else
                GeradordeCenario.mapa[i + 1].SetActive(true);
        }
        
    }

    void ioMapaEsquerda(int i)
    {
        if (GeradordeCenario.mapa.Count > 1)
        {
            if (i < GeradordeCenario.mapa.Count - 1)
                GeradordeCenario.mapa[i + 1].SetActive(false);
            if (i > 0)
                GeradordeCenario.mapa[i - 1].SetActive(true);
        }
    }
}