using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraCinematic : MonoBehaviour
{
    public GameObject player;

    public static bool startCinematic;
    
    public GameObject camera1;
    public GameObject camera2;
    // Start is called before the first frame update
    void Start()
    {
        startCinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (startCinematic == true)
        {
            transform.position = Vector3.Lerp(transform.position, player.transform.position, 0.5f * Time.deltaTime);
        }
        
        if (transform.position.y <= 1f)
        {
            startCinematic = false;
        }
        
        if ((Input.GetKey(KeyCode.RightShift))&& Mutation2.Mutation < 3 && startCinematic == false)
        {
            camera2.GetComponent<Transform> ().Translate (new Vector3 (0, 0.1f));

        }
        else if ((Input.GetKey(KeyCode.Space))&& Mutation2.Mutation < 3 && startCinematic == false)
        {
            camera1.GetComponent<Transform> ().Translate (new Vector3 (0, 0.1f));

        }
    }
}
