using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JoueurPrincipale : MonoBehaviour
{
    // Start is called before the first frame update
    bool isInverse;
    bool gameIsRunning;
    bool playerIsGrounded;
    bool playerIsJumping;
    private float deplacementHorizontal;
    private float deplacementVertical;
    private Rigidbody rigidBody;
    private float rotationY;
    private float rotationX;
    private Vector3 deplacementVecteur;
    [SerializeField][Range(100f, 600f)] private float speed;
    [SerializeField][Range(50f, 200f)] private float rotationSpeed;
    [SerializeField] private bool inversionY;
    private Camera cameraPrincipale;
    Menu menu;
    Text messageTexte;

    void Start()
    {
        messageTexte = GetComponent<Text>();
        rigidBody = GetComponent<Rigidbody>();
        isInverse = false;
        gameIsRunning = false;
        playerIsGrounded = false;
        playerIsJumping = false;
        rotationY = 0.0f;
        rotationX = 0.0f;
        deplacementHorizontal = 0.0f;
        deplacementVertical = 0.0f;
        cameraPrincipale = GameObject.Find("Main Camera").GetComponent<Camera>();
        menu = FindObjectOfType<Menu>();
    }

    // Update is called once per frame
    void Update()
    {
        
        // Gestion de la pause
        if (Input.GetKeyDown(KeyCode.Escape))
        {
           
            gameIsRunning = !gameIsRunning;
            Time.timeScale = gameIsRunning ? 1 : 0; // Met le jeu en pause ou reprend
            if (gameIsRunning)
            {
                menu.masquerMenuPause();

            }
            else
            {
               
                menu.afficherMenuPause();
            }

          
            
            return; // �vite de continuer si le jeu est en pause
        }
        if (Input.GetKeyDown(KeyCode.Keypad5) && !gameIsRunning)
        {
            gestionInversion();
        }

        if (!gameIsRunning)
        {
            return; // Si le jeu est en pause, ignore les mises � jour
        }

        if (!gameIsRunning)
        {
            //menu.afficherMenuPause();
            return; // Si le jeu est en pause, ignore les mises � jour
        }

        if (!gameIsRunning && rigidBody.velocity.y == 0)
        {
            //gameIsRunning = true;
            playerIsGrounded = true;
        }
        if (playerIsGrounded && !playerIsJumping && Input.GetKeyDown(KeyCode.Space))
        {
            playerIsJumping = true;
        }

      
        deplacementHorizontal = Input.GetAxis("Horizontal");
        deplacementVertical = Input.GetAxis("Vertical");

        //Rotation
        deplacementVecteur = new Vector3(deplacementHorizontal, rigidBody.velocity.y, deplacementVertical);
        deplacementVecteur.x *= speed * Time.deltaTime;
        deplacementVecteur.z *= speed * Time.deltaTime; ;
        deplacementVecteur = transform.rotation * deplacementVecteur;
        if (gameIsRunning)
        {
            rotationY = Input.GetAxis("Mouse X");
            rotationX = Input.GetAxis("Mouse Y");
            if (isInverse)
            {
                rotationX *= -1.0f;
            }
        }
    }


    public void gestionInversion()
    {

        isInverse = !isInverse;
        Debug.Log("Y-axis inversion is now " + (isInverse ? "enabled" : "disabled"));


    }


    private void FixedUpdate()
    {
        if (!playerIsGrounded && playerIsJumping && rigidBody.velocity.y == 0)
        {
            playerIsGrounded = true;
            playerIsJumping = false;
        }
        if (playerIsJumping && playerIsGrounded)
        {
            rigidBody.AddForce(Vector3.up * 5, ForceMode.VelocityChange);
            playerIsGrounded = false;

        }

        //if (Input.GetKeyDown(KeyCode.Escape))
        //{
        //    gameIsRunning = !gameIsRunning;
        //}

        rigidBody.velocity = new Vector3(deplacementVecteur.x, rigidBody.velocity.y, deplacementVecteur.z);

        // Rottation
        transform.Rotate(0, rotationY * rotationSpeed * Time.deltaTime, 0);

    }
    private void LateUpdate()
    {
        cameraPrincipale.transform.Rotate(rotationX * rotationSpeed * Time.deltaTime, 0, 0);
        zoomCameras();
    }
    private void zoomCameras()
    {
        if (Input.GetKey(KeyCode.I))
        {
            float zoom = Input.GetAxis("Mouse ScrollWheel") * -1.0f;
            cameraPrincipale.fieldOfView += zoom * 500 * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.O))
        {
            float zoom = Input.GetAxis("Mouse ScrollWheel") * -1.0f;
        }
    }
    public void D�marrerJeu()
    {
        gameIsRunning = true;
        Time.timeScale = 1; // Assurez-vous que le temps n'est pas en pause
        Debug.Log("Jeu d�marr� !");
    }
    //private void mettrePause()
    //{
    //    if (Input.GetKeyDown(KeyCode.Escape))
    //    {
    //        gameIsRunning = !gameIsRunning;
    //    }
    //}
}