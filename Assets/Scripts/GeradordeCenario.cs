using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradordeCenario : MonoBehaviour
{
    public GameObject inicio;
    public GameObject final;
    public GameObject[] chekpoint;
    public GameObject[] mapas;
    public static List<GameObject> randomdoMapa = new List<GameObject>();
    public static List<GameObject> mapa = new List<GameObject>();


    void Start()
    {
        RandomizaMapa();
        var gbj = Instantiate(inicio, Vector3.zero, Quaternion.identity);
        gbj.GetComponent<Modulo>().indice = 0;
        mapa.Add(gbj);
    }

    void RandomizaMapa()
    {
        randomdoMapa.Add(inicio);
        randomdoMapa.Add(mapas[0]);
        for (int x = 0; x < 4; x++)
        {
            int rnd = Random.Range(0, mapas.Length - 1);
            randomdoMapa.Add(mapas[rnd]);
        }
        int rndCkp = Random.Range(0, chekpoint.Length - 1);
        randomdoMapa.Add(chekpoint[rndCkp]);
        for (int x = 0; x < 5; x++)
        {
            int rnd = Random.Range(0, mapas.Length - 1);
            randomdoMapa.Add(mapas[rnd]);
        }
        randomdoMapa.Add(final);
        
        // printa o cenário randomizado
        // string maps = "MAPA: ";
        // for (int x = 0; x < randomdoMapa.Count; x++)
        // {
        //     maps += randomdoMapa[x].name + " ";
        // }
        // maps += "FIM DO MAPA";
        // print(maps);
    }
}