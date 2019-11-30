﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    
    //These variables check if input has been made. This is important for the Deletion Mechanic
    //As I need to check if a block has spawn FIRST before deleting the opposing one.
    //This is to fix a bug in where the block is stolen before the player has a chance to input anything, and will thus always get a mutation
    public static bool inputMade2;
    private bool deleteThree;
    private int deleteCounter;
    private int deleteCounter2;
    public float time;

    public int pressCount;
    
   
    void Start()
    {
        inputMade2 = false;
        deleteCounter = 0;
        deleteCounter2 = 0;
        deleteThree = false;
        time = 0.2f;
        pressCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    //player 1 inputs/controller
        if ((Input.GetKeyDown(KeyCode.A) || Input.GetButtonDown("P1 Left")) && Mutation1.Mutation < 3 && cameraCinematic.startCinematic == false)
        {
            Instantiate(prefabA, transform.position, transform.rotation);
            StartCoroutine(MoveUp2());
            p1Progress.fillAmount += 1f;
            StartCoroutine(ResetBool2());
            pressCount += 1;
            inputMade2 = true;

            FindObjectOfType<AudioManager>().Play("Correct");
        }
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetButtonDown("P1 Up"))&& Mutation1.Mutation < 3 && cameraCinematic.startCinematic == false)
        {
            Instantiate(prefabG, transform.position, transform.rotation);
            StartCoroutine(MoveUp2());
            p1Progress.fillAmount += 1f;
            pressCount += 1;
            inputMade2 = true;

            
            FindObjectOfType<AudioManager>().Play("Correct");

        }
        if ((Input.GetKeyDown(KeyCode.S) || Input.GetButtonDown("P1 Down"))&& Mutation1.Mutation < 3 && cameraCinematic.startCinematic == false)
        {
            Instantiate(prefabC, transform.position, transform.rotation);
            StartCoroutine(MoveUp2());
            p1Progress.fillAmount += 1f;
            pressCount += 1;
            StartCoroutine(ResetBool2());
            inputMade2 = true;
            
            FindObjectOfType<AudioManager>().Play("Correct");


        }
        if ((Input.GetKeyDown(KeyCode.D)|| Input.GetButtonDown("P1 Right") ) && Mutation1.Mutation < 3 && cameraCinematic.startCinematic == false)
        {
            Instantiate(prefabT, transform.position, transform.rotation);
            StartCoroutine(MoveUp2());
            p1Progress.fillAmount += 1f;
            pressCount += 1;
            StartCoroutine(ResetBool2());
            inputMade2 = true;
            
            FindObjectOfType<AudioManager>().Play("Correct");
        }
        
        
        //Helicase Mechanic
        if (Input.GetKeyDown(KeyCode.Y) && p1Progress.fillAmount == 1f) 
        {
            deleteThree = true;
            p1Progress.fillAmount = 0f;
        }
        
        if (deleteThree == true && deleteCounter < 3)
        {
           
            float myMaxDistance2 = 2000f;
            RaycastHit downHit;
            Ray checkRay2 = new Ray(transform.position, -transform.up);
            time -= Time.deltaTime;
            if (time <= 0)
            {
                StartCoroutine(MoveDown());
                Physics.Raycast(checkRay2, out downHit, myMaxDistance2);
                Destroy(downHit.transform.gameObject); 
                ScoreText1.Score -= 1;
                time = 0.2f;
                deleteThree = false;
                deleteCounter++;
            }
        }

        if (Mutation1.Mutation == 3 && deleteCounter2 < pressCount)
        {
            float myMaxDistance2 = 2000f;
            RaycastHit downHit;
            Ray checkRay2 = new Ray(transform.position, -transform.up);
            time -= Time.deltaTime;
            if (time <= 0)
            {
                StartCoroutine(MoveDown());
                Physics.Raycast(checkRay2, out downHit, myMaxDistance2);
                Destroy(downHit.transform.gameObject);
                ScoreText1.Score = 0;
                time = 0.02f;
                deleteCounter2++;
            }
        }


        if (ScoreText1.Score == 50)
        {
            SceneManager.LoadScene (2);
        }
        if (p1Progress.fillAmount < 1.0f)
        {
            p1Progress.color = new Color(1, 1, 1, 1);
        }
        
        if (p1Progress.fillAmount >= 1.0f)
        {
            p1Progress.color = new Color(0, 1, 1, 1);
            p1Progress.fillAmount = 1.0f;
        }
        
        IEnumerator ResetBool2()
        {
            yield return new WaitForSeconds(1f);
            inputMade2 = false;
        
        }

        IEnumerator MoveUp2()
        {
            yield return  new WaitForSeconds(0.1f);
            this.GetComponent<Transform>().Translate(new Vector3(0, 2f));
        }
        
        IEnumerator MoveDown()
        {
            yield return  new WaitForSeconds(0.1f);
            this.GetComponent<Transform>().Translate(new Vector3(0, -2f));
        }

    }
}
