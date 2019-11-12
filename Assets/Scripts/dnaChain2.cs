using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//PURPOSE: player2 (ARROW KEYS) player controller and progress bar
//usage: put this on  player2enemyspawnmanager to spawn the prefabs randomly 
//basically assign prefabs

public class dnaChain2 : MonoBehaviour
{
    //prefabs for the player input
    public GameObject prefabA;

    public GameObject prefabT;

    public GameObject prefabC;

    public GameObject prefabG;
    
    public Image p2Progress;

    
    //time left for player objects to appear
    public Image timer;
    public float timeLeft;
    public float maxTime = 60f;
    
    // Start is called before the first frame update
    void Start()
    {

        timeLeft = maxTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Instantiate(prefabA, transform.position, transform.rotation);
            this.GetComponent<Transform>().Translate(new Vector3(0, 2f));
            p2Progress.fillAmount += .01f;

        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Instantiate(prefabG, transform.position, transform.rotation);
            this.GetComponent<Transform>().Translate(new Vector3(0, 2f));
            p2Progress.fillAmount += .01f;


        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Instantiate(prefabC, transform.position, transform.rotation);
            this.GetComponent<Transform>().Translate(new Vector3(0, 2f));
            p2Progress.fillAmount += .01f;


        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Instantiate(prefabT, transform.position, transform.rotation);
            this.GetComponent<Transform>().Translate(new Vector3(0, 2f));
            p2Progress.fillAmount += .01f;


        }
        
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            timer.fillAmount = timeLeft / maxTime;
        }
        else
        {
            Time.timeScale = 0;
        }
        
    
        
    }
}
