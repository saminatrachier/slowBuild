using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//USAGE: This script goes on the Raycast 2 Gameobject. This block will always check
//The current Enemy DNA Block.
//PURPOSE: The raycast from this block will grab the information of the opposing block for the
//steal mechanic. When the steal mechanic is activated, it will delete the prefab away.
public class RaycastCheck3 : MonoBehaviour
{
    [Header("Got Variables")]
    public static bool gotG;

    public static bool gotC;

    public static bool gotA;

    public static bool gotT;

    private bool blockStolen;

    
    [Header("Prefabs Player 2")]
    //game objects that reference DNA Chain 2 game objects

    public GameObject prefabG;

    public GameObject prefabC;

    public GameObject prefabA;

    public GameObject prefabT;
    
    //Reference position of the  blocks

    public Vector3 opposingBlockPos;

    public Vector3 thisBlockPos;
    
    //Variable to check if the prefab has been deleted
    public static bool isDestroyed;

    //Music Reference
    public bool playOnce;
    
    //Finally a reference to DeletionMutation1
    public GameObject dnaSpanwer1;
    public DeletionMutation1 deleteScript1;
    
   // public TextMeshProUGUI deletion;
    public float timer;

    void Start()
    {
        gotG = false;
        gotC = false;
        gotA = false;
        gotT = false;


        isDestroyed = false;


        playOnce = true;

        deleteScript1 = dnaSpanwer1.GetComponent<DeletionMutation1>();

    }


