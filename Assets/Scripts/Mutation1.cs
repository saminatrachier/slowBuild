using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mutation1 : MonoBehaviour
{
    public Color color3 = new Color(255, 0, 0,255); //bright red

    public Color color2 = new Color(255, 85, 85,255);//medium red

    public Color color1 = new Color(255, 185, 185, 255); //light red

    public Camera cam1;

    public static int Mutation = 0;
    public GameObject gameOverText;

    // Start is called before the first frame update
    void Start()
    {
        cam1 = GetComponent<Camera>();
        gameOverText.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (Mutation == 1)
        {
            cam1.backgroundColor =color1;
        }

        if (Mutation == 2)
        {
            cam1.backgroundColor = color2;
        }

        if (Mutation == 3)
        {
            cam1.backgroundColor = color3;
            gameOverText.SetActive(true);

        }
    }
}
