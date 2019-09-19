using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Usage: Spawn the prefabs randomly in a straight line for the DNA Chain
//
public class dnaSpawn : MonoBehaviour
{
    public dnaChain myDNAPrefab;

    public int maxDNACount = 100; //how many DNA should we be able to make?
    List<dnaChain> myDNAList = new List<dnaChain>(); //list of all the DNA that spawns
    // Start is called before the first frame update
    void Start()
    {
        int currentDNACount = 0;
        while (currentDNACount < maxDNACount)
        {
            dnaChain newDNAClone = (dnaChain) Instantiate(myDNAPrefab, transform.position, transform.rotation);
            myDNAList.Add(newDNAClone);
            currentDNACount++;
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
    //player input:
    //if player presses the correct key then another key should spawn
    
    
}
