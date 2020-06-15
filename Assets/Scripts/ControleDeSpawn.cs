using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleDeSpawn : MonoBehaviour
{
    public Horda[] Hordas;
    public bool ativo = false;

    void Awake()
    {
        GetComponent<MeshRenderer>().enabled = false;
        for (int x = 0; x < Hordas.Length; x++)
        {
            for (int y = 0; y < Hordas[x].Spawns.Length; y++)
            {
                Hordas[x].Spawns[y].GetComponent<MeshRenderer>().enabled = false;
            }
        }
    }

    [System.Serializable]
    public struct Horda
    {
        public Spawn[] Spawns;
        public float delayEntreHordas;
    }

    void OnTriggerEnter(Collider quem)
    {
        if (quem.tag == "Player" && !ativo)
        {
            ativo = true;
            ativaHorda();
        }
    }

    void ativaHorda()
    {
        StartCoroutine(AtivandoHordas());
    }

    IEnumerator AtivandoHordas()
    {
        for (int x = 0; x < Hordas.Length; x++)
        {
            for (int s = 0; s < Hordas[x].Spawns.Length; s++)
            {
                StartCoroutine(Hordas[x].Spawns[s].IniciaSpawn());
            }
            yield return new WaitForSeconds(Hordas[x].delayEntreHordas);
        }
    }
}