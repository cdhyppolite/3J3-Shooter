using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenererEnnemisScript : MonoBehaviour
{
    public GameObject ennemi1;
    public GameObject ennemi2;
    public GameObject ennemi3;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("ennemiFaible", 1f, 2f);
        InvokeRepeating("ennemiFort", 1f, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ennemiFort()
    {
        GameObject ennemiClone = Instantiate(ennemi3);
        ennemiClone.SetActive(true);
    }

    void ennemiFaible()
    {
        int choixEnnemi = Random.Range(1, 3);
        GameObject ennemiClone;
        if (choixEnnemi==1)
            ennemiClone = Instantiate(ennemi1);
        else
            ennemiClone = Instantiate(ennemi2);
        ennemiClone.SetActive(true);
        /*
        cloneBalle.transform.position = boutFusil.transform.position;
        cloneBalle.transform.rotation = boutFusil.transform.rotation;
        //On active le clône. La balle originale doit rester désactivée.
        cloneBalle.SetActive(true);
        //On applique une vélocité au clône. (velocité = transform.forward * vitesseBalle)
        cloneBalle.GetComponent<Rigidbody>().velocity = transform.forward * vitesseBalle;
        Destroy(cloneBalle, 0.8f);*/
    }
}
