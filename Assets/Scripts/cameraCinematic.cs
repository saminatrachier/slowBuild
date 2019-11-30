using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraCinematic : MonoBehaviour
{
    public GameObject player;

    public static bool startCinematic;
    
    public GameObject camera1;
    public GameObject camera2;

    public float p1Vert;

    public float p2Vert;
    // Start is called before the first frame update
    void Start()
    {
        startCinematic = true;

        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug code that checks the axis of the controllers
        p1Vert = Input.GetAxis("P1 Vertical");
        p2Vert = Input.GetAxis("P2 Vertical");
        
        if (startCinematic == true)
        {
            transform.position = Vector3.Lerp(transform.position, player.transform.position, 0.5f * Time.deltaTime);
        }
        
        if (transform.position.y <= 1f)
        {
            startCinematic = false;
        }
        
        if ((Input.GetKey(KeyCode.RightShift)) || Input.GetAxis("P2 Vertical") <= -1 || Input.GetAxis("P2 Vertical MAC") <= -1 && Mutation2.Mutation < 3 && startCinematic == false)
        {
            camera2.GetComponent<Transform> ().Translate (new Vector3 (0, 0.1f));

        }
        else if ((Input.GetKey(KeyCode.Space)) || Input.GetAxis("P1 Vertical") <= -1 || Input.GetAxis("P1 Vertical MAC") <= -1  && Mutation2.Mutation < 3 && startCinematic == false)
        {
            camera1.GetComponent<Transform> ().Translate (new Vector3 (0, 0.1f));

        }
        else if ((Input.GetKey(KeyCode.LeftShift)) || Input.GetAxis("P1 Vertical") >= 1 || Input.GetAxis("P1 Vertical MAC") >= 1  && Mutation2.Mutation < 3 && startCinematic == false)
        {
            if (transform.position.y >= 1)
            {
                camera1.GetComponent<Transform> ().Translate (new Vector3 (0, -0.1f));
            }
        }
        else if ((Input.GetKey(KeyCode.Return)) || Input.GetAxis("P2 Vertical") >= 1 || Input.GetAxis("P2 Vertical MAC") >= 1  && Mutation2.Mutation < 3 && startCinematic == false)
        {
            if (transform.position.y >= 1)
            {
                camera2.GetComponent<Transform> ().Translate (new Vector3 (0, -0.1f));
            }
        }
    }
}
