using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    Canvas canvas;
    GameObject messagePause;
    Text messageTexte;
    bool choixJoueur1;
    bool choixJoueur2;
    bool choixJoueur3;
    bool choixJoueur4;
    bool choixJoueur5;
    JoueurPrincipale JoueurPrincipale;
    //public Vector3 targetPosition = new Vector3(0f, 0f, 0f);  // Position de la caméra
    //public Vector3 targetRotation = new Vector3(90f, 90f, 0f);    // Rotation de la caméra (en degrés)

    // Start is called before the first frame update
    void Start()
    {
        JoueurPrincipale = FindObjectOfType<JoueurPrincipale>();
        canvas = GameObject.Find("Menu").GetComponent<Canvas>();
        messageTexte = GetComponent<Text>();
        canvas = GetComponent<Canvas>();
        messagePause = GameObject.FindWithTag("Pause");
        if (messagePause != null)
        {
            messagePause.SetActive(false); // Désactive l'objet pause
        }

    }

    // Update is called once per frame  
    void Update()
    {
        
        choixJoueur1 = Input.GetKeyDown(KeyCode.Keypad1);
        choixJoueur2 = Input.GetKeyDown(KeyCode.Keypad2);
        choixJoueur3 = Input.GetKeyDown(KeyCode.Keypad3);
        choixJoueur4 = Input.GetKeyDown(KeyCode.Keypad4);
        choixJoueur5 = Input.GetKeyDown(KeyCode.Keypad5);

        if (choixJoueur1)
        {
            Debug.Log("1");
            canvas.enabled = false; // Masque le menu principal
            FindObjectOfType<JoueurPrincipale>().DémarrerJeu(); // Démarre le jeu
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
            messageTexte.enabled = true;
            messageTexte.text = "Développeurs :\n Etienne Tardif-Girard\n Dylan Pironnet\n Commande : \n " +
                "W - Avancer \n" +
                "S - Reculer \n" +
                "A - Aller à gauche \n" +
                "D - Aller à droite \n" +
              //  "ESPACE - Sauter \n" + 
                "ECHAP - Mettre le jeu en pause";


        }
        else if (choixJoueur5)
        {
            if (canvas.enabled)
            {
                Debug.Log("5");
                JoueurPrincipale.gestionInversion();
            }
        }
    }
    public void afficherMenuPause()
    {
        if (messagePause != null)
        {
            messagePause.SetActive(true); // Active l'objet pause

        }
    }

    public void masquerMenuPause()
    {
        if (messagePause != null)
        {
            messagePause.SetActive(false); // Désactive l'objet pause
        }
    }
}
