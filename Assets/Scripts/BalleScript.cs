using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalleScript : MonoBehaviour
{
    //Script à associer à la balle

    /*#################################################
    -- variables publiques à définir dans l'inspecteur
    #################################################*/
    public GameObject impactTir; // Référence au Prefab à instancier lorsque le tir frappe un objet. (Prefab ParticulesHit)
    public GameObject personnage; // Référence au personnage

    /*
     * Fonction OnCollisionEnter. Gère ce qui se passe lorsqu'une balle touche un objet.
     */
    void OnCollisionEnter(Collision infoCollision)
    {

        //--> Partie à compléter
        //* 1. Création d'une copie de l'objet de particules particulesContact
        GameObject cloneExplosion = Instantiate(impactTir);
        //* 2. On place l'objet copié au point de contact de la collison
        cloneExplosion.transform.position = gameObject.transform.position;
        //* 3. On active l'objet copié
        cloneExplosion.SetActive(true);
        //* 4. On oriente l'objet copié vers le personnage (LookAt)
        cloneExplosion.transform.LookAt(personnage.transform);
        //* 5. On applique une légère correction de position pour éviter que les particules se retouvent derrère l'objet
        //* 5. On détruit l'objet copié (particules de fumée) après un délai d'une seconde.
        Destroy(cloneExplosion, 1f);
        //* 6. On détruit la balle (immédiatement)
        Destroy(gameObject);
    }
}
