using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeletionMutation1 : MonoBehaviour
{
    public static bool stealDNA;
    void Start()
    {
        stealDNA = false;
       
    }

    
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Q))
        {
            stealDNA = true;
        } 
    }
}
