using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.UNetWeaver;

public class DeletionMutation2 : MonoBehaviour
{
    public static bool stealDNA2;
    public bool enableSteal2;
    
    //Variables that allow for a new prefab to be made
    public static bool createG2;
    public static bool createC2;
    public static bool createA2;
    public static bool createT2;

    public TextMeshProUGUI holdText2;

    public TextMeshProUGUI deletion;

    public float timer;
    public float timer2;
    
    //Refernece to the Progress Bar for Player 1
    public GameObject player2Spawn;
    public dnaChain2 dnaChainScript2; 
    
    //Music Reference
    private bool playOnce;
    
    
    void Start()
    {
        deletion.text = null;
        stealDNA2 = false;
        //This variable should be set to false at start
        //And must turn true when the progress/combo bar is filled up
        enableSteal2 = false;

        createG2 = false;
        createC2 = false;
        createA2 = false;
        createT2 = false;

        timer = 0f;
        timer2 = 0f;

        holdText2.text = "HOLD:";

        dnaChainScript2 = player2Spawn.GetComponent<dnaChain2>();
        
        playOnce = true;


    }

    
    void Update()
    {
        //Temporary debug key that will simulate getting the bar filled up 
        if (dnaChainScript2.p2Progress.fillAmount >= 1.0f)
        {
            enableSteal2 = true;
            RaycastCheck2.isDestroyed = false;
           
            //When progress bar is full, reset isDestorye from raycastcheck2 to false;
        }

        if (deletion.text == "DELETION")
        {
            timer += Time.deltaTime;

            if (timer > 1f)
            {
                deletion.text = " ";
            }
        }
        
        if (deletion.text == "INSERTION")
        {
            timer2 += Time.deltaTime;

            if (timer2 > 1f)
            {
                deletion.text = " ";
            }
        }

        if (enableSteal2 == true)
        {
            if (Input.GetKeyDown(KeyCode.P) || (Input.GetButtonDown("P2 Delete")))
            {
                dnaChainScript2.p2Progress.fillAmount = 0.0f;
                if (timer <= 1f)
                {
                    deletion.text = "DELETION";
                }

                if (timer2 <= 1f && timer > 0)
                {
                    deletion.text = "INSERTION";
                }
                stealDNA2 = true;
                if (playOnce == false)
                {
                    playOnce = true;
                }
            }

            if (RaycastCheck.gotG2)
            {
                //Put a UI thing that shows the current holding dna block;
                holdText2.text = "HOLD: G";
                createG2 = true;
                
                if (playOnce)
                {
                    FindObjectOfType<AudioManager>().Play("Stolen");
                    playOnce = false;
                }
            }

            if (RaycastCheck.gotC2)
            {
                holdText2.text = "HOLD: C";
                createC2 = true;
                
                if (playOnce)
                {
                    FindObjectOfType<AudioManager>().Play("Stolen");
                    playOnce = false;
                }
            }
            
            if (RaycastCheck.gotA2)
            {
                holdText2.text = "HOLD: A";
                createA2 = true;
                
                if (playOnce)
                {
                    FindObjectOfType<AudioManager>().Play("Stolen");
                    playOnce = false;
                }
            }
            
            if (RaycastCheck.gotT2)
            {
                holdText2.text = "HOLD: T";
                createT2 = true;
                
                if (playOnce)
                {
                    FindObjectOfType<AudioManager>().Play("Stolen");
                    playOnce = false;
                }
            }
        }
       
       
    }
}
