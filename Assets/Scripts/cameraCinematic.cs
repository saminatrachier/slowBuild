using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraCinematic : MonoBehaviour
{
    public GameObject player;

    public static bool startCinematic;
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
    }
}
