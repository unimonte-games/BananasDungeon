using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelecaoDePersonagem : MonoBehaviour
{
    public Text txtBotaoPlayer;
    public GameObject[] Personagens;
    public int indice = 0;
    public float timer = 1.5f;
    public bool Selecao = false;
    public Dados.PlayerIndice playerIndice;
    public Dados.Personagens Person = Dados.Personagens.Nenhum;
    public bool Confirmado = false;
    public Selecionados.Jogador PersonagemSelecionado;
    Selecao selecao;


    void Awake()
    {
        selecao = FindObjectOfType<Selecao>();
    }

    void Start()
    {
        if (Personagens.Length == 0)
            txtBotaoPlayer.text = "Em breve...";

        for (int x = 0; x < Personagens.Length; x++)
        {
            Personagens[x].GetComponent<Rigidbody>().isKinematic = true;
            Personagens[x].GetComponent<Move>().enabled = false;
            Animator anim = Personagens[x].GetComponent<Animator>();
            Dados.Personagens person = Personagens[x].GetComponent<Atributos>().Personagem;
            Dados.Armas arma = AutoSave.QualArma(person);
            Dados.ArmaNivel nivel = AutoSave.QualNivel(arma);

            Personagens[x].SetActive(false);
        }
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (Personagens.Length == 0)
            return;

        if (Input.GetButtonDown(playerIndice.ToString() + "B") && !Selecao)
            SceneManager.LoadScene("Menu");

        if (Selecao)
        {
            if (Input.GetAxisRaw(playerIndice.ToString() + "Right/Left") != 0 && timer > 1f)
            {
                timer = 0;
                switch ((int)Input.GetAxisRaw(playerIndice.ToString() + "Right/Left"))
                {
                    case 1:
                        indice += 1;
                        MudarPersonagem(indice);
                        break;
                    case -1:
                        indice -= 1;
                        MudarPersonagem(indice);
                        break;
                }
            }

            if (Input.GetButtonDown(playerIndice.ToString() + "A"))
            {
                print("A");
                if (FindObjectOfType<Selecao>().PodeSelecionar(Person))
                {
                    print("A");
                    selecao.SFX.PlayOneShot(selecao.SomClick);
                    Confirmado = true;
                    Personagens[indice].GetComponent<ControleDeAnimacao>().Selecionar();
                    GetComponent<Image>().color = Color.yellow;
                    PersonagemSelecionado.personagem = Person;
                    PersonagemSelecionado.playerIndice = playerIndice;
                }
            }

            if (Input.GetButtonDown(playerIndice.ToString() + "B"))
            {
                if (Confirmado)
                {
                    print("B");
                    selecao.SFX.PlayOneShot(selecao.SomClick);
                    Confirmado = false;
                    Personagens[indice].GetComponent<ControleDeAnimacao>().DesSelecionar();
                    GetComponent<Image>().color = Color.white;
                    PersonagemSelecionado.personagem = Dados.Personagens.Nenhum;
                    PersonagemSelecionado.playerIndice = Dados.PlayerIndice.Vazio;
                }
                else
                {
                    selecao.SFX.PlayOneShot(selecao.SomClick);
                    Selecao = false;
                    for (int x = 0; x < Personagens.Length; x++)
                    {
                        Personagens[x].SetActive(false);
                    }
                    Person = Dados.Personagens.Nenhum;
                    indice = 0;
                    txtBotaoPlayer.enabled = true;
                }
            }
        }
        

        if (Input.GetButtonDown(playerIndice.ToString() + "Start") && !Selecao)
        {
            Selecao = true;
            selecao.SFX.PlayOneShot(selecao.SomClick);
            Debug.Log(Personagens.Length, gameObject);
            Personagens[0].SetActive(true);
            Personagens[0].GetComponent<ControleDeAnimacao>().Idle(1);
            Person = Personagens[0].GetComponent<Atributos>().Personagem;
            ControleDeArmas ctrArmas = Personagens[0].GetComponent<ControleDeArmas>();
            ctrArmas.AtivarArma(ctrArmas.arma, ctrArmas.nivel);
            txtBotaoPlayer.enabled = false;
        }
    }

    public void MudarPersonagem(int i)
    {
        selecao.SFX.PlayOneShot(selecao.SomClick);
        if (i > Personagens.Length - 1)
            i = 0;

        if (i < 0)
            i = Personagens.Length - 1;
        for (int x = 0; x < Personagens.Length; x++)
        {
            Personagens[x].SetActive(x == i ? true : false);
            Person = Personagens[x].GetComponent<Atributos>().Personagem;
            ControleDeArmas ctrArmas = Personagens[x].GetComponent<ControleDeArmas>();
            ctrArmas.AtivarArma(ctrArmas.arma, ctrArmas.nivel);
        }
        indice = i;
    }
}