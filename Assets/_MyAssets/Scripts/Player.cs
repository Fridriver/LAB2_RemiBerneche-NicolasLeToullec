using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // ***** Attributs *****
    
    [SerializeField] private float _vitesse = 800f;  //Vitesse de déplacement du joueur
    private Rigidbody _rb;  // Variable pour emmagasiner le rigidbody du joueur
    
    //  ***** Méthodes privées *****
    
    private void Start()
    {
        // Position initiale du joueur
        transform.position = new Vector3(-30f, 0.51f, -30f);  // place le joueur à sa position initiale 
        _rb = GetComponent<Rigidbody>();  // Récupère le rigidbody du Player
    }

    // Ici on utilise FixedUpdate car les mouvements du joueurs implique le déplacement d'un rigidbody
    private void FixedUpdate()
    {
        MouvementsJoueur();
    }

    /*
     * Méthode qui gère les déplacements du joueur
     */
    private void MouvementsJoueur()
    {
        float positionX = Input.GetAxis("Horizontal"); // Récupère la valeur de l'axe horizontal de l'input manager
        float positionZ = Input.GetAxis("Vertical");  // Récupère la valeur de l'axe vertical de l'input manager
        Vector3 direction = new Vector3(positionX, 0f, positionZ);  // Établi la direction du vecteur à appliquer sur le joueur
        _rb.velocity = direction * Time.fixedDeltaTime * _vitesse;  // Applique la vélocité sur le corps du joueur dans la direction du vecteur
        // _rb.AddForce(direction * Time.fixedDeltaTime * _vitesse);  // Applique une force sur le joueur dans la direction du vecteur
    }

    // ***** Méthodes publiques *****

    /*
     * Méthode appelé en fin de partie qui rend le gameObject Player inactif
     */
    public void finPartieJoueur()
    {
        gameObject.SetActive(false);  // Désactive le gameObject
    }
}
