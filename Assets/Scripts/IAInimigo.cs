using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAInimigo : MonoBehaviour
{
    public GameObject[] players;
    public float distMinimaAtaque = 10f;
    public float distAtaque = 2f;
    public float velMov = 4.8f;
    ControledeAnimacaoInimigo ctrAnim;
    Atributos atrib;

    void Awake()
    {
        ctrAnim = GetComponent<ControledeAnimacaoInimigo>();
        atrib = GetComponent<Atributos>();
    }

    void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
    }

    void Update()
    {
        if (ctrAnim.Atacando || ctrAnim.Morto)
            return;

        transform.LookAt(AlvoPerto().transform);
        GameObject alvo = AlvoPerto();
        if (alvo)
        {
            float distAlvo = Vector3.Distance(transform.position, alvo.transform.position);
            if (distAlvo > distMinimaAtaque)
                ctrAnim.Idle();
            else
            {
                if (distAlvo > distAtaque)
                {
                    ctrAnim.Walk();
                    transform.Translate(Vector3.forward * velMov * Time.deltaTime);
                }
                else
                    ctrAnim.Ataque(TipoAtaque());
            }
        }
        else
            ctrAnim.Idle();
    }

    public int TipoAtaque()
    {
        int aFraco = 100;
        int aForte = 0;
        int vida = atrib.Vida;
        int vidaAtual = atrib.vidaAtual;

        aForte = (int)(100 * vidaAtual / vida);
        aFraco -= aForte;

        int rnd = Random.Range(1, 101);
        if (rnd > aFraco)
            return 1;

        return 0;
    }

    public GameObject AlvoPerto()
    {
        float distancia = float.MaxValue;
        GameObject Alvo = null;

        for (int x = 0; x < players.Length; x++)
        {
            if (Vector3.Distance(players[x].transform.position, transform.position) < distancia)
            {
                distancia = Vector3.Distance(players[x].transform.position, transform.position);
                Alvo = players[x];
            }
        }

        return Alvo;
    }
}