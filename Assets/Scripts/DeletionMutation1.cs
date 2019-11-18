using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using UnityEngine;

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
    private bool enableSteal;
    
    //Variables that allow for a new prefab to be made
    public static bool createG;
    public static bool createC;
    public static bool createA;
    public static bool createT;
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

    }

    
    void Update()
    {
        //Temporary debug key that will simulate getting the bar filled up 
        if (Input.GetKeyDown(KeyCode.Space))
        {
            enableSteal = true;
        }

        if (enableSteal == true)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                stealDNA = true;
            }

            if (RaycastCheck2.gotG)
            {
                //Put a UI thing that shows the current holding dna block;
                createG = true;
            }

            if (RaycastCheck2.gotC)
            {
                createC = true;
            }
            
            if (RaycastCheck2.gotA)
            {
                createA = true;
            }
            
            if (RaycastCheck2.gotT)
            {
                createT = true;
            }
        }
        else
        {
            Debug.Log("Can't Steal Now. Bar for P2 Needs to Fill");
        }
       
    }
}
