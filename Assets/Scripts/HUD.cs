using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public GameObject[] BarraDeVida;
    public GameObject[] Personagens;

    public GameObject PegarBarra(Dados.PlayerIndice player)
    {
        BarraDeVida[(int)player - 1].SetActive(true);
        return BarraDeVida[(int)player - 1];
    }

    void Start()
    {
        print("Start HUD");
        print(Selecionados.Jogadores.Count);
        print(Personagens.Length);
        for (int x = 0; x < Selecionados.Jogadores.Count; x++)
        {
            print("teste1");
            print(Selecionados.Jogadores[x].personagem.ToString() + " " + x);
            for (int y = 0; y < Personagens.Length; y++)
            {
                print("teste2");
                print(Personagens[y].ToString() + " " + y);
                if (Selecionados.Jogadores[x].personagem == Personagens[y].GetComponent<Atributos>().Personagem)
                {
                    print("teste3");
                    Vector3 posInicial = Vector3.zero;
                    switch (Selecionados.Jogadores[x].playerIndice)
                    {
                        case Dados.PlayerIndice.P1:
                            posInicial += Vector3.forward * 2;
                            break;
                        case Dados.PlayerIndice.P2:
                            posInicial += Vector3.left * 2;
                            break;
                        case Dados.PlayerIndice.P3:
                            posInicial += Vector3.right * 2;
                            break;
                        case Dados.PlayerIndice.P4:
                            posInicial += Vector3.back * 2;
                            break;
                    }
                    var gbj = Instantiate(Personagens[y], posInicial, Quaternion.identity);
                    gbj.GetComponent<Move>().playerIndice = Selecionados.Jogadores[x].playerIndice;
                    var barra = BarraDeVida[(int)Selecionados.Jogadores[x].playerIndice - 1];
                    barra.SetActive(true);
                    var atb = gbj.GetComponent<Atributos>();
                    atb.barraVida = barra.GetComponentInChildren<Slider>();
                    atb.barraVida.maxValue = atb.Vida;
                    atb.barraVida.value = atb.vidaAtual;
                    gbj.SetActive(true);
                    break;
                }
            }
        }
    }
}