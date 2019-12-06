using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using UnityEngine;
using TMPro;

//USAGE: This script is where information relating to the Stealing/Insertion Mechanic is held.
//PURPOSE: When Q is pressed after the power up bar is filled up, stealDNA is set to true. 
//Meanwhile, RaycastCheck2 checks if StealDNA is set to true. if it is, it will steal the current block in front of it, ie basically deleting it.
//It should then send the information back to this script, which it will hold on to, until q is pressed again.
//It then tells raycast check 2 or some other script to, delete the opposing prefab and replace it with the one on hold.

//THE TRICK: We don't actually hold on to the prefab that gets stolen, but rather we get information about the prefab that was deleted that we hold on to.
//This script is basically allowing raycastcheck 2 to be able to instantite a prefab based on the information here.

//Could we theeoritcally do this all in one script? Perhaps, but I think its nicer to kinda split it up so that one script isn't super bloated.
public class DeletionMutation1 : MonoBehaviour
{
    public static bool stealDNA;
    public bool enableSteal;
    
    //Variables that allow for a new prefab to be made
    public static bool createG;
    public static bool createC;
    public static bool createA;
    public static bool createT;

    public TextMeshProUGUI holdText;
    
    //Refernece to the Progress Bar for Player 1
    public GameObject player1Spawn;
    public dnaChain dnaChainScript; 
    
    //Music Reference
    private bool playOnce;
    
    void Start()
    {
        stealDNA = false;
        //This variable should be set to false at start
        //And must turn true when the progress/combo bar is filled up
        enableSteal = false;

        createG = false;
        createC = false;
        createA = false;
        createT = false;

        holdText.text = "HOLD:";

        dnaChainScript = player1Spawn.GetComponent<dnaChain>();

        playOnce = true;

    }

    
    void Update()
    {
        //Temporary debug key that will simulate getting the bar filled up 
        if (dnaChainScript.p1Progress.fillAmount == 1.0f)
        {
            enableSteal = true;
            RaycastCheck2.isDestroyed = false;
         
            //When progress bar is full, reset isDestoryed from raycastcheck2 to false;
        }

        if (enableSteal == true)
        {
            if (Input.GetKeyDown(KeyCode.Q) || (Input.GetButtonDown("P1 Delete")))
            {
                dnaChainScript.p1Progress.fillAmount = 0.0f;
                stealDNA = true;

                if (playOnce == false)
                {
                    playOnce = true;
                }
                
                if (FindObjectOfType<RaycastCheck2>().playOnce == false)
                {
                    FindObjectOfType<RaycastCheck2>().playOnce = true;
                }

          
                
               
            }

            if (RaycastCheck2.gotG)
            {
                //Put a UI thing that shows the current holding dna block;
                
                holdText.text = "HOLD: G";
                createG = true;
                
                if (playOnce)
                {
                    FindObjectOfType<AudioManager>().Play("Stolen");
                    playOnce = false;
                }
            }

            if (RaycastCheck2.gotC)
            {
               
                holdText.text = "HOLD: C";
                createC = true;
                
                if (playOnce)
                {
                    FindObjectOfType<AudioManager>().Play("Stolen");
                    playOnce = false;
                }
            }
            
            if (RaycastCheck2.gotA)
            {
                holdText.text = "HOLD: A";
                createA = true;
                
                if (playOnce)
                {
                    FindObjectOfType<AudioManager>().Play("Stolen");
                    playOnce = false;
                }
            }
            
            if (RaycastCheck2.gotT)
            {
               
                holdText.text = "HOLD: T";
                createT = true;
            }
        }
       
       
    }
}
