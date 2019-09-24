using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//usage: put this on my DNA prefabs to spawn the prefabs randomly 
//also create matching pairs for 
//basically assign prefabs

public class dnaChain : MonoBehaviour
{
    //prefabs for the player input
    public GameObject prefabA;

    public GameObject prefabT;

    public GameObject prefabC;

    public GameObject prefabG;
    
    //time left for player objects to appear
    public float timeLeft = 0f;
    
    // Start is called before the first frame update
    void Start()
    {
  
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Instantiate(prefabA, transform.position, transform.rotation);
            this.GetComponent<Transform>().Translate(new Vector3(0, 2f));
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            Instantiate(prefabG, transform.position, transform.rotation);
            this.GetComponent<Transform>().Translate(new Vector3(0, 2f));

        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Instantiate(prefabC, transform.position, transform.rotation);
            this.GetComponent<Transform>().Translate(new Vector3(0, 2f));

        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            Instantiate(prefabT, transform.position, transform.rotation);
            this.GetComponent<Transform>().Translate(new Vector3(0, 2f));

        }
        
    
        
    }
}
