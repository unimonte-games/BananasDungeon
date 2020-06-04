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

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            DefinirNivel(Dados.ArmaNivel.Nivel1);
        if (Input.GetKeyDown(KeyCode.Alpha2))
            DefinirNivel(Dados.ArmaNivel.Nivel2);
        if (Input.GetKeyDown(KeyCode.Alpha3))
            DefinirNivel(Dados.ArmaNivel.Nivel3);
        if (Input.GetKeyDown(KeyCode.Alpha4))
            DefinirNivel(Dados.ArmaNivel.Nivel4);
        if (Input.GetKeyDown(KeyCode.Alpha5))
            DefinirNivel(Dados.ArmaNivel.Nivel5);
    }

    public float DefinirNivel(Dados.ArmaNivel nivel)
    {
        print("Arma: " + arma.ToString() + " Nível: " + nivel.ToString());
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
                NiveisArma[0].nivel.SetActive(true);
                NiveisArma[1].nivel.SetActive(false);
                NiveisArma[2].nivel.SetActive(false);
                NiveisArma[3].nivel.SetActive(false);
                NiveisArma[4].nivel.SetActive(false);
                break;
            case Dados.ArmaNivel.Nivel2:
                NiveisArma[0].nivel.SetActive(true);
                NiveisArma[1].nivel.SetActive(true);
                NiveisArma[2].nivel.SetActive(false);
                NiveisArma[3].nivel.SetActive(false);
                NiveisArma[4].nivel.SetActive(false);
                break;
            case Dados.ArmaNivel.Nivel3:
                NiveisArma[0].nivel.SetActive(true);
                NiveisArma[1].nivel.SetActive(true);
                NiveisArma[2].nivel.SetActive(true);
                NiveisArma[3].nivel.SetActive(false);
                NiveisArma[4].nivel.SetActive(false);
                break;
            case Dados.ArmaNivel.Nivel4:
                NiveisArma[0].nivel.SetActive(true);
                NiveisArma[1].nivel.SetActive(true);
                NiveisArma[2].nivel.SetActive(true);
                NiveisArma[3].nivel.SetActive(true);
                NiveisArma[4].nivel.SetActive(false);
                break;
            case Dados.ArmaNivel.Nivel5:
                NiveisArma[0].nivel.SetActive(true);
                NiveisArma[1].nivel.SetActive(true);
                NiveisArma[2].nivel.SetActive(true);
                NiveisArma[3].nivel.SetActive(true);
                NiveisArma[4].nivel.SetActive(true);
                break;
        }
    }

    void NivelArco(Dados.ArmaNivel nivel)
    {
        switch (nivel)
        {
            case Dados.ArmaNivel.Nivel1:
                NiveisArma[0].nivel.SetActive(true);
                NiveisArma[1].nivel.SetActive(false);
                NiveisArma[2].nivel.SetActive(false);
                NiveisArma[3].nivel.SetActive(false);
                NiveisArma[4].nivel.SetActive(false);
                break;
            case Dados.ArmaNivel.Nivel2:
                NiveisArma[0].nivel.SetActive(true);
                NiveisArma[1].nivel.SetActive(true);
                NiveisArma[2].nivel.SetActive(false);
                NiveisArma[3].nivel.SetActive(false);
                NiveisArma[4].nivel.SetActive(false);
                break;
            case Dados.ArmaNivel.Nivel3:
                NiveisArma[0].nivel.SetActive(true);
                NiveisArma[1].nivel.SetActive(true);
                NiveisArma[2].nivel.SetActive(true);
                NiveisArma[3].nivel.SetActive(false);
                NiveisArma[4].nivel.SetActive(false);
                break;
            case Dados.ArmaNivel.Nivel4:
                NiveisArma[0].nivel.SetActive(true);
                NiveisArma[1].nivel.SetActive(true);
                NiveisArma[2].nivel.SetActive(true);
                NiveisArma[3].nivel.SetActive(true);
                NiveisArma[4].nivel.SetActive(false);
                break;
            case Dados.ArmaNivel.Nivel5:
                NiveisArma[0].nivel.SetActive(true);
                NiveisArma[1].nivel.SetActive(true);
                NiveisArma[2].nivel.SetActive(true);
                NiveisArma[3].nivel.SetActive(true);
                NiveisArma[4].nivel.SetActive(true);
                break;
        }
    }
    
    void NivelCajado(Dados.ArmaNivel nivel)
    {
        switch (nivel)
        {
            case Dados.ArmaNivel.Nivel1:
                NiveisArma[0].nivel.SetActive(true);
                NiveisArma[1].nivel.SetActive(false);
                NiveisArma[2].nivel.SetActive(false);
                NiveisArma[3].nivel.SetActive(false);
                NiveisArma[4].nivel.SetActive(false);
                break;
            case Dados.ArmaNivel.Nivel2:
                NiveisArma[0].nivel.SetActive(true);
                NiveisArma[1].nivel.SetActive(true);
                NiveisArma[2].nivel.SetActive(false);
                NiveisArma[3].nivel.SetActive(false);
                NiveisArma[4].nivel.SetActive(false);
                break;
            case Dados.ArmaNivel.Nivel3:
                NiveisArma[0].nivel.SetActive(true);
                NiveisArma[1].nivel.SetActive(true);
                NiveisArma[2].nivel.SetActive(true);
                NiveisArma[3].nivel.SetActive(false);
                NiveisArma[4].nivel.SetActive(false);
                break;
            case Dados.ArmaNivel.Nivel4:
                NiveisArma[0].nivel.SetActive(true);
                NiveisArma[1].nivel.SetActive(true);
                NiveisArma[2].nivel.SetActive(true);
                NiveisArma[3].nivel.SetActive(true);
                NiveisArma[4].nivel.SetActive(false);
                break;
            case Dados.ArmaNivel.Nivel5:
                NiveisArma[0].nivel.SetActive(true);
                NiveisArma[1].nivel.SetActive(true);
                NiveisArma[2].nivel.SetActive(true);
                NiveisArma[3].nivel.SetActive(true);
                NiveisArma[4].nivel.SetActive(true);
                break;
        }
    }

    void NivelMachado(Dados.ArmaNivel nivel)
    {
        switch (nivel)
        {
            case Dados.ArmaNivel.Nivel1:
                NiveisArma[0].nivel.SetActive(true);
                NiveisArma[1].nivel.SetActive(false);
                NiveisArma[2].nivel.SetActive(false);
                NiveisArma[3].nivel.SetActive(false);
                NiveisArma[4].nivel.SetActive(false);
                break;
            case Dados.ArmaNivel.Nivel2:
                NiveisArma[0].nivel.SetActive(true);
                NiveisArma[1].nivel.SetActive(true);
                NiveisArma[2].nivel.SetActive(false);
                NiveisArma[3].nivel.SetActive(false);
                NiveisArma[4].nivel.SetActive(false);
                break;
            case Dados.ArmaNivel.Nivel3:
                NiveisArma[0].nivel.SetActive(true);
                NiveisArma[1].nivel.SetActive(false);
                NiveisArma[2].nivel.SetActive(true);
                NiveisArma[3].nivel.SetActive(false);
                NiveisArma[4].nivel.SetActive(false);
                break;
            case Dados.ArmaNivel.Nivel4:
                NiveisArma[0].nivel.SetActive(true);
                NiveisArma[1].nivel.SetActive(false);
                NiveisArma[2].nivel.SetActive(true);
                NiveisArma[3].nivel.SetActive(true);
                NiveisArma[4].nivel.SetActive(false);
                break;
            case Dados.ArmaNivel.Nivel5:
                NiveisArma[0].nivel.SetActive(true);
                NiveisArma[1].nivel.SetActive(false);
                NiveisArma[2].nivel.SetActive(true);
                NiveisArma[3].nivel.SetActive(true);
                NiveisArma[4].nivel.SetActive(true);
                break;
        }
    }

    void NivelEspada(Dados.ArmaNivel nivel)
    {
        switch (nivel)
        {
            case Dados.ArmaNivel.Nivel1:
                NiveisArma[0].nivel.SetActive(true);
                NiveisArma[1].nivel.SetActive(false);
                NiveisArma[2].nivel.SetActive(false);
                NiveisArma[3].nivel.SetActive(false);
                NiveisArma[4].nivel.SetActive(false);
                break;
            case Dados.ArmaNivel.Nivel2:
                NiveisArma[0].nivel.SetActive(false);
                NiveisArma[1].nivel.SetActive(true);
                NiveisArma[2].nivel.SetActive(false);
                NiveisArma[3].nivel.SetActive(false);
                NiveisArma[4].nivel.SetActive(false);
                break;
            case Dados.ArmaNivel.Nivel3:
                NiveisArma[0].nivel.SetActive(false);
                NiveisArma[1].nivel.SetActive(true);
                NiveisArma[2].nivel.SetActive(true);
                NiveisArma[3].nivel.SetActive(false);
                NiveisArma[4].nivel.SetActive(false);
                break;
            case Dados.ArmaNivel.Nivel4:
                NiveisArma[0].nivel.SetActive(false);
                NiveisArma[1].nivel.SetActive(true);
                NiveisArma[2].nivel.SetActive(true);
                NiveisArma[3].nivel.SetActive(true);
                NiveisArma[4].nivel.SetActive(false);
                break;
            case Dados.ArmaNivel.Nivel5:
                NiveisArma[0].nivel.SetActive(false);
                NiveisArma[1].nivel.SetActive(true);
                NiveisArma[2].nivel.SetActive(true);
                NiveisArma[3].nivel.SetActive(true);
                NiveisArma[4].nivel.SetActive(true);
                break;
        }
    }

    void NivelLanca(Dados.ArmaNivel nivel)
    {
        switch (nivel)
        {
            case Dados.ArmaNivel.Nivel1:
                NiveisArma[0].nivel.SetActive(true);
                NiveisArma[1].nivel.SetActive(false);
                NiveisArma[2].nivel.SetActive(false);
                NiveisArma[3].nivel.SetActive(false);
                NiveisArma[4].nivel.SetActive(false);
                break;
            case Dados.ArmaNivel.Nivel2:
                NiveisArma[0].nivel.SetActive(true);
                NiveisArma[1].nivel.SetActive(true);
                NiveisArma[2].nivel.SetActive(false);
                NiveisArma[3].nivel.SetActive(false);
                NiveisArma[4].nivel.SetActive(false);
                break;
            case Dados.ArmaNivel.Nivel3:
                NiveisArma[0].nivel.SetActive(true);
                NiveisArma[1].nivel.SetActive(true);
                NiveisArma[2].nivel.SetActive(true);
                NiveisArma[3].nivel.SetActive(false);
                NiveisArma[4].nivel.SetActive(false);
                break;
            case Dados.ArmaNivel.Nivel4:
                NiveisArma[0].nivel.SetActive(true);
                NiveisArma[1].nivel.SetActive(true);
                NiveisArma[2].nivel.SetActive(false);
                NiveisArma[3].nivel.SetActive(true);
                NiveisArma[4].nivel.SetActive(false);
                break;
            case Dados.ArmaNivel.Nivel5:
                NiveisArma[0].nivel.SetActive(true);
                NiveisArma[1].nivel.SetActive(true);
                NiveisArma[2].nivel.SetActive(false);
                NiveisArma[3].nivel.SetActive(true);
                NiveisArma[4].nivel.SetActive(true);
                break;
        }
    }

}