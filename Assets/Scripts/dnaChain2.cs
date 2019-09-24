using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//usage: put this on my DNA prefabs to spawn the prefabs randomly 
//also create matching pairs for 
//basically assign prefabs

public class dnaChain2 : MonoBehaviour
{
    //prefabs for the player input
    public GameObject prefabA;

    public GameObject prefabT;

    public GameObject prefabC;

    public GameObject prefabG;
    
    public Image p2Progress;

    
    //time left for player objects to appear
    public float timeLeft = 0f;
    
    // Start is called before the first frame update
    void Start()
    {
  
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Instantiate(prefabA, transform.position, transform.rotation);
            this.GetComponent<Transform>().Translate(new Vector3(0, 2f));
            p2Progress.fillAmount += .01f;

        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Instantiate(prefabG, transform.position, transform.rotation);
            this.GetComponent<Transform>().Translate(new Vector3(0, 2f));
            p2Progress.fillAmount += .01f;


        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Instantiate(prefabC, transform.position, transform.rotation);
            this.GetComponent<Transform>().Translate(new Vector3(0, 2f));
            p2Progress.fillAmount += .01f;


        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Instantiate(prefabT, transform.position, transform.rotation);
            this.GetComponent<Transform>().Translate(new Vector3(0, 2f));
            p2Progress.fillAmount += .01f;


        }
        
    
        
    }
}
