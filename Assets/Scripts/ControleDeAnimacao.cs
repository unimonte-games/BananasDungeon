using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleDeAnimacao : MonoBehaviour
{
    public enum Estado
    {
        Morte = -1,
        Idle = 0,
        Andando,
        Atacando
    }
    public Animator anim;
    public bool Atacando = false;
    

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public float Velocidade(float vel)
    {
        anim.SetFloat("Velocidade", vel);
        return vel;
    }

    public void Idle(int idle)
    {
        if (idle == -1)
            idle = Random.Range(0,2);

        anim.SetInteger("Idle", idle);
        anim.SetInteger("Move", (int)Estado.Idle);
    }

    public void Andar()
    {
        anim.SetInteger("Move", (int)Estado.Andando);
    }

    public void Ataque(int atk)
    {
        anim.SetInteger("Ataque", atk);
        anim.SetInteger("Move", (int)Estado.Atacando);
    }

    public void Morte()
    {
        int i = Random.Range(0,2);

        anim.SetInteger(Estado.Morte.ToString(), i);
        anim.SetInteger("Move", (int)Estado.Morte);
    }

    public void Desequipar()
    {
        anim.SetBool(Dados.Armas.Arco.ToString(), false);
        anim.SetBool(Dados.Armas.Espada.ToString(), false);
        anim.SetBool(Dados.Armas.Machado.ToString(), false);
        anim.SetBool(Dados.Armas.Alabarda.ToString(), false);
        anim.SetBool(Dados.Armas.Lanca.ToString(), false);
        anim.SetBool(Dados.Armas.Cajado.ToString(), false);
    }

    public void TrocaArma(Dados.Armas arma)
    {
        Desequipar();
        Idle(1);
        anim.SetBool(arma.ToString(), true);
    }

    public void Selecionar()
    {
        print("Selecionar");
        anim.SetBool("Selecao", true);
        var arma = GetComponent<ControleDeArmas>().arma;
        Desequipar();
        Idle(0);
        anim.SetBool(arma.ToString(), true);
    }

    public void DesSelecionar()
    {
        print("DesSelecionar");
        anim.SetBool("Selecao", true);
        var arma = GetComponent<ControleDeArmas>().arma;
        Desequipar();
        Idle(1);
        anim.SetBool(arma.ToString(), true);
    }

    #region Evento de animação
    public void IniciouAtaque()
    {
        print("Iniciou o Ataque");
        Atacando = true;
    }

    public void ParouAtaque()
    {
        print("Terminou o Ataque");
        Atacando = false;
    }
    #endregion
}