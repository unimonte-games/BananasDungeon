using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleDeArmas : MonoBehaviour
{
    Animator Anim;
    public Armas ArmaInicial;
    public Inventario[] Arsenal;
    public enum Armas
    {
        Nenhum,
        Alabarda,
        Arco,
        Cajado,
        Espada,
        Lanca,
        Machado
    }
    
    [System.Serializable]
    public struct Inventario
    {
        public Armas Arma;
        public GameObject Local;
    }

    void Start()
    {
        if (true)//caso não tenha uma arma selecionada
        {
            AtivarArma(ArmaInicial, NivelArma.Nivel.Nivel1);
        }
        //else caseo tenha uma arma definida, ativar arma/nivel
    }

    public void AtivarArma(Armas Arma, NivelArma.Nivel nivel)
    {
        for (int x = 0; x < Arsenal.Length; x++)
        {
            if (Arsenal[x].Arma == Arma)
            {
                Arsenal[x].Local.SetActive(true);
                Arsenal[x].Local.GetComponent<NivelArma>().DefinirNivel(nivel);
            }
        }
    }
}