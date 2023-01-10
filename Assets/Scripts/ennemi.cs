using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ennemi : MonoBehaviour
{
    Animator ennemiAnim;
    private NavMeshAgent navAgent;
    public int nbDeVies;
    public AudioClip sonBlessure;
    public AudioClip sonMort;
    public GameObject particuleMortEnnemi;
    public GameObject cible;
    public int points;
    // Start is called before the first frame update
    void Start()
    {
        ennemiAnim = GetComponent<Animator>();
        navAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        navAgent.SetDestination(cible.transform.position);

        if (navAgent.velocity.magnitude > 0)
        {
            ennemiAnim.SetBool("marche", true);
        }
        else
        {
            ennemiAnim.SetBool("marche", false);
        }

        if ((ennemiAnim.GetCurrentAnimatorStateInfo(0).IsName("Mort"))|| cible.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Mort")) {
            navAgent.enabled = false;
        }
    }

    void OnCollisionEnter(Collision infoCollision)
    {
        if(infoCollision.gameObject.tag=="balle")
        {
            blesser();
        }
    }
    void blesser()
    {
        nbDeVies -= 1;
        if (!ennemiAnim.GetCurrentAnimatorStateInfo(0).IsName("Mort"))
            GetComponent<AudioSource>().PlayOneShot(sonBlessure);
        if (nbDeVies ==0)
        {
            ennemiAnim.SetTrigger("mort");
            GetComponent<AudioSource>().PlayOneShot(sonMort);
            GetComponent<Collider>().enabled = false;
            Invoke("disparaitre", 2f);
            DeplacementPersoScript.score += points;
        }
    }
    void disparaitre()
    {
        GameObject particuleMort = Instantiate(particuleMortEnnemi);
        particuleMort.transform.position = gameObject.transform.position;
        particuleMort.SetActive(true);
        Destroy(gameObject);
        Destroy(particuleMort.gameObject, 2f);
    }
}