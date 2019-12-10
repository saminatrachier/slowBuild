using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using EZCameraShake;
using TMPro;

//PURPOSE: player2 (ARROW KEYS) player controller and progress bar
//usage: put this on  player2enemyspawnmanager to spawn the prefabs randomly 
//basically assign prefabs

public class dnaChain3 : MonoBehaviour
{
    //prefabs for the player input
    public GameObject prefabA;

    public GameObject prefabT;

    public GameObject prefabC;

    public GameObject prefabG;

    public Image p1Progress;
    
    public Image p2Progress;

    public Image progressBar;
    
   // public TextMeshProUGUI helicase;
    //time left for player objects to appear
    public Image timer;

    public static bool winner2;
    public float time;
    public float timeLeft;
    public float maxTime = 60f;
    
    private bool deleteThree;
    private int deleteCounter;
    private int deleteCounter2;
    public int pressCount;
    
    public GameObject tutorialText;
    public GameObject tutorialText2;
    public TextMeshProUGUI score;
    public GameObject start;
    
    public Color color1 = new Color(255, 185, 185, 255); //light red
    public Camera cam1;
    
    //These variables check if input has been made. This is important for the Deletion Mechanic
    //As I need to check if a block has spawn FIRST before deleting the opposing one.
    //This is to fix a bug in where the block is stolen before the player has a chance to input anything, and will thus always get a mutation
    public static bool inputMade;
    public GameObject cameraParent2;
    void Start()
    {
     //  helicase.text = null;
        timeLeft = maxTime;
        inputMade = false;
        deleteCounter = 0;
        deleteCounter2 = 0;
        deleteThree = false;
        time = 0.2f;
        winner2 = false;
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
        
        if ((Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetButtonDown("P2 Left"))&& Mutation2.Mutation < 3 && cameraCinematic.startCinematic == false && winner2 != true)
        {
            tutorialText.SetActive(false);
            Instantiate(prefabA, transform.position, transform.rotation);
            StartCoroutine(MoveUp());
            p2Progress.fillAmount += 0.05f;
            progressBar.fillAmount += 0.02f;
            inputMade = true;
            pressCount += 1;
            StartCoroutine(ResetBool());
            //screenshakep2 change
            CameraShaker.GetInstance("Main Camerap2").ShakeOnce(2f, 1f, .1f, 1);
            

        }
        if ((Input.GetKeyDown(KeyCode.UpArrow)|| Input.GetButtonDown("P2 Up"))&& Mutation2.Mutation < 3 && cameraCinematic.startCinematic == false && winner2 != true)
        {
            tutorialText.SetActive(false);
            Instantiate(prefabG, transform.position, transform.rotation);
            StartCoroutine(MoveUp());
            p2Progress.fillAmount += 0.05f;
            progressBar.fillAmount += 0.02f;
            inputMade = true;
            pressCount += 1;
            StartCoroutine(ResetBool());
            
            CameraShaker.GetInstance("Main Camerap2").ShakeOnce(2f, 2f, .1f, 1);

        }
        if ((Input.GetKeyDown(KeyCode.DownArrow)|| Input.GetButtonDown("P2 Down"))&& Mutation2.Mutation < 3 && cameraCinematic.startCinematic == false && winner2 != true)
        {
            tutorialText.SetActive(false);
            Instantiate(prefabC, transform.position, transform.rotation);
            StartCoroutine(MoveUp());
            p2Progress.fillAmount += 0.05f;
            progressBar.fillAmount += 0.02f;
            inputMade = true;
            pressCount += 1;
            StartCoroutine(ResetBool());
          
            CameraShaker.GetInstance("Main Camerap2").ShakeOnce(2f, 2f, .1f, 1);


        }
        if ((Input.GetKeyDown(KeyCode.RightArrow)|| Input.GetButtonDown("P2 Right") )&& Mutation2.Mutation < 3 && cameraCinematic.startCinematic == false && winner2 != true)
        {
            tutorialText.SetActive(false);
            Instantiate(prefabT, transform.position, transform.rotation);
            StartCoroutine(MoveUp());
            p2Progress.fillAmount += 0.05f;
            progressBar.fillAmount += 0.02f;
            inputMade = true;
            pressCount += 1;
            StartCoroutine(ResetBool());
            
            CameraShaker.GetInstance("Main Camerap2").ShakeOnce(2f, 2f, .1f, 1);
        }
        
        score.text = (ScoreText2.Score2).ToString();
        
        if (score.text == "5")
        {
            winner2 = true;
            tutorialText.SetActive(true);
            tutorialText.GetComponent<TextMeshProUGUI>().text = "Ready!";
            cam1.backgroundColor =color1;
           //SceneManager.LoadScene (2);
        }
        
        if (winner2 == true && dnaChain1.winner == true)
        {
            start.SetActive(true);
            tutorialText.SetActive(false);
            tutorialText2.SetActive(false);
            if (Input.anyKeyDown)
            {
                SceneManager.LoadScene(1);
            }
        }
        
        if (Mutation2.Mutation == 3 && deleteCounter2 < pressCount)
        {
            Debug.Log("oop");
            progressBar.fillAmount = 0f;
            float myMaxDistance2 = 2000f;
            RaycastHit downHit;
            Ray checkRay2 = new Ray(transform.position, -transform.up);
            time -= Time.deltaTime;
            if (time <= 0)
            {
                StartCoroutine(MoveDown());
                Physics.Raycast(checkRay2, out downHit, myMaxDistance2);
                Destroy(downHit.transform.gameObject);
                ScoreText2.Score2 = 0;
                time = 0.02f;
                deleteCounter2++;
            }
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
        cameraParent2.GetComponent<Transform>().Translate(new Vector3(0, 2f));
    }
    
    IEnumerator MoveDown()
    {
        yield return  new WaitForSeconds(0.1f);
        this.GetComponent<Transform>().Translate(new Vector3(0, -2f));
    }
}
