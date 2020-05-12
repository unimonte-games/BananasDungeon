using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DadosPlayer : MonoBehaviour
{
    public int Vida = 1000;
    public Slider barraVida;

    void Update()
    {
        barraVida.value = Vida;
    }
}