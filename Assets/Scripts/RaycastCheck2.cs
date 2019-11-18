using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//USAGE: This script goes on the Raycast 2 Gameobject. This block will always check
//The current Enemy DNA Block.
//PURPOSE: The raycast from this block will grab the information of the opposing block for the
//steal mechanic. When the steal mechanic is activated, it will delete the prefab away.
public class RaycastCheck2 : MonoBehaviour
{
    public static bool gotG;

    public static bool gotC;

    public static bool gotA;

    public static bool gotT;

    private bool blockStolen;


    //Scripts that reference DNA Chain 2 game objects

    public GameObject prefabG;

    public GameObject prefabC;

    public GameObject prefabA;

    public GameObject prefabT;





    void Start()
    {
        gotG = false;
        gotC = false;
        gotA = false;
        gotT = false;





    }


    void Update()
    {

        //First, we create a raycast that this object will make to check what the current opposing block is.
        Ray checkRay = new Ray(transform.position, -transform.right);
        RaycastHit hit;
        float myMaxDistance = 5f;


        //Then we check what each raycast is hitting
        if (Physics.Raycast(checkRay, out hit, myMaxDistance) && hit.transform.tag == "G")
        {
            //The tags help us tell which is which.
            Debug.Log("The Current Enemy Block is a G");

            //Now we gotta check if we can steal DNA. This is handled in DeletionMutation1
            if (DeletionMutation1.stealDNA)
            {
                //Another check, but we got to make sure the player whose being stolen from made an input first before we still. This is just to prevent 
                //the opposing block from being deleted before the player has a chance to at least score a point.
                //For now just makes sure this stays.
                if (dnaChain2.inputMade)
                {
                    Debug.Log("Steal the G");
                    Destroy(hit.transform.gameObject);
                    DeletionMutation1.stealDNA = false;
                    gotG = true;
                }

            }

        }
        else if (hit.transform.tag == "C")
        {
            if (DeletionMutation1.stealDNA)
            {

                if (dnaChain2.inputMade)
                {
                    Debug.Log("Steal the C");
                    Destroy(hit.transform.gameObject);
                    DeletionMutation1.stealDNA = false;
                    gotC = true;
                }

            }
        }
        else if (hit.transform.tag == "A")
        {
            if (DeletionMutation1.stealDNA)
            {

                if (dnaChain2.inputMade)
                {
                    Debug.Log("Steal the A");
                    Destroy(hit.transform.gameObject);
                    DeletionMutation1.stealDNA = false;
                    gotA = true;
                }

            }
        }
        else if (hit.transform.tag == "T")
        {
            if (DeletionMutation1.stealDNA)
            {

                if (dnaChain2.inputMade)
                {
                    Debug.Log("Steal the T");
                    Destroy(hit.transform.gameObject);
                    DeletionMutation1.stealDNA = false;
                    gotT = true;
                }

            }
        }

        if (Physics.Raycast(checkRay, out hit, myMaxDistance) && Input.GetKeyDown(KeyCode.Q))
        {
            if (DeletionMutation1.createG)
            {
                //We need to get the opposing block to be deleted
                Destroy(hit.transform.gameObject);
                //then raycastcheck 2 creates a new block in its place.
                Instantiate(prefabG, new Vector3(47, 2, 0), transform.rotation);
                DeletionMutation1.createG = false;
            }

            if (DeletionMutation1.createC)
            {
                //We need to get the opposing block to be deleted
                Destroy(hit.transform.gameObject);
                //then raycastcheck 2 creates a new block in its place.
                Instantiate(prefabC, new Vector3(47, 2, 0), transform.rotation);
                DeletionMutation1.createC = false;
            }

            if (DeletionMutation1.createA)
            {
                //We need to get the opposing block to be deleted
                Destroy(hit.transform.gameObject);
                //then raycastcheck 2 creates a new block in its place.
                Instantiate(prefabA, new Vector3(47, 2, 0), transform.rotation);
                DeletionMutation1.createA = false;


                if (DeletionMutation1.createT)
                {
                    //We need to get the opposing block to be deleted
                    Destroy(hit.transform.gameObject);
                    //then raycastcheck 2 creates a new block in its place.
                    Instantiate(prefabT, new Vector3(47, 2, 0), transform.rotation);
                    DeletionMutation1.createT = false;
                }
            }


        }
    }
}
