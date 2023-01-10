using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TirScript_CreationBalle : MonoBehaviour
{
    /*#################################################
   -- variables publiques à définir dans l'inspecteur
   #################################################*/
    public GameObject balle; // Référence au gameObject de la balle
    public GameObject particuleBalle; // Référence au gameObject à activer lorsque le personnage tir
    public float vitesseBalle=30; // Vitesse de la balle
    public AudioClip gunShot;
    public GameObject boutFusil;

    /*#################################################
   -- variables privées
   #################################################*/
    private bool peutTirer; // Est-ce que le personnage peut tirer


    //----------------------------------------------------------------------------------------------
    void Start()
    {
        peutTirer = true; // Au départ, on veut que le personnage puisse tirer
    }
    //----------------------------------------------------------------------------------------------


    /*
     * Fonction Update. On appele la fonction Tir() lorsque la touche espace est enfoncée et que 
     * le personnage peut tirer
     */
    void Update()
    {

        // --> partie à compléter ****
        if (((Input.GetKey(KeyCode.Space)) || Input.GetKey(KeyCode.Mouse0)) && (peutTirer==true))
        {
            Tir();
        }
         
    }
    //----------------------------------------------------------------------------------------------


    /*
     * Fonction Tir. Gère le tir d'une nouvelle balle.
     */
    void Tir()
    {
        /* On désactive la capacité de tirer et on appelle la fonction ActiveTir() après
         un délai de 0.1 seconde */
        peutTirer = false;
        Invoke("ActiveTir", 0.2f);
        
        //1. activation de la particuleBalle
        particuleBalle.SetActive(true);
        //2. activation du son "Player GunShot". Que devez-vous ajouter au personnage pour qu'il puisse jouer un son?
        GetComponent<AudioSource>().PlayOneShot(gunShot);
        //3. Création d'une copie de la balle à partir de la balle originale. La position et la rotation du clône doivent être les mêmes que la balle originale.
        clonerBalle();
    }
    //----------------------------------------------------------------------------------------------


    /*
     * Fonction ActiveTir(). Réactive la capacité de tirer.
     */

    void ActiveTir()
    {
        //--> partie à compléter...
        //* 1. On réactive la capacité de tirer... variable peutTirer...
        peutTirer = true;
        //* 2. On désactive la particule particuleBalle
        particuleBalle.SetActive(false);
    }

    void clonerBalle()
    {
        GameObject cloneBalle = Instantiate(balle);
        cloneBalle.transform.position = boutFusil.transform.position;
        cloneBalle.transform.rotation = boutFusil.transform.rotation;
        //On active le clône. La balle originale doit rester désactivée.
        cloneBalle.SetActive(true);
        //On applique une vélocité au clône. (velocité = transform.forward * vitesseBalle)
        cloneBalle.GetComponent<Rigidbody>().velocity = transform.forward * vitesseBalle;
        Destroy(cloneBalle, 0.8f);

    }
}
