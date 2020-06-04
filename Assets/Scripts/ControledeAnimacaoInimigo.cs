using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControledeAnimacaoInimigo : MonoBehaviour
{
    public bool Atacando = false;
    public bool Morto = false;
    Animator Anim;
    enum Estado
    {
        Idle = 0,
        Walk,
        Ataque
    }

    void Awake()
    {
        Anim = GetComponent<Animator>();
    }

    public void Idle()
    {
        Anim.SetInteger("Move", (int)Estado.Idle);
    }

    public void Walk()
    {
        Anim.SetInteger("Move", (int)Estado.Walk);
    }

    public void Ataque(int a)
    {
        Anim.SetInteger("Move", (int)Estado.Ataque);
        Anim.SetInteger("Ataque", a);
    }

    public void Morte()
    {
        print("Morte");
        Anim.SetInteger("Move", -1);
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