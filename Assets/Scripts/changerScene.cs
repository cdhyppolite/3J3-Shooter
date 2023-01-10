using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changerScene : MonoBehaviour
{
    public string sceneACharger = "SceneDebut";
    public bool activerChangement;
    public bool changerSceneSpace;
    public GameObject musique;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(musique);
    }

    // Update is called once per frame
    void Update()
    {
        if(activerChangement == true)
        {
            changementScene();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (changerSceneSpace == true) 
                activerChangement = true;
        }
    }
    

    void changementScene()
    {
        if (SceneManager.GetActiveScene().name != "SceneDebut")
        {
            print("oui");
            DeplacementPersoScript.score = 0;
        }
        SceneManager.LoadScene(sceneACharger);
    }
}
