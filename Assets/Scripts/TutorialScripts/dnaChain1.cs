using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using EZCameraShake;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

//PURPOSE: player1 (WASD) player controller and progress bar
//usage: put this on player1enemyspawnmanager to spawn the prefabs randomly 
//basically assign prefabs

public class dnaChain1 : MonoBehaviour
{
    //prefabs for the player input
    public GameObject prefabA;

    public GameObject prefabT;

    public GameObject prefabC;

    public GameObject prefabG;

    public Image p1Progress;
    
    public Image p2Progress;
    
    public Image progressBar;

    public static bool winner;
    
    public Color color1 = new Color(255, 185, 185, 255); //light red
    public Camera cam1;
    
  //  public TextMeshProUGUI helicase;
    
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

    public GameObject tutorialText;
    public GameObject tutorialText2;
    
    public TextMeshProUGUI score;
    public GameObject start;
    
    
    //Reference to the parent
    public GameObject cameraParent;
   
    void Start()
    {
      //  helicase.text = null;
        inputMade2 = false;
        deleteCounter = 0;
        deleteCounter2 = 0;
        deleteThree = false;
        time = 0.2f;
        pressCount = 0;
        winner = false;
        tutorialText.SetActive(false);
        start.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (cameraCinematic.startCinematic == false && pressCount == 0)
        {
            tutorialText.SetActive(true);
        }
    //player 1 inputs/controller
        if ((Input.GetKeyDown(KeyCode.A) || Input.GetButtonDown("P1 Left")) && Mutation1.Mutation < 3 && cameraCinematic.startCinematic == false && winner != true)
        {
            tutorialText.SetActive(false);
            Instantiate(prefabA, transform.position, transform.rotation);
            StartCoroutine(MoveUp2());
            p1Progress.fillAmount += 0.05f;
            StartCoroutine(ResetBool2());
            progressBar.fillAmount += 0.02f;
            pressCount += 1;
            inputMade2 = true;

            //player1ShakeChange
            CameraShaker.GetInstance("Main Camera").ShakeOnce(2f, 1f, .1f, 1);
        }
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetButtonDown("P1 Up"))&& Mutation1.Mutation < 3 && cameraCinematic.startCinematic == false && winner != true)
        {
            tutorialText.SetActive(false);
            Instantiate(prefabG, transform.position, transform.rotation);
            StartCoroutine(MoveUp2());
            p1Progress.fillAmount += 0.05f;
            progressBar.fillAmount += 0.02f;
            pressCount += 1;
            inputMade2 = true;

            CameraShaker.GetInstance("Main Camera").ShakeOnce(2f, 2f, .1f, 1);

        }
        if ((Input.GetKeyDown(KeyCode.S) || Input.GetButtonDown("P1 Down"))&& Mutation1.Mutation < 3 && cameraCinematic.startCinematic == false && winner != true)
        {
            tutorialText.SetActive(false);
            Instantiate(prefabC, transform.position, transform.rotation);
            StartCoroutine(MoveUp2());
            p1Progress.fillAmount += 0.05f;
            progressBar.fillAmount += 0.02f;
            pressCount += 1;
            StartCoroutine(ResetBool2());
            inputMade2 = true;
            
            CameraShaker.GetInstance("Main Camera").ShakeOnce(2f, 2f, .1f, 1);


        }
        if ((Input.GetKeyDown(KeyCode.D)|| Input.GetButtonDown("P1 Right") ) && Mutation1.Mutation < 3 && cameraCinematic.startCinematic == false && winner != true)
        {
            tutorialText.SetActive(false);
            Instantiate(prefabT, transform.position, transform.rotation);
            StartCoroutine(MoveUp2());
            p1Progress.fillAmount += 0.05f;
            progressBar.fillAmount += 0.02f;
            pressCount += 1;
            StartCoroutine(ResetBool2());
            inputMade2 = true;
            
            CameraShaker.GetInstance("Main Camera").ShakeOnce(2f, 2f, .1f, 1);
        }
        

        if (Mutation1.Mutation == 3 && deleteCounter2 < pressCount)
        {
            Debug.Log("oopyy");
            progressBar.fillAmount = 0f;
            float myMaxDistance2 = 2000f;
            RaycastHit downHit;
            Ray checkRay2 = new Ray(transform.position, -transform.up);
            time -= Time.deltaTime;
            if (time <= 0)
            {
                StartCoroutine(MoveDown2());
                Physics.Raycast(checkRay2, out downHit, myMaxDistance2);
                Destroy(downHit.transform.gameObject);
                ScoreText1.Score = 0;
                time = 0.02f;
                deleteCounter2++;
            }
        }

        score.text = (ScoreText1.Score).ToString();

        if (score.text == "5")
        {
            winner = true;
            tutorialText.SetActive(true);
            tutorialText.GetComponent<TextMeshProUGUI>().text = "Ready!";
            cam1.backgroundColor =color1;
            //SceneManager.LoadScene (2);
        }

        if (winner == true && dnaChain3.winner2 == true)
        {
            start.SetActive(true);
            tutorialText.SetActive(false);
            tutorialText2.SetActive(false);
            if (Input.anyKeyDown)
            {
                SceneManager.LoadScene(1);
            }
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
            cameraParent.GetComponent<Transform>().Translate(new Vector3(0, 2f));
        }
        
        IEnumerator MoveDown2()
        {
            yield return  new WaitForSeconds(0.1f);
            this.GetComponent<Transform>().Translate(new Vector3(0, -2f));
        }

    }
}
