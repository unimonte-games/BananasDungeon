using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Modulo : MonoBehaviour
{
    public enum ModuloTipo { inicio, final, checkpoint, mapa};
    public ModuloTipo Tipo;
    public int indice;
    public PontodeSpawn[] spawns;


    void Awake()
    {
        spawns = GetComponentsInChildren<PontodeSpawn>();
    }
}