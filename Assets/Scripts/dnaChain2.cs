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
    public float time;
    public float timeLeft;
    public float maxTime = 60f;
    
    private bool deleteThree;
    private int deleteCounter;
    
    //These variables check if input has been made. This is important for the Deletion Mechanic
    //As I need to check if a block has spawn FIRST before deleting the opposing one.
    //This is to fix a bug in where the block is stolen before the player has a chance to input anything, and will thus always get a mutation
    public static bool inputMade;
    void Start()
    {

        timeLeft = maxTime;
        inputMade = false;
        deleteCounter = 0;
        deleteThree = false;
        time = 0.2f;
    }

    // Update is called once per frame
    void Update()
    {
        
        if ((Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetButtonDown("P2 Left"))&& Mutation2.Mutation < 3 && cameraCinematic.startCinematic == false)
        {
            Instantiate(prefabA, transform.position, transform.rotation);
            StartCoroutine(MoveUp());
            p2Progress.fillAmount += 0.05f;
            inputMade = true;
            StartCoroutine(ResetBool());
            

        }
        if ((Input.GetKeyDown(KeyCode.UpArrow)|| Input.GetButtonDown("P2 Up"))&& Mutation2.Mutation < 3 && cameraCinematic.startCinematic == false)
        {
            Instantiate(prefabG, transform.position, transform.rotation);
            StartCoroutine(MoveUp());
            p2Progress.fillAmount += 0.05f;
            inputMade = true;
            StartCoroutine(ResetBool());
            


        }
        if ((Input.GetKeyDown(KeyCode.DownArrow)|| Input.GetButtonDown("P2 Down"))&& Mutation2.Mutation < 3 && cameraCinematic.startCinematic == false)
        {
            Instantiate(prefabC, transform.position, transform.rotation);
            StartCoroutine(MoveUp());
            p2Progress.fillAmount += 0.5f;
            inputMade = true;
            StartCoroutine(ResetBool());
          


        }
        if ((Input.GetKeyDown(KeyCode.RightArrow)|| Input.GetButtonDown("P2 Right") )&& Mutation2.Mutation < 3 && cameraCinematic.startCinematic == false)
        {
            Instantiate(prefabT, transform.position, transform.rotation);
            StartCoroutine(MoveUp());
            p2Progress.fillAmount += 0.5f;
            inputMade = true;
            StartCoroutine(ResetBool());
        }
        
        
        if (timeLeft > 0 && cameraCinematic.startCinematic == false)
        {
          //  timeLeft -= Time.deltaTime;
           // timer.fillAmount = timeLeft / maxTime;
        }
        else if (cameraCinematic.startCinematic == false)
        {
            Time.timeScale = 0;
            SceneManager.LoadScene (2);
        }
        
        //Helicase Mechanic
        if (Input.GetKeyDown(KeyCode.R) || (Input.GetButtonDown("P1 Heliocase")&& p2Progress.fillAmount >= 1f) )
        {
            deleteThree = true;
            p2Progress.fillAmount = 0f;
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
                ScoreText2.Score2 -= 1;
                time = 0.2f;
                deleteCounter++;
            }
        }
        
        if (p2Progress.fillAmount < 1.0f)
        {
            p2Progress.color = new Color(1, 1, 1, 1);
        }
        
        if (p2Progress.fillAmount >= 1.0f)
        {
            p2Progress.color = new Color(0, 1, 1, 1);
            p2Progress.fillAmount = 1.0f;
        }
        
    }

    IEnumerator ResetBool()
    {
        yield return new WaitForSeconds(1f);
        inputMade = false;
        
    }

    IEnumerator MoveUp()
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
