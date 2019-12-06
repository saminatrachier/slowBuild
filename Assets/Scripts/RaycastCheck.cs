using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastCheck : MonoBehaviour
{
    [Header("Got Variables")]
    public static bool gotG2;

    public static bool gotC2;

    public static bool gotA2;

    public static bool gotT2;

    private bool blockStolen;

    
    [Header("Prefabs Player")]
    //game objects that reference DNA Chain game objects

    public GameObject prefabG;

    public GameObject prefabC;

    public GameObject prefabA;

    public GameObject prefabT;
    
    //Reference position of the blocks

    public Vector3 opposingBlockPos2;

    public Vector3 thisBlockPos2;
    
    //Variable to check if the prefab has been deleted
    public static bool isDestroyed2;
    
    //Reference to Music
    public bool playOnce;

    void Start()
    {
        gotG2 = false;
        gotC2 = false;
        gotA2 = false;
        gotT2 = false;


        isDestroyed2 = false;

        playOnce = true;

    }

    // Update is called once per frame
    void Update()
    {
         //First, we create a raycast that this object will make to check what the current opposing block is.
        Ray checkRay = new Ray(transform.position, -transform.right);
        //This raycast checks whats below
        Ray checkRay2 = new Ray(transform.position, -transform.up);
        RaycastHit hit;
        RaycastHit downHit;
        float myMaxDistance = 5f;
        float myMaxDistance2 = 2000f;

        thisBlockPos2 = this.transform.position;

        Debug.DrawRay(transform.position, -transform.up, Color.magenta);
        if (Physics.Raycast(checkRay, out hit, myMaxDistance) && hit.transform != null)
        {
            //Then we check what each raycast is hitting
            if (Physics.Raycast(checkRay, out hit, myMaxDistance) && hit.transform.tag == "G")
            {
                //Reference to where the current opposing block is.
                //This helps when replacing the block later
                opposingBlockPos2 = hit.transform.position;
                
                //The tags help us tell which is which.
            
    
                //Now we gotta check if we can steal DNA. This is handled in DeletionMutation1
                if (DeletionMutation2.stealDNA2 && isDestroyed2 == false)
                {
                    //Another check, but we got to make sure the player whose being stolen from made an input first before we still. This is just to prevent 
                    //the opposing block from being deleted before the player has a chance to at least score a point.
                    //For now just makes sure this stays.
                    if (dnaChain.inputMade2)
                    {
                        Debug.Log("Steal the G 2");
                        Destroy(hit.transform.gameObject);
                        DeletionMutation2.stealDNA2 = false;
                        gotG2 = true;
                    }
    
                }

        }
        else if (hit.transform.tag == "C")
        {
            
            //Reference to where the current opposing block is.
            //This helps when replacing the block later
            opposingBlockPos2 = hit.transform.position;
            
            if (DeletionMutation2.stealDNA2 && isDestroyed2 == false)
            {

                if (dnaChain.inputMade2)
                {
                    Debug.Log("Steal the C 2");
                    Destroy(hit.transform.gameObject);
                    DeletionMutation2.stealDNA2 = false;
                    gotC2 = true;
                }

            }
        }
        else if (hit.transform.tag == "A" && isDestroyed2 == false)
        {
            
            //Reference to where the current opposing block is.
            //This helps when replacing the block later
            opposingBlockPos2 = hit.transform.position;
            
            if (DeletionMutation2.stealDNA2)
            {

                if (dnaChain.inputMade2)
                {
                    Debug.Log("Steal the A 2");
                    Destroy(hit.transform.gameObject);
                    DeletionMutation2.stealDNA2 = false;
                    gotA2 = true;
                }

            }
        }
        else if (hit.transform.tag == "T" && isDestroyed2 == false)
        {
            //Reference to where the current opposing block is.
            //This helps when replacing the block later
            opposingBlockPos2 = hit.transform.position;
            
            if (DeletionMutation2.stealDNA2)
            {

                if (dnaChain.inputMade2)
                {
                    Debug.Log("Steal the T 2");
                    Destroy(hit.transform.gameObject);
                    DeletionMutation2.stealDNA2 = false;
                    gotT2 = true;
                }

            }
        }
            
            
        }
        else
        {
            Debug.Log("Raycast is returning null!");
        }

        ///Insertion 
        if ( Input.GetKeyDown(KeyCode.P) || (Input.GetButtonDown("P2 Delete")))
        {
            
           
            
            if (DeletionMutation2.createG2)
            {
                isDestroyed2 = true;
                //We need to get the opposing block to be deleted
                if (hit.transform != null)
                {
                   Destroy(hit.transform.gameObject); 
                }
                    
                    //then raycastcheck 2 creates a new block in its place.
                    //We should get the position of it.
                    StartCoroutine(PlaceBlockG());
                    FindObjectOfType<AudioManager>().Play("Place");
                    DeletionMutation2.createG2 = false;
         
            }

            if (DeletionMutation2.createC2)
            {
                isDestroyed2 = true;
                //We need to get the opposing block to be deleted
                if (hit.transform != null)
                {
                    Destroy(hit.transform.gameObject); 
                }
               
                    //then raycastcheck 2 creates a new block in its place.
                    StartCoroutine(PlaceBlockC());
                    DeletionMutation2.createC2 = false;
             
               
            }

            if (DeletionMutation2.createA2)
            {
                isDestroyed2 = true;
                //We need to get the opposing block to be deleted
                if (hit.transform != null)
                {
                    Destroy(hit.transform.gameObject); 
                }
              
                    //then raycastcheck 2 creates a new block in its place.
                    StartCoroutine(PlaceBlockA());
                    DeletionMutation2.createA2 = false;
       
               
     
            }
            
            if (DeletionMutation2.createT2)
            {
            
                isDestroyed2 = true;
                //We need to get the opposing block to be deleted
                if (hit.transform != null)
                {
                    Destroy(hit.transform.gameObject); 
                }
             
                    //then raycastcheck 2 creates a new block in its place.
                    StartCoroutine(PlaceBlockT());
                    DeletionMutation2.createT2 = false;
            
               
            }


        }

        IEnumerator PlaceBlockG()
        {
            yield return new WaitForSeconds(0.1f);
            Instantiate(prefabG, new Vector3(0, thisBlockPos2.y, 0), transform.rotation);
            Debug.Log("Place the Block In");
            
            ///Now we need to reset things in order to allow the mechanic to be used again.
            
        }
        
        IEnumerator PlaceBlockC()
        {
            yield return new WaitForSeconds(0.1f);
            Instantiate(prefabC, new Vector3(0, thisBlockPos2.y, 0), transform.rotation);
            Debug.Log("Place the Block In");
            
        }
        
        IEnumerator PlaceBlockA()
        {
            yield return new WaitForSeconds(0.1f);
            Instantiate(prefabA, new Vector3(0, thisBlockPos2.y, 0), transform.rotation);
            Debug.Log("Place the Block In");
        }
        
        IEnumerator PlaceBlockT()
        {
            yield return new WaitForSeconds(0.1f);
            Instantiate(prefabT, new Vector3(0, thisBlockPos2.y, 0), transform.rotation);
            Debug.Log("Place the Block In");
        }
    }
}
