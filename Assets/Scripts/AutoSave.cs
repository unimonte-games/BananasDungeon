using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoSave : MonoBehaviour
{
    public static Dados.Armas[] Armas = { Dados.Armas.Arco, Dados.Armas.Espada, Dados.Armas.Machado};
    public static List<PlayerArma> ArmaPadrao = new List<PlayerArma>();

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

    public static int Sangue = 0;

    void Awake()
    {
        if (PlayersArmas.Count != 0)
            return;

        CarregarArmaPlayer();

        CarregarArmaNivel();

        CarregarSangue();

        //Pergaminhos das armas
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            print("Limpando save");
            PlayerPrefs.DeleteAll();
            print("Save limpo");
            CarregarArmaPlayer();
            CarregarArmaNivel();
            CarregarSangue();
            print("Save inicial");
        }
    }

    public static void AddPlayerArma(Dados.Personagens player, Dados.Armas arma)
    {
        PlayerArma p;
        p.player = player;
        p.arma = arma;
        PlayersArmas.Add(p);
    }

    public static void AddNivelArma(Dados.Armas arma, Dados.ArmaNivel nivel)
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

    public static void AtualizarSangue(int q, bool adicionar)
    {
        print("Tinha: " + Sangue);
        if (adicionar)
            Sangue += q;
        else
            Sangue -= q;
        print("Tem: " + Sangue);

        PlayerPrefs.SetInt("Sangue", Sangue);
    }

    public static void AtualizarNivelArma(Dados.Armas arma)
    {
        for (int x = 0; x < ArmasNiveis.Count; x++)
        {
            if (ArmasNiveis[x].arma == arma)
            {
                PlayerPrefs.SetInt(arma.ToString() + "Nivel", (int)ArmasNiveis[x].nivel);
            }
        }
        CarregarArmaNivel();
    }

    public static void AtualizarArma(Dados.Personagens perso, Dados.Armas gun)
    {
        PlayerPrefs.SetInt(perso.ToString() + "Arma", (int)gun);
        CarregarArmaPlayer();
    }

    static void CarregarArmaPlayer()
    {
        PlayerArma Oliver;
        Oliver.player = Dados.Personagens.Oliver;
        Oliver.arma = Dados.Armas.Machado;

        PlayerArma Amazona;
        Amazona.player = Dados.Personagens.Amazona;
        Amazona.arma = Dados.Armas.Arco;
        ArmaPadrao.Add(Oliver);
        ArmaPadrao.Add(Amazona);

        PlayersArmas.Clear();
        for (int x = 0; x < ArmaPadrao.Count; x++)
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
    }

    static void CarregarArmaNivel()
    {
        ArmasNiveis.Clear();
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

    void CarregarSangue()
    {
        if (!PlayerPrefs.HasKey("Sangue"))
        {
            PlayerPrefs.SetInt("Nivel", 0);
            Sangue = 0;
        }
        else
        {
            int saldo = PlayerPrefs.GetInt("Sangue");
            Sangue = saldo;
        }
    }
}