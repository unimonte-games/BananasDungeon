using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleDeArmas : MonoBehaviour
{
    Atributos atbPlayer;
    ControleDeAnimacao ctrAnim;

    public Dados.Armas arma;
    public Dados.ArmaNivel nivel;
    public float multi;

    public Inventario[] Arsenal;
    [System.Serializable]
    public struct Inventario
    {
        public Dados.Armas Arma;
        public GameObject Local;
    }

    void Awake()
    {
        atbPlayer = GetComponent<Atributos>();
        ctrAnim = GetComponent<ControleDeAnimacao>();

        arma = AutoSave.QualArma(atbPlayer.Personagem);
        nivel = AutoSave.QualNivel(arma);
    }

    void Start()
    {
        AtivarArma(arma, nivel);
    }

    public void AtivarArma(Dados.Armas A, Dados.ArmaNivel N)
    {
        print("Ativar arma");
        ctrAnim.TrocaArma(A);
        for (int x = 0; x < Arsenal.Length; x++)
        {
            if (Arsenal[x].Arma == A)
            {
                Arsenal[x].Local.SetActive(true);
                multi = Arsenal[x].Local.GetComponent<NivelArma>().DefinirNivel(N);
                print(A.ToString());
                print(multi);
                break;
            }
        }
    }
}