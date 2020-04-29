using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Modulo : MonoBehaviour
{
    public enum ModuloTipo { inicio, final, checkpoint, mapa, bonus, boss};
    public ModuloTipo Tipo;
    public int indice;
}