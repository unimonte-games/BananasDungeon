using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleDeArmas : MonoBehaviour
{
    public Inventario[] Arsenal;
    public enum Armas
    {
        Espada, Machado, Arco, Lanca, Halbard, Cajado
    }
    [System.Serializable]
    public struct Inventario
    {
        public Armas Arma;
        public GameObject Local;
    }

    public void AtivarArma(Armas Arma)
    {
        for (int x = 0; x < Arsenal.Length; x++)
        {
            if (Arsenal[x].Arma == Arma)
                Arsenal[x].Local.SetActive(true);
        }
    }
}