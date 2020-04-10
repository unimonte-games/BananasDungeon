using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entrada : MonoBehaviour
{
    void Start()
    {
        var j = Input.GetJoystickNames();
        for (int x = 0; x < j.Length; x++)
        {
            print(j[x]);
        }
    }

    void OnGUI()//teste para detectar a entrada do jogador
    {
        Event e = Event.current;
        if (e.isKey)
            print(e.keyCode);
    }
}