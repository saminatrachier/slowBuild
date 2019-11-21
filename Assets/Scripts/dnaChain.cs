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
    
    //These variables check if input has been made. This is important for the Deletion Mechanic
    //As I need to check if a block has spawn FIRST before deleting the opposing one.
    //This is to fix a bug in where the block is stolen before the player has a chance to input anything, and will thus always get a mutation
    public static bool inputMade2;
    void Start()
    {
        inputMade2 = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (inputMade2)
        {
            Debug.Log("Input has been made by Player 1. You are now able to steal, Player 2");
        }
        else
        {
            Debug.Log("Slow your roll, Player 2. You can't steal yet because there is no input.");
        }
        
    //player 1 inputs/controller
        if ((Input.GetKeyDown(KeyCode.A) || Input.GetButtonDown("P1 Left")) && Mutation1.Mutation < 3 && cameraCinematic.startCinematic == false)
        {
            Instantiate(prefabA, transform.position, transform.rotation);
            StartCoroutine(MoveUp2());
            p1Progress.fillAmount += .05f;
            StartCoroutine(ResetBool2());
            inputMade2 = true;

        }
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetButtonDown("P1 Up"))&& Mutation1.Mutation < 3 && cameraCinematic.startCinematic == false)
        {
            Instantiate(prefabG, transform.position, transform.rotation);
            StartCoroutine(MoveUp2());
            p1Progress.fillAmount += .05f;
            inputMade2 = true;


        }
        if ((Input.GetKeyDown(KeyCode.S) || Input.GetButtonDown("P1 Down"))&& Mutation1.Mutation < 3 && cameraCinematic.startCinematic == false)
        {
            Instantiate(prefabC, transform.position, transform.rotation);
            StartCoroutine(MoveUp2());
            p1Progress.fillAmount += .05f;
            StartCoroutine(ResetBool2());
            inputMade2 = true;


        }
        if ((Input.GetKeyDown(KeyCode.D)|| Input.GetButtonDown("P1 Right") ) && Mutation1.Mutation < 3 && cameraCinematic.startCinematic == false)
        {
            Instantiate(prefabT, transform.position, transform.rotation);
            StartCoroutine(MoveUp2());
            p1Progress.fillAmount += .05f;
            StartCoroutine(ResetBool2());
            inputMade2 = true;
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

    }
}
