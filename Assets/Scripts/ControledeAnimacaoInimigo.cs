using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControledeAnimacaoInimigo : MonoBehaviour
{
    public bool Atacando = false;
    public bool Morto = false;
    [Space(20)]
    public float velAnimMorte = 1;
    public float velAnimAtaqueForte = 1;
    public float velAnimAtaqueFraco = 1;
    public float velAnimAndar = 1;
    float velAnim = 1;

    Animator Anim;
    enum Estado
    {
        Morte = -1,
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
        Anim.speed = velAnim;
        Anim.SetInteger("Move", (int)Estado.Idle);
    }

    public void Walk()
    {
        Anim.speed = velAnimAndar;
        Anim.SetInteger("Move", (int)Estado.Walk);
    }

    public void Ataque(int a)
    {
        switch (a)
        {
            case 0:
                Anim.speed = velAnimAtaqueFraco;
                break;
            case 1:
                Anim.speed = velAnimAtaqueForte;
                break;
        }
        Anim.SetInteger("Move", (int)Estado.Ataque);
        Anim.SetInteger("Ataque", a);
    }

    public void Morte()
    {
        print("Morte");
        Morto = true;
        Anim.speed = velAnimMorte;
        Anim.SetInteger("Move", (int)Estado.Morte);
    }
    
    #region Evento de animação
    public void IniciouAtaque()
    {
        Atacando = true;
    }

    public void ParouAtaque()
    {
        Atacando = false;
    }
    #endregion
}