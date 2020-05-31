using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoSave : MonoBehaviour
{
    public enum Players
    {
        Nenhum,
        Amazona,
        Oliver
    }
    public static List<ArmaNivel> ArmasNiveis = new List<ArmaNivel>();
    public struct ArmaNivel
    {
        public ControleDeArmas.Armas arma;
        public NivelArma.Nivel nivel;
    }
    public static List<PlayerArma> PlayersArmas = new List<PlayerArma>();
    public struct PlayerArma
    {
        public Players player;
        public ControleDeArmas arma;
    }

    void Awake()
    {
        if (PlayerPrefs.HasKey(Players.Amazona.ToString()))
            print("Amazona iniciada");

        if (PlayerPrefs.HasKey(Players.Oliver.ToString()))
            print("Oliver iniciada");
    }
}