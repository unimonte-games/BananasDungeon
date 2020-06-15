using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradordeCenario : MonoBehaviour
{
    Mapeamentos Mapeamento;
    string Modelo;
    bool inicial = true;
    public GameObject[] inicio;
    public GameObject[] final;
    public GameObject[] bonus;
    public GameObject[] boss;
    public GameObject[] chekpoint;
    public GameObject[] mapas;
    public static List<GameObject> randomdoMapa = new List<GameObject>();
    public static List<GameObject> mapa = new List<GameObject>(); 

    void Awake()
    {
        Mapeamento = GetComponent<Mapeamentos>();
        RandomizaMapa();
    }

    string RandomizaModelo()
    {
        int r = Random.Range(0, 100);
        int acumulador = 0;
        for (int x = 0; x < Mapeamento.Maps.Length; x++)
        {
            acumulador += Mapeamento.Maps[x].Porcentagem;
            if (r <= acumulador)
                return Mapeamento.Maps[x].Modelo;
        }

        return  "";
    }

    void RandomizaMapa()
    {
        Modelo = RandomizaModelo();

        for (int x = 0; x < Modelo.Length; x++)
        {
            string i = Modelo.Substring(x, 1);
            switch (i)
            {
                case "1":
                    AddInicioFim();
                    break;
                case "0":
                    AddCheckpoint();
                    break;
                case "*":
                    AddBoss();
                    break;
                case "+":
                    AddBonus();
                    break;
                default:
                    AddMapa(int.Parse(i));
                    break;
            }
        }

        //printa o cenário randomizado
        // string maps = "MAPA: ";
        // for (int x = 0; x < randomdoMapa.Count; x++)
        // {
        //     maps += randomdoMapa[x].name + " ";
        // }
        // maps += "FIM DO MAPA";
        // print(maps);
    }
    
    void AddInicioFim()
    {
        if (inicial)
        {
            int rnd = Random.Range(0, inicio.Length - 1);
            randomdoMapa.Add(inicio[rnd]);
            inicial = false;
            var gbj = Instantiate(randomdoMapa[0], Vector3.zero, Quaternion.identity);
            mapa.Add(gbj);
            gbj.GetComponent<Modulo>().indice = 0;
        }
        else
        {
            int rnd = Random.Range(0, final.Length - 1);
            randomdoMapa.Add(final[rnd]);
        }
    }

    void AddCheckpoint()
    {
        int rndCkp = Random.Range(0, chekpoint.Length - 1);
        randomdoMapa.Add(chekpoint[rndCkp]);
    }

    void AddMapa(int q)
    {
        for (int x = 0; x < q; x++)
        {
            int rnd = Random.Range(0, mapas.Length - 1);
            randomdoMapa.Add(mapas[rnd]);
        }
    }

    void AddBoss()
    {
        int rnd = Random.Range(0, boss.Length - 1);
        randomdoMapa.Add(boss[rnd]);
    }
    
    void AddBonus()
    {
        int rnd = Random.Range(0, bonus.Length - 1);
        randomdoMapa.Add(bonus[rnd]);
    }
}