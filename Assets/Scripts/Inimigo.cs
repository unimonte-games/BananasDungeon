using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    public enum Tipo { Soldado, AranhaP, AranhaM, Bonus, Boss };
    public Tipo TipoInimigo;
    public DropRange Drops;
    [System.Serializable]
    public struct DropRange
    {
        public int inicio;
        public int fim;
    }


    public void Drop()
    {
        int qSangue = Random.Range(Drops.inicio, Drops.fim + 1);
        AutoSave.AtualizarSangue(qSangue, true);
    }
}