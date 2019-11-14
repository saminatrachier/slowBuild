using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//PURPOSE: player1 (WASD) player controller and progress bar
//usage: put this on player1enemyspawnmanager to spawn the prefabs randomly 
//basically assign prefabs

public class dnaChain : MonoBehaviour
{
    //prefabs for the player input
    public GameObject prefabA;

    public GameObject prefabT;

    public GameObject prefabC;

    public GameObject prefabG;

    public Image p1Progress;
    
    //time left for player objects to appear
    public float timeLeft = 0f;
    
    // Start is called before the first frame update
    void Start()
    {
  
    }

    // Update is called once per frame
    void Update()
    {
    
    //player 1 inputs/controller
        if (Input.GetKeyDown(KeyCode.A) || Input.GetButtonDown("P1 Left"))
        {
            Instantiate(prefabA, transform.position, transform.rotation);
            this.GetComponent<Transform>().Translate(new Vector3(0, 2f));
            p1Progress.fillAmount += .01f;

        }
        if (Input.GetKeyDown(KeyCode.W) || Input.GetButtonDown("P1 Up"))
        {
            Instantiate(prefabG, transform.position, transform.rotation);
            this.GetComponent<Transform>().Translate(new Vector3(0, 2f));
            p1Progress.fillAmount += .01f;


        }
        if (Input.GetKeyDown(KeyCode.S) || Input.GetButtonDown("P1 Down"))
        {
            Instantiate(prefabC, transform.position, transform.rotation);
            this.GetComponent<Transform>().Translate(new Vector3(0, 2f));
            p1Progress.fillAmount += .01f;


        }
        if (Input.GetKeyDown(KeyCode.D)|| Input.GetButtonDown("P1 Right") )
        {
            Instantiate(prefabT, transform.position, transform.rotation);
            this.GetComponent<Transform>().Translate(new Vector3(0, 2f));
            p1Progress.fillAmount += .01f;


        }
        
    
        
    }
}
