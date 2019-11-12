using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using system.collections.generic;



//Usage: Spawn the prefabs randomly in a straight line for the DNA Chain
//Purpose: creates a DNA list for player 1 to match their inputs tp
public class dnaSpawn : MonoBehaviour
{
    //public dnaChain myDNAPrefab;
    public GameObject PrefabA;

    public GameObject PrefabT;

    public GameObject PrefabC;

    public GameObject PrefabG;

    public int maxDNACount = 100; //how many DNA should we be able to make?
    List<GameObject> myDNAList = new List<GameObject>(); //list of all the DNA that spawns

   
    
    // Start is called before the first frame update
    void Start()
    {
        for (int y = 0; y < 100; y++)
        { 
            //position of the prefabs
            Vector3 spawnPosition = new Vector3(0,y*2, 0);


            int currentDNACount = 0;
       
            
            //creates a list of the DNA components prefabs
                myDNAList.Add(PrefabA);
                myDNAList.Add(PrefabC);
                myDNAList.Add(PrefabT);
                myDNAList.Add(PrefabG);

                int prefabIndex = UnityEngine.Random.Range(0, 4);
                Instantiate(myDNAList[prefabIndex], spawnPosition, transform.rotation);
                currentDNACount++;
            //}
        }

        // Update is called once per frame
        void Update()
        {
        }
       

    }
}