    void Update()
    {
     //   if (deletion.text == "INSERTION")
    //    {
     //       timer += Time.deltaTime;
     //   }

      //  if (timer >= 1f)
      //  {
       //     deletion.text = " ";
       // }
        //First, we create a raycast that this object will make to check what the current opposing block is.
        Ray checkRay = new Ray(transform.position, -transform.forward);
        Ray checkRay2 = new Ray(transform.position, -transform.up);
        RaycastHit hit;
        RaycastHit downHit;
        float myMaxDistance = 5f;
        float myMaxDistance2 = 2000f;

        Debug.Log(isDestroyed);

        thisBlockPos = this.transform.position;

        Debug.DrawRay(transform.position, -transform.forward, Color.magenta);
        if (Physics.Raycast(checkRay, out hit, myMaxDistance) && hit.transform != null)
        {
            //Then we check what each raycast is hitting
        if (Physics.Raycast(checkRay, out hit, myMaxDistance) && hit.transform.tag == "G")
        {
            Debug.Log("OOOP");
            //Reference to where the current opposing block is.
            //This helps when replacing the block later
            opposingBlockPos = hit.transform.position;
            
            //The tags help us tell which is which.
            //Debug.Log("The Current Enemy Block is a G");

            //Now we gotta check if we can steal DNA. This is handled in DeletionMutation1
            if (DeletionMutation1.stealDNA && isDestroyed == false)
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
            //Reference to where the current opposing block is.
            //This helps when replacing the block later
            opposingBlockPos = hit.transform.position;
            
            if (DeletionMutation1.stealDNA && isDestroyed == false)
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
        else if (hit.transform.tag == "A" && isDestroyed == false)
        {
            //Reference to where the current opposing block is.
            //This helps when replacing the block later
            opposingBlockPos = hit.transform.position;
            
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
        else if (hit.transform.tag == "T" && isDestroyed == false)
        {
            //Reference to where the current opposing block is.
            //This helps when replacing the block later
            opposingBlockPos = hit.transform.position;
            
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
            
            
        }
        else
        {
            Debug.Log("Raycast is returning null!");
        }


        ///Insertion 
        if ( Input.GetKeyDown(KeyCode.Q) || (Input.GetButtonDown("P1 Delete")))
        {
            
            
            if (DeletionMutation1.createG)
            {
                FindObjectOfType<AudioManager>().Play("Mechanic3");
            
             //   if (timer <= 1f)
            //    {
             //       deletion.text = "INSERTION";
            //    }
                isDestroyed = true;
                //We need to get the opposing block to be deleted
                if (hit.transform != null)
                {
                   Destroy(hit.transform.gameObject); 
                }
                    
                    //then this object creates a new block in its place.
                    //We should get the position of it.
                    StartCoroutine(PlaceBlockG());
                    DeletionMutation1.createG = false;

                    if (playOnce)
                    {
                       FindObjectOfType<AudioManager>().Play("Place");
                       playOnce = false;
                    }
                    
                    //We need to reset everything now in order to allow this mechanic to happen again.
                    deleteScript1.enableSteal = false;
                    deleteScript1.holdText.text = "NOT HOLDING";
                        //Note to self: I did the long way around of calling DeletionMutation1. Might as well keep it for cocnsitency.
                        //Then again the easy wasy was for static variables so...

            }

            if (DeletionMutation1.createC)
            {
                FindObjectOfType<AudioManager>().Play("Mechanic3");
            
                if (timer <= 1f)
                {
                  //  deletion.text = "INSERTION";
                }
                isDestroyed = true;
                //We need to get the opposing block to be deleted
                if (hit.transform != null)
                {
                    Destroy(hit.transform.gameObject); 
                }
               
                    //then raycastcheck 2 creates a new block in its place.
                    StartCoroutine(PlaceBlockC());
                    DeletionMutation1.createC = false;
                    
                    if (playOnce)
                    {
                        FindObjectOfType<AudioManager>().Play("Place");
                        playOnce = false;
                    }
                    
                    //We need to reset everything now in order to allow this mechanic to happen again.
                    deleteScript1.enableSteal = false;
                    deleteScript1.holdText.text = "NOT HOLDING";
                    
             
               
            }

            if (DeletionMutation1.createA)
            {
                FindObjectOfType<AudioManager>().Play("Mechanic3");
            
                if (timer <= 1f)
                {
                 //   deletion.text = "INSERTION";
                }
                isDestroyed = true;
                //We need to get the opposing block to be deleted
                if (hit.transform != null)
                {
                    Destroy(hit.transform.gameObject); 
                }
              
                    //then raycastcheck 2 creates a new block in its place.
                    StartCoroutine(PlaceBlockA());
                    DeletionMutation1.createA = false;
                    
                    if (playOnce)
                    {
                        FindObjectOfType<AudioManager>().Play("Place");
                        playOnce = false;
                    }
       
               
                    //We need to reset everything now in order to allow this mechanic to happen again.
                    deleteScript1.enableSteal = false;
                    deleteScript1.holdText.text = "NOT HOLDING";
     
            }
            
            if (DeletionMutation1.createT)
            {
                FindObjectOfType<AudioManager>().Play("Mechanic3");
            
                if (timer <= 1f)
                {
                 //   deletion.text = "INSERTION";
                }
                isDestroyed = true;
                //We need to get the opposing block to be deleted
                if (hit.transform != null)
                {
                    Destroy(hit.transform.gameObject); 
                }
             
                    //then raycastcheck 2 creates a new block in its place.
                    StartCoroutine(PlaceBlockT());
                    DeletionMutation1.createT = false;
                    
                    if (playOnce)
                    {
                        FindObjectOfType<AudioManager>().Play("Place");
                        playOnce = false;
                    }
                    
                    //We need to reset everything now in order to allow this mechanic to happen again.
                    deleteScript1.enableSteal = false;
                    deleteScript1.holdText.text = "NOT HOLDING";
            
               
            }


        }

        IEnumerator PlaceBlockG()
        {
            yield return new WaitForSeconds(0.1f);
            Instantiate(prefabG, new Vector3(47, thisBlockPos.y, 0), new Quaternion(0f,90f,0f,0f));
            DeletionMutation1.createG = false;
            gotG = false;
            Debug.Log("Place the Block In");
            
      
        }
        
        IEnumerator PlaceBlockC()
        {
            yield return new WaitForSeconds(0.1f);
            Instantiate(prefabC, new Vector3(47, thisBlockPos.y, 0), new Quaternion(0f,90f,0f,0f));
            DeletionMutation1.createC = false;
            gotC = false;
            Debug.Log("Place the Block In");
            
        }
        
        IEnumerator PlaceBlockA()
        {
            yield return new WaitForSeconds(0.1f);
            Instantiate(prefabA, new Vector3(47, thisBlockPos.y, 0), new Quaternion(0f,90f,0f,0f));
            DeletionMutation1.createA = false;
            gotA = false;    
            Debug.Log("Place the Block In");
        }
        
        IEnumerator PlaceBlockT()
        {
            yield return new WaitForSeconds(0.1f);
            Instantiate(prefabT, new Vector3(47, thisBlockPos.y, 0), new Quaternion(0f,90f,0f,0f));
            DeletionMutation1.createT = false;
            gotT = false;
            Debug.Log("Place the Block In");
        }
    }
}
