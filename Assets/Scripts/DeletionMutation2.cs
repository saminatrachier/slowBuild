using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DeletionMutation2 : MonoBehaviour
{
    public static bool stealDNA2;
    private bool enableSteal2;
    
    //Variables that allow for a new prefab to be made
    public static bool createG2;
    public static bool createC2;
    public static bool createA2;
    public static bool createT2;

    public TextMeshProUGUI holdText2;
    
    //Refernece to the Progress Bar for Player 1
    public GameObject player2Spawn;
    public dnaChain2 dnaChainScript2; 
    
    void Start()
    {
        stealDNA2 = false;
        //This variable should be set to false at start
        //And must turn true when the progress/combo bar is filled up
        enableSteal2 = true;

        createG2 = false;
        createC2 = false;
        createA2 = false;
        createT2 = false;

        holdText2.text = "HOLD:";

        dnaChainScript2 = player2Spawn.GetComponent<dnaChain2>();

    }

    
    void Update()
    {
        //Temporary debug key that will simulate getting the bar filled up 
        if (dnaChainScript2.p2Progress.fillAmount == 1.0f)
        {
            enableSteal2 = true;
            RaycastCheck2.isDestroyed = false;
           
            //When progress bar is full, reset isDestorye from raycastcheck2 to false;
        }

        if (enableSteal2 == true)
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                dnaChainScript2.p2Progress.fillAmount = 0.0f;
                
                stealDNA2 = true;
            }

            if (RaycastCheck.gotG2)
            {
                //Put a UI thing that shows the current holding dna block;
                holdText2.text = "HOLD: G";
                createG2 = true;
            }

            if (RaycastCheck.gotC2)
            {
                holdText2.text = "HOLD: C";
                createC2 = true;
            }
            
            if (RaycastCheck.gotA2)
            {
                holdText2.text = "HOLD: A";
                createA2 = true;
            }
            
            if (RaycastCheck.gotT2)
            {
                holdText2.text = "HOLD: T";
                createT2 = true;
            }
        }
       
       
    }
}
