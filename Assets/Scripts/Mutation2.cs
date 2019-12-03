using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//USAGE: put this on player 2's camera to change the background color when a mutation occurs
//purpose: Player 2's visual mutation tracker (screen background color)
public class Mutation2 : MonoBehaviour

{
    public GameObject player;
    public Color color3 = new Color(255, 0, 0,255); //bright red

    public Color color2 = new Color(255, 85, 85,255);//medium red

    public Color color1 = new Color(255, 185, 185, 255); //light red
    
    public Color default1 = new Color(49, 77, 121, 0);

    public Camera cam2;

    public GameObject gameOverText;
    
    public GameObject mutation;

    public float time;
    
    public static int Mutation = 0;
    // Start is called before the first frame update
    void Start()
    {
        Mutation = 0;
        cam2 = GetComponent<Camera>();
        gameOverText.SetActive(false);
        time = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Mutation == 1)
        {
            cam2.backgroundColor =color1;
        }

        if (Mutation == 2)
        {
            cam2.backgroundColor = color2;
        }

        if (Mutation == 3)
        {
            cam2.backgroundColor = color3;
            gameOverText.SetActive(true);

            cam2.transform.position = Vector3.Lerp(cam2.transform.position, player.transform.position, 1.5f * Time.deltaTime);
            if (cam2.transform.position.y <= 1f)
            {
                cam2.backgroundColor = default1;
                gameOverText.SetActive(false); 
                Mutation = 0;
            }

        }
    }

}
