using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    Canvas canvas;
    Text messageTexte;
    bool choixJoueur1;
    bool choixJoueur2;
    bool choixJoueur3;
    bool choixJoueur4;
    
    public Vector3 targetPosition = new Vector3(0f, 0f, 0f);  // Position de la cam�ra
    public Vector3 targetRotation = new Vector3(0f, 90f, 0f);    // Rotation de la cam�ra (en degr�s)

    // Start is called before the first frame update
    void Start()
    {
        canvas = GameObject.Find("Menu").GetComponent<Canvas>();
        messageTexte = GetComponent<Text>();
        
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
            canvas.enabled = false;
            Camera.main.transform.position = targetPosition;
            Camera.main.transform.rotation = Quaternion.Euler(targetRotation);
        }
        else if (choixJoueur2)
        {
            Debug.Log("2");
        }
        else if (choixJoueur3)
        {
            Debug.Log("3");
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false; // Cela arr�te le jeu dans l'�diteur Unity
#else
        Application.Quit(); // Quitte l'application dans un build
#endif
        }
        else if (choixJoueur4)
        {
            Debug.Log("4");  
            messageTexte.enabled = true;
            messageTexte.text = "D�veloppeurs :\n Etienne Tardif-Girard\n Dylan Pironnet\n Commande : \n";
           
        }
    }
}
