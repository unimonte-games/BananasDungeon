using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NivelArma : MonoBehaviour
{
    public Niveis NiveisArma;

    public enum Nivel
    {
        Nivel1, Nivel2, Nivel3, Nivel4, Nivel5
    }

    [System.Serializable]
    public struct Niveis
    {
        public ControleDeArmas.Armas arma;
        public GameObject[] nivel;
    }

    public void DefinirNivel(Nivel nivel)
    {
        switch (NiveisArma.arma)
        {
            case ControleDeArmas.Armas.Arco:
                NivelArco(nivel);
                break;
            case ControleDeArmas.Armas.Espada:
                NivelEspada(nivel);
                break;
            case ControleDeArmas.Armas.Machado:
                NivelMachado(nivel);
                break;
            case ControleDeArmas.Armas.Alabarda:
                NivelAlabarda(nivel);
                break;
            case ControleDeArmas.Armas.Cajado:
                NivelCajado(nivel);
                break;
            case ControleDeArmas.Armas.Lanca:
                NivelLanca(nivel);
                break;
        }
    }

    void NivelAlabarda(Nivel nivel)
    {
        switch (nivel)
        {
            case Nivel.Nivel1:
                NiveisArma.nivel[0].SetActive(true);
                NiveisArma.nivel[1].SetActive(false);
                NiveisArma.nivel[2].SetActive(false);
                NiveisArma.nivel[3].SetActive(false);
                //NiveisArma.nivel[4].SetActive(false);
                break;
            case Nivel.Nivel2:
                NiveisArma.nivel[0].SetActive(true);
                NiveisArma.nivel[1].SetActive(true);
                NiveisArma.nivel[2].SetActive(false);
                NiveisArma.nivel[3].SetActive(false);
                //NiveisArma.nivel[4].SetActive(false);
                break;
            case Nivel.Nivel3:
                NiveisArma.nivel[0].SetActive(true);
                NiveisArma.nivel[1].SetActive(true);
                NiveisArma.nivel[2].SetActive(true);
                NiveisArma.nivel[3].SetActive(false);
                //NiveisArma.nivel[4].SetActive(false);
                break;
            case Nivel.Nivel4:
                NiveisArma.nivel[0].SetActive(true);
                NiveisArma.nivel[1].SetActive(true);
                NiveisArma.nivel[2].SetActive(true);
                NiveisArma.nivel[3].SetActive(true);
                //NiveisArma.nivel[4].SetActive(false);
                break;
            case Nivel.Nivel5:
                NiveisArma.nivel[0].SetActive(true);
                NiveisArma.nivel[1].SetActive(true);
                NiveisArma.nivel[2].SetActive(true);
                NiveisArma.nivel[3].SetActive(true);
                //NiveisArma.nivel[4].SetActive(true);
                break;
        }
    }

    void NivelArco(Nivel nivel)
    {
        switch (nivel)
        {
            case Nivel.Nivel1:
                NiveisArma.nivel[0].SetActive(true);
                NiveisArma.nivel[1].SetActive(false);
                NiveisArma.nivel[2].SetActive(false);
                NiveisArma.nivel[3].SetActive(false);
                //NiveisArma.nivel[4].SetActive(false);
                break;
            case Nivel.Nivel2:
                NiveisArma.nivel[0].SetActive(true);
                NiveisArma.nivel[1].SetActive(true);
                NiveisArma.nivel[2].SetActive(false);
                NiveisArma.nivel[3].SetActive(false);
                //NiveisArma.nivel[4].SetActive(false);
                break;
            case Nivel.Nivel3:
                NiveisArma.nivel[0].SetActive(true);
                NiveisArma.nivel[1].SetActive(true);
                NiveisArma.nivel[2].SetActive(true);
                NiveisArma.nivel[3].SetActive(false);
                //NiveisArma.nivel[4].SetActive(false);
                break;
            case Nivel.Nivel4:
                NiveisArma.nivel[0].SetActive(true);
                NiveisArma.nivel[1].SetActive(true);
                NiveisArma.nivel[2].SetActive(true);
                NiveisArma.nivel[3].SetActive(true);
                //NiveisArma.nivel[4].SetActive(false);
                break;
            case Nivel.Nivel5:
                NiveisArma.nivel[0].SetActive(true);
                NiveisArma.nivel[1].SetActive(true);
                NiveisArma.nivel[2].SetActive(true);
                NiveisArma.nivel[3].SetActive(true);
                //NiveisArma.nivel[4].SetActive(true);
                break;
        }
    }
    
    void NivelCajado(Nivel nivel)
    {
        switch (nivel)
        {
            case Nivel.Nivel1:
                NiveisArma.nivel[0].SetActive(true);
                NiveisArma.nivel[1].SetActive(false);
                NiveisArma.nivel[2].SetActive(false);
                NiveisArma.nivel[3].SetActive(false);
                //NiveisArma.nivel[4].SetActive(false);
                break;
            case Nivel.Nivel2:
                NiveisArma.nivel[0].SetActive(true);
                NiveisArma.nivel[1].SetActive(true);
                NiveisArma.nivel[2].SetActive(false);
                NiveisArma.nivel[3].SetActive(false);
                //NiveisArma.nivel[4].SetActive(false);
                break;
            case Nivel.Nivel3:
                NiveisArma.nivel[0].SetActive(true);
                NiveisArma.nivel[1].SetActive(true);
                NiveisArma.nivel[2].SetActive(true);
                NiveisArma.nivel[3].SetActive(false);
                //NiveisArma.nivel[4].SetActive(false);
                break;
            case Nivel.Nivel4:
                NiveisArma.nivel[0].SetActive(true);
                NiveisArma.nivel[1].SetActive(true);
                NiveisArma.nivel[2].SetActive(true);
                NiveisArma.nivel[3].SetActive(true);
                //NiveisArma.nivel[4].SetActive(false);
                break;
            case Nivel.Nivel5:
                NiveisArma.nivel[0].SetActive(true);
                NiveisArma.nivel[1].SetActive(true);
                NiveisArma.nivel[2].SetActive(true);
                NiveisArma.nivel[3].SetActive(true);
                //NiveisArma.nivel[4].SetActive(true);
                break;
        }
    }

    void NivelMachado(Nivel nivel)
    {
        switch (nivel)
        {
            case Nivel.Nivel1:
                NiveisArma.nivel[0].SetActive(true);
                NiveisArma.nivel[1].SetActive(false);
                NiveisArma.nivel[2].SetActive(false);
                NiveisArma.nivel[3].SetActive(false);
                //NiveisArma.nivel[4].SetActive(false);
                break;
            case Nivel.Nivel2:
                NiveisArma.nivel[0].SetActive(true);
                NiveisArma.nivel[1].SetActive(true);
                NiveisArma.nivel[2].SetActive(false);
                NiveisArma.nivel[3].SetActive(false);
                //NiveisArma.nivel[4].SetActive(false);
                break;
            case Nivel.Nivel3:
                NiveisArma.nivel[0].SetActive(true);
                NiveisArma.nivel[1].SetActive(false);
                NiveisArma.nivel[2].SetActive(true);
                NiveisArma.nivel[3].SetActive(false);
                //NiveisArma.nivel[4].SetActive(false);
                break;
            case Nivel.Nivel4:
                NiveisArma.nivel[0].SetActive(true);
                NiveisArma.nivel[1].SetActive(false);
                NiveisArma.nivel[2].SetActive(true);
                NiveisArma.nivel[3].SetActive(true);
                //NiveisArma.nivel[4].SetActive(false);
                break;
            case Nivel.Nivel5:
                NiveisArma.nivel[0].SetActive(true);
                NiveisArma.nivel[1].SetActive(false);
                NiveisArma.nivel[2].SetActive(true);
                NiveisArma.nivel[3].SetActive(true);
                //NiveisArma.nivel[4].SetActive(true);
                break;
        }
    }

    void NivelEspada(Nivel nivel)
    {
        switch (nivel)
        {
            case Nivel.Nivel1:
                NiveisArma.nivel[0].SetActive(true);
                NiveisArma.nivel[1].SetActive(false);
                NiveisArma.nivel[2].SetActive(false);
                NiveisArma.nivel[3].SetActive(false);
                //NiveisArma.nivel[4].SetActive(false);
                break;
            case Nivel.Nivel2:
                NiveisArma.nivel[0].SetActive(false);
                NiveisArma.nivel[1].SetActive(true);
                NiveisArma.nivel[2].SetActive(false);
                NiveisArma.nivel[3].SetActive(false);
                //NiveisArma.nivel[4].SetActive(false);
                break;
            case Nivel.Nivel3:
                NiveisArma.nivel[0].SetActive(false);
                NiveisArma.nivel[1].SetActive(true);
                NiveisArma.nivel[2].SetActive(true);
                NiveisArma.nivel[3].SetActive(false);
                //NiveisArma.nivel[4].SetActive(false);
                break;
            case Nivel.Nivel4:
                NiveisArma.nivel[0].SetActive(false);
                NiveisArma.nivel[1].SetActive(true);
                NiveisArma.nivel[2].SetActive(true);
                NiveisArma.nivel[3].SetActive(true);
                //NiveisArma.nivel[4].SetActive(false);
                break;
            case Nivel.Nivel5:
                NiveisArma.nivel[0].SetActive(false);
                NiveisArma.nivel[1].SetActive(true);
                NiveisArma.nivel[2].SetActive(true);
                NiveisArma.nivel[3].SetActive(true);
                //NiveisArma.nivel[4].SetActive(true);
                break;
        }
    }

    void NivelLanca(Nivel nivel)
    {
        switch (nivel)
        {
            case Nivel.Nivel1:
                NiveisArma.nivel[0].SetActive(true);
                NiveisArma.nivel[1].SetActive(false);
                NiveisArma.nivel[2].SetActive(false);
                NiveisArma.nivel[3].SetActive(false);
                //NiveisArma.nivel[4].SetActive(false);
                break;
            case Nivel.Nivel2:
                NiveisArma.nivel[0].SetActive(true);
                NiveisArma.nivel[1].SetActive(true);
                NiveisArma.nivel[2].SetActive(false);
                NiveisArma.nivel[3].SetActive(false);
                //NiveisArma.nivel[4].SetActive(false);
                break;
            case Nivel.Nivel3:
                NiveisArma.nivel[0].SetActive(true);
                NiveisArma.nivel[1].SetActive(true);
                NiveisArma.nivel[2].SetActive(true);
                NiveisArma.nivel[3].SetActive(false);
                //NiveisArma.nivel[4].SetActive(false);
                break;
            case Nivel.Nivel4:
                NiveisArma.nivel[0].SetActive(true);
                NiveisArma.nivel[1].SetActive(true);
                NiveisArma.nivel[2].SetActive(false);
                NiveisArma.nivel[3].SetActive(true);
                //NiveisArma.nivel[4].SetActive(false);
                break;
            case Nivel.Nivel5:
                NiveisArma.nivel[0].SetActive(true);
                NiveisArma.nivel[1].SetActive(true);
                NiveisArma.nivel[2].SetActive(false);
                NiveisArma.nivel[3].SetActive(true);
                //NiveisArma.nivel[4].SetActive(true);
                break;
        }
    }
}