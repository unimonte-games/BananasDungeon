using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mapeamentos : MonoBehaviour
{
    [System.Serializable]
    public struct Mapeamento
    {
        public string Modelo;
        public int Porcentagem;
    }
    
    public Mapeamento[] Maps;

    void Start()
    {
        int soma = 0;
        for (int x = 0; x < Maps.Length; x++)
        {
            soma += Maps[x].Porcentagem;
        }

        if (soma != 100)
            Debug.LogError("As somas das porcentagens devem somar 100", gameObject);
    }
}