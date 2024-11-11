using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    bool choixJoueur1;
    bool choixJoueur2;
    bool choixJoueur3;
    bool choixJoueur4;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        choixJoueur1 = Input.GetKeyDown(KeyCode.Keypad1);
        choixJoueur2 = Input.GetKeyDown(KeyCode.Keypad2);
        choixJoueur3 = Input.GetKeyDown(KeyCode.Keypad3);
        choixJoueur4 = Input.GetKeyDown(KeyCode.Keypad4);
            
        if (choixJoueur1)
        {
            Debug.Log("1");
        }
        else if (choixJoueur2)
        {
            Debug.Log("2");
        }
        else if (choixJoueur3)
        {
            Debug.Log("3");
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false; // Cela arrête le jeu dans l'éditeur Unity
#else
        Application.Quit(); // Quitte l'application dans un build
#endif
        }
        else if (choixJoueur4)
        {
            Debug.Log("4");
        }
    }
}
