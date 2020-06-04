using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NivelArma : MonoBehaviour
{
    public Niveis[] NiveisArma;
    [Space(20)]
    public Dados.Armas arma;

    [System.Serializable]
    public struct Niveis
    {
        public GameObject nivel;
        public float multiplicador;
    }

    public float DefinirNivel(Dados.ArmaNivel nivel)
    {
        switch (arma)
        {
            case Dados.Armas.Alabarda:
                //NivelAlabarda(nivel);
                return NiveisArma[(int)nivel].multiplicador;
            case Dados.Armas.Arco:
                NivelArco(nivel);
                return NiveisArma[(int)nivel].multiplicador;
            case Dados.Armas.Cajado:
                //NivelCajado(nivel);
                return NiveisArma[(int)nivel].multiplicador;
            case Dados.Armas.Espada:
                NivelEspada(nivel);
                return NiveisArma[(int)nivel].multiplicador;
            case Dados.Armas.Lanca:
                //NivelLanca(nivel);
                return NiveisArma[(int)nivel].multiplicador;
            case Dados.Armas.Machado:
                NivelMachado(nivel);
                return NiveisArma[(int)nivel].multiplicador;
            default:
                return 1;
        }
    }

    void NivelAlabarda(Dados.ArmaNivel nivel)
    {
        switch (nivel)
        {
            case Dados.ArmaNivel.Nivel1:
                NiveisArma[(int)nivel].nivel.SetActive(true);
                NiveisArma[(int)nivel].nivel.SetActive(false);
                NiveisArma[(int)nivel].nivel.SetActive(false);
                NiveisArma[(int)nivel].nivel.SetActive(false);
                NiveisArma[(int)nivel].nivel.SetActive(false);
                break;
            case Dados.ArmaNivel.Nivel2:
                NiveisArma[(int)nivel].nivel.SetActive(true);
                NiveisArma[(int)nivel].nivel.SetActive(true);
                NiveisArma[(int)nivel].nivel.SetActive(false);
                NiveisArma[(int)nivel].nivel.SetActive(false);
                NiveisArma[(int)nivel].nivel.SetActive(false);
                break;
            case Dados.ArmaNivel.Nivel3:
                NiveisArma[(int)nivel].nivel.SetActive(true);
                NiveisArma[(int)nivel].nivel.SetActive(true);
                NiveisArma[(int)nivel].nivel.SetActive(true);
                NiveisArma[(int)nivel].nivel.SetActive(false);
                NiveisArma[(int)nivel].nivel.SetActive(false);
                break;
            case Dados.ArmaNivel.Nivel4:
                NiveisArma[(int)nivel].nivel.SetActive(true);
                NiveisArma[(int)nivel].nivel.SetActive(true);
                NiveisArma[(int)nivel].nivel.SetActive(true);
                NiveisArma[(int)nivel].nivel.SetActive(true);
                NiveisArma[(int)nivel].nivel.SetActive(false);
                break;
            case Dados.ArmaNivel.Nivel5:
                NiveisArma[(int)nivel].nivel.SetActive(true);
                NiveisArma[(int)nivel].nivel.SetActive(true);
                NiveisArma[(int)nivel].nivel.SetActive(true);
                NiveisArma[(int)nivel].nivel.SetActive(true);
                NiveisArma[(int)nivel].nivel.SetActive(true);
                break;
        }
    }

    void NivelArco(Dados.ArmaNivel nivel)
    {
        switch (nivel)
        {
            case Dados.ArmaNivel.Nivel1:
                NiveisArma[(int)nivel].nivel.SetActive(true);
                NiveisArma[(int)nivel].nivel.SetActive(false);
                NiveisArma[(int)nivel].nivel.SetActive(false);
                NiveisArma[(int)nivel].nivel.SetActive(false);
                NiveisArma[(int)nivel].nivel.SetActive(false);
                break;
            case Dados.ArmaNivel.Nivel2:
                NiveisArma[(int)nivel].nivel.SetActive(true);
                NiveisArma[(int)nivel].nivel.SetActive(true);
                NiveisArma[(int)nivel].nivel.SetActive(false);
                NiveisArma[(int)nivel].nivel.SetActive(false);
                NiveisArma[(int)nivel].nivel.SetActive(false);
                break;
            case Dados.ArmaNivel.Nivel3:
                NiveisArma[(int)nivel].nivel.SetActive(true);
                NiveisArma[(int)nivel].nivel.SetActive(true);
                NiveisArma[(int)nivel].nivel.SetActive(true);
                NiveisArma[(int)nivel].nivel.SetActive(false);
                NiveisArma[(int)nivel].nivel.SetActive(false);
                break;
            case Dados.ArmaNivel.Nivel4:
                NiveisArma[(int)nivel].nivel.SetActive(true);
                NiveisArma[(int)nivel].nivel.SetActive(true);
                NiveisArma[(int)nivel].nivel.SetActive(true);
                NiveisArma[(int)nivel].nivel.SetActive(true);
                NiveisArma[(int)nivel].nivel.SetActive(false);
                break;
            case Dados.ArmaNivel.Nivel5:
                NiveisArma[(int)nivel].nivel.SetActive(true);
                NiveisArma[(int)nivel].nivel.SetActive(true);
                NiveisArma[(int)nivel].nivel.SetActive(true);
                NiveisArma[(int)nivel].nivel.SetActive(true);
                NiveisArma[(int)nivel].nivel.SetActive(true);
                break;
        }
    }
    
    void NivelCajado(Dados.ArmaNivel nivel)
    {
        switch (nivel)
        {
            case Dados.ArmaNivel.Nivel1:
                NiveisArma[(int)nivel].nivel.SetActive(true);
                NiveisArma[(int)nivel].nivel.SetActive(false);
                NiveisArma[(int)nivel].nivel.SetActive(false);
                NiveisArma[(int)nivel].nivel.SetActive(false);
                NiveisArma[(int)nivel].nivel.SetActive(false);
                break;
            case Dados.ArmaNivel.Nivel2:
                NiveisArma[(int)nivel].nivel.SetActive(true);
                NiveisArma[(int)nivel].nivel.SetActive(true);
                NiveisArma[(int)nivel].nivel.SetActive(false);
                NiveisArma[(int)nivel].nivel.SetActive(false);
                NiveisArma[(int)nivel].nivel.SetActive(false);
                break;
            case Dados.ArmaNivel.Nivel3:
                NiveisArma[(int)nivel].nivel.SetActive(true);
                NiveisArma[(int)nivel].nivel.SetActive(true);
                NiveisArma[(int)nivel].nivel.SetActive(true);
                NiveisArma[(int)nivel].nivel.SetActive(false);
                NiveisArma[(int)nivel].nivel.SetActive(false);
                break;
            case Dados.ArmaNivel.Nivel4:
                NiveisArma[(int)nivel].nivel.SetActive(true);
                NiveisArma[(int)nivel].nivel.SetActive(true);
                NiveisArma[(int)nivel].nivel.SetActive(true);
                NiveisArma[(int)nivel].nivel.SetActive(true);
                NiveisArma[(int)nivel].nivel.SetActive(false);
                break;
            case Dados.ArmaNivel.Nivel5:
                NiveisArma[(int)nivel].nivel.SetActive(true);
                NiveisArma[(int)nivel].nivel.SetActive(true);
                NiveisArma[(int)nivel].nivel.SetActive(true);
                NiveisArma[(int)nivel].nivel.SetActive(true);
                NiveisArma[(int)nivel].nivel.SetActive(true);
                break;
        }
    }

    void NivelMachado(Dados.ArmaNivel nivel)
    {
        switch (nivel)
        {
            case Dados.ArmaNivel.Nivel1:
                NiveisArma[(int)nivel].nivel.SetActive(true);
                NiveisArma[(int)nivel].nivel.SetActive(false);
                NiveisArma[(int)nivel].nivel.SetActive(false);
                NiveisArma[(int)nivel].nivel.SetActive(false);
                NiveisArma[(int)nivel].nivel.SetActive(false);
                break;
            case Dados.ArmaNivel.Nivel2:
                NiveisArma[(int)nivel].nivel.SetActive(true);
                NiveisArma[(int)nivel].nivel.SetActive(true);
                NiveisArma[(int)nivel].nivel.SetActive(false);
                NiveisArma[(int)nivel].nivel.SetActive(false);
                NiveisArma[(int)nivel].nivel.SetActive(false);
                break;
            case Dados.ArmaNivel.Nivel3:
                NiveisArma[(int)nivel].nivel.SetActive(true);
                NiveisArma[(int)nivel].nivel.SetActive(false);
                NiveisArma[(int)nivel].nivel.SetActive(true);
                NiveisArma[(int)nivel].nivel.SetActive(false);
                NiveisArma[(int)nivel].nivel.SetActive(false);
                break;
            case Dados.ArmaNivel.Nivel4:
                NiveisArma[(int)nivel].nivel.SetActive(true);
                NiveisArma[(int)nivel].nivel.SetActive(false);
                NiveisArma[(int)nivel].nivel.SetActive(true);
                NiveisArma[(int)nivel].nivel.SetActive(true);
                NiveisArma[(int)nivel].nivel.SetActive(false);
                break;
            case Dados.ArmaNivel.Nivel5:
                NiveisArma[(int)nivel].nivel.SetActive(true);
                NiveisArma[(int)nivel].nivel.SetActive(false);
                NiveisArma[(int)nivel].nivel.SetActive(true);
                NiveisArma[(int)nivel].nivel.SetActive(true);
                NiveisArma[(int)nivel].nivel.SetActive(true);
                break;
        }
    }

    void NivelEspada(Dados.ArmaNivel nivel)
    {
        switch (nivel)
        {
            case Dados.ArmaNivel.Nivel1:
                NiveisArma[(int)nivel].nivel.SetActive(true);
                NiveisArma[(int)nivel].nivel.SetActive(false);
                NiveisArma[(int)nivel].nivel.SetActive(false);
                NiveisArma[(int)nivel].nivel.SetActive(false);
                NiveisArma[(int)nivel].nivel.SetActive(false);
                break;
            case Dados.ArmaNivel.Nivel2:
                NiveisArma[(int)nivel].nivel.SetActive(false);
                NiveisArma[(int)nivel].nivel.SetActive(true);
                NiveisArma[(int)nivel].nivel.SetActive(false);
                NiveisArma[(int)nivel].nivel.SetActive(false);
                NiveisArma[(int)nivel].nivel.SetActive(false);
                break;
            case Dados.ArmaNivel.Nivel3:
                NiveisArma[(int)nivel].nivel.SetActive(false);
                NiveisArma[(int)nivel].nivel.SetActive(true);
                NiveisArma[(int)nivel].nivel.SetActive(true);
                NiveisArma[(int)nivel].nivel.SetActive(false);
                NiveisArma[(int)nivel].nivel.SetActive(false);
                break;
            case Dados.ArmaNivel.Nivel4:
                NiveisArma[(int)nivel].nivel.SetActive(false);
                NiveisArma[(int)nivel].nivel.SetActive(true);
                NiveisArma[(int)nivel].nivel.SetActive(true);
                NiveisArma[(int)nivel].nivel.SetActive(true);
                NiveisArma[(int)nivel].nivel.SetActive(false);
                break;
            case Dados.ArmaNivel.Nivel5:
                NiveisArma[(int)nivel].nivel.SetActive(false);
                NiveisArma[(int)nivel].nivel.SetActive(true);
                NiveisArma[(int)nivel].nivel.SetActive(true);
                NiveisArma[(int)nivel].nivel.SetActive(true);
                NiveisArma[(int)nivel].nivel.SetActive(true);
                break;
        }
    }

    void NivelLanca(Dados.ArmaNivel nivel)
    {
        switch (nivel)
        {
            case Dados.ArmaNivel.Nivel1:
                NiveisArma[(int)nivel].nivel.SetActive(true);
                NiveisArma[(int)nivel].nivel.SetActive(false);
                NiveisArma[(int)nivel].nivel.SetActive(false);
                NiveisArma[(int)nivel].nivel.SetActive(false);
                NiveisArma[(int)nivel].nivel.SetActive(false);
                break;
            case Dados.ArmaNivel.Nivel2:
                NiveisArma[(int)nivel].nivel.SetActive(true);
                NiveisArma[(int)nivel].nivel.SetActive(true);
                NiveisArma[(int)nivel].nivel.SetActive(false);
                NiveisArma[(int)nivel].nivel.SetActive(false);
                NiveisArma[(int)nivel].nivel.SetActive(false);
                break;
            case Dados.ArmaNivel.Nivel3:
                NiveisArma[(int)nivel].nivel.SetActive(true);
                NiveisArma[(int)nivel].nivel.SetActive(true);
                NiveisArma[(int)nivel].nivel.SetActive(true);
                NiveisArma[(int)nivel].nivel.SetActive(false);
                NiveisArma[(int)nivel].nivel.SetActive(false);
                break;
            case Dados.ArmaNivel.Nivel4:
                NiveisArma[(int)nivel].nivel.SetActive(true);
                NiveisArma[(int)nivel].nivel.SetActive(true);
                NiveisArma[(int)nivel].nivel.SetActive(false);
                NiveisArma[(int)nivel].nivel.SetActive(true);
                NiveisArma[(int)nivel].nivel.SetActive(false);
                break;
            case Dados.ArmaNivel.Nivel5:
                NiveisArma[(int)nivel].nivel.SetActive(true);
                NiveisArma[(int)nivel].nivel.SetActive(true);
                NiveisArma[(int)nivel].nivel.SetActive(false);
                NiveisArma[(int)nivel].nivel.SetActive(true);
                NiveisArma[(int)nivel].nivel.SetActive(true);
                break;
        }
    }

}