using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    
    //These variables check if input has been made. This is important for the Deletion Mechanic
    //As I need to check if a block has spawn FIRST before deleting the opposing one.
    //This is to fix a bug in where the block is stolen before the player has a chance to input anything, and will thus always get a mutation
    public static bool inputMade;
    void Start()
    {

        timeLeft = maxTime;
        inputMade = false;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("inputMade is " + inputMade);
        
        
        if ((Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetButtonDown("P2 Left"))&& Mutation2.Mutation < 3 && cameraCinematic.startCinematic == false)
        {
            Instantiate(prefabA, transform.position, transform.rotation);
            StartCoroutine(MoveUp());
            p2Progress.fillAmount += .01f;
            inputMade = true;
            StartCoroutine(ResetBool());
            

        }
        if ((Input.GetKeyDown(KeyCode.UpArrow)|| Input.GetButtonDown("P2 Up"))&& Mutation2.Mutation < 3 && cameraCinematic.startCinematic == false)
        {
            Instantiate(prefabG, transform.position, transform.rotation);
            StartCoroutine(MoveUp());
            p2Progress.fillAmount += .01f;
            inputMade = true;
            StartCoroutine(ResetBool());
            


        }
        if ((Input.GetKeyDown(KeyCode.DownArrow)|| Input.GetButtonDown("P2 Down"))&& Mutation2.Mutation < 3 && cameraCinematic.startCinematic == false)
        {
            Instantiate(prefabC, transform.position, transform.rotation);
            StartCoroutine(MoveUp());
            p2Progress.fillAmount += .01f;
            inputMade = true;
            StartCoroutine(ResetBool());
          


        }
        if ((Input.GetKeyDown(KeyCode.RightArrow)|| Input.GetButtonDown("P2 Right") )&& Mutation2.Mutation < 3 && cameraCinematic.startCinematic == false)
        {
            Instantiate(prefabT, transform.position, transform.rotation);
            StartCoroutine(MoveUp());
            p2Progress.fillAmount += .01f;
            inputMade = true;
            StartCoroutine(ResetBool());
         


        }
        
        if (timeLeft > 0 && cameraCinematic.startCinematic == false)
        {
            timeLeft -= Time.deltaTime;
            timer.fillAmount = timeLeft / maxTime;
        }
        else if (cameraCinematic.startCinematic == false)
        {
            Time.timeScale = 0;
            SceneManager.LoadScene (2);
        }
        
    
        
    }

    IEnumerator ResetBool()
    {
        yield return new WaitForSeconds(1f);
        inputMade = false;
        
    }

    IEnumerator MoveUp()
    {
        yield return  new WaitForSeconds(1.5f);
        this.GetComponent<Transform>().Translate(new Vector3(0, 2f));
    }
}
