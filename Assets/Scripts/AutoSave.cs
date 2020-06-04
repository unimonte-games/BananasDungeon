using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoSave : MonoBehaviour
{
    public Dados.Armas[] Armas;
    public PlayerArma[] ArmaPadrao;

    public static List<ArmaNivel> ArmasNiveis = new List<ArmaNivel>();
    public struct ArmaNivel
    {
        public Dados.Armas arma;
        public Dados.ArmaNivel nivel;
    }
    public static List<PlayerArma> PlayersArmas = new List<PlayerArma>();
    [System.Serializable]
    public struct PlayerArma
    {
        public Dados.Personagens player;
        public Dados.Armas arma;
    }

    void Awake()
    {
        if (PlayersArmas.Count != 0)
            return;

        //sanguineo
        //pergaminho da arma

        for (int x = 0; x < ArmaPadrao.Length; x++)
        {
            if (!PlayerPrefs.HasKey(ArmaPadrao[x].player.ToString() + "Arma"))
            {
                PlayerPrefs.SetInt(ArmaPadrao[x].player.ToString() + "Arma", (int)ArmaPadrao[x].arma);
                AddPlayerArma(ArmaPadrao[x].player, ArmaPadrao[x].arma);
            }
            else
            {
                int arma = PlayerPrefs.GetInt(ArmaPadrao[x].player.ToString() + "Arma");
                AddPlayerArma(ArmaPadrao[x].player, (Dados.Armas)arma);
            }
        }

        for (int x = 0; x < Armas.Length; x++)
        {
            if (!PlayerPrefs.HasKey(Armas[x].ToString() + "Nivel"))
            {
                PlayerPrefs.SetInt(Armas[x].ToString() + "Nivel", (int)Dados.ArmaNivel.Nivel1);
                AddNivelArma(Armas[x], Dados.ArmaNivel.Nivel1);
            }
            else
            {
                int nivel = PlayerPrefs.GetInt(Armas[x].ToString() + "Nivel");
                AddNivelArma(Armas[x], (Dados.ArmaNivel)nivel);
            }
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            print("LimpandoSave");
            PlayerPrefs.DeleteAll();
            print("SaveLimpo");
        }
    }

    public void AddPlayerArma(Dados.Personagens player, Dados.Armas arma)
    {
        PlayerArma p;
        p.player = player;
        p.arma = arma;
        PlayersArmas.Add(p);
    }

    public void AddNivelArma(Dados.Armas arma, Dados.ArmaNivel nivel)
    {
        ArmaNivel a;
        a.arma = arma;
        a.nivel = nivel;
        ArmasNiveis.Add(a);
    }

    public static Dados.Armas QualArma(Dados.Personagens personagem)
    {
        for (int x = 0; x < PlayersArmas.Count; x++)
        {
            if (PlayersArmas[x].player == personagem)
                return PlayersArmas[x].arma;
        }
        return Dados.Armas.Nenhum;
    }

    public static Dados.ArmaNivel QualNivel(Dados.Armas arma)
    {
        for (int x = 0; x < ArmasNiveis.Count; x++)
        {
            if (ArmasNiveis[x].arma == arma)
                return ArmasNiveis[x].nivel;
        }
        return Dados.ArmaNivel.Nivel1;
    }
}