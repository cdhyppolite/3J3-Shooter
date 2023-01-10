using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gestionPivot : MonoBehaviour
{
    public GameObject cible;              // le personnage
    public GameObject camera3ePerso;     // la caméra 
    public float hauteurPivot;          // Ajustement de la position du pivot en hauteur   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = cible.transform.position + new Vector3(0, hauteurPivot, 0);
        transform.Rotate(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0);
        // -Input.GetAxis("Mouse Y")   pour inverser la direction

        //Annuler la rotation en Z
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, 0);

    }
}
