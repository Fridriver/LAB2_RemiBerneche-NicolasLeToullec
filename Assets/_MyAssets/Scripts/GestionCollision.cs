using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionCollision : MonoBehaviour
{
    // ***** Attributs *****
    private GestionJeu _gestionJeu;  // Sert à récupérer le l'attribut pointage dans la classe GestionJeu
    private bool _touche;  // Booléen qui permet de détecter si l'objet a été touché

    // ***** Méthodes privées *****
    private void Start()
    {
        _gestionJeu = FindObjectOfType<GestionJeu>();  // lie la variable au gameObject GestionJeu de la scène
        _touche= false;  // initialise le booléen à faux au début de la scène
    }

    /* 
     * Rôle : Méthode qui se déclenche quand une collision se produit avec l'objet
     * Entrée : un objet de type Collision qui représente l'objet avec qui la collision s'est produite
     */
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && !_touche)  // Si l'objet avec la collision s'est produite est le joueur et qu'il n'a pas déjà et touché
        {
                gameObject.GetComponent<MeshRenderer>().material.color = Color.red;  //change la couleur du matériel à rouge
                _gestionJeu.AugmenterPointage();  // Appelle la méthode publique dans GestionJeu pour augmenter le pointage
                _touche = true;  // change le booléen à vrai pour indiqué que l'objet a été touché
        }
    }
}
