﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//USAGE: put this on the spawning prefabs to make sure the player has the correct input
//put this on the spawning dna and put a tag on the player's pieces

//player's G component score and mutation tracking

public class player1G : MonoBehaviour
{
    public GameObject GChain;

    public GameObject C;
    // Start is called before the first frame update
    void Start()
    {
        Ray myRay = new Ray(transform.position, -transform.right);
        Debug.Log("send help");
        RaycastHit hit;

        float myMaxDistance = 5f;
        Debug.DrawRay(myRay.origin, myRay.direction * myMaxDistance, Color.yellow);
        if (Physics.Raycast(myRay, out hit,myMaxDistance)&& hit.transform.tag =="C")
        {
            
            Debug.Log("Score++");
            ScoreText1.Score += 1;
            FindObjectOfType<AudioManager>().Play("Correct");


        }
        else
        {
            Debug.Log("Mutation++");
            Mutation1.Mutation += 1;
            FindObjectOfType<AudioManager>().Play("Wrong");
        } 
    }

    // Update is called once per frame
    void Update()
    {
      
        
        
        // void OnCollisionEnter(Collision other)
   // {
    //    if (other.gameObject == T)
      //  {
        //    Debug.Log("score++");
            //create a score script
            //Score++;

        //}
        //else
        //{
          //  Debug.Log("Mutation");
            //create a script to count mutations
            //Mutation++;
        //}
    }
}
