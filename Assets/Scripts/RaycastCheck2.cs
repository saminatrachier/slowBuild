using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//USAGE: This script goes on the Raycast 2 Gameobject. This block will always check
//The current Enemy DNA Block.
//PURPOSE: The raycast from this block will grab the information of the opposing block for the
//steal mechanic. When the steal mechanic is activated, it will teleport the prefab away.
public class RaycastCheck2 : MonoBehaviour
{
   
    void Start()
    {
        
    }


    void Update()
    {
        Ray checkRay = new Ray(transform.position, -transform.right);

        RaycastHit hit;

        float myMaxDistance = 5f;
        Debug.DrawRay(checkRay.origin, checkRay.direction * myMaxDistance, Color.red);
        if (Physics.Raycast(checkRay, out hit,myMaxDistance) && hit.transform.tag =="G")
        {
            
            Debug.Log("The Current Enemy Block is a G");

            if (DeletionMutation1.stealDNA)
            {
                Debug.Log("Steal the G");
                hit.transform.position = Vector3.up;
                DeletionMutation1.stealDNA = false;
            }

        }
        else if (hit.transform.tag == "C")
        {
            if (DeletionMutation1.stealDNA)
            {
                Debug.Log("Steal the C");
                DeletionMutation1.stealDNA = false;
            }
        }
        else if (hit.transform.tag == "A")
        {
            if (DeletionMutation1.stealDNA)
            {
                Debug.Log("Steal the A");
                DeletionMutation1.stealDNA = false;
            }
        }
        else if (hit.transform.tag == "T")
        {
            if (DeletionMutation1.stealDNA)
            {
                Debug.Log("Steal the T");
                DeletionMutation1.stealDNA = false;
            }
        }



    }
}
