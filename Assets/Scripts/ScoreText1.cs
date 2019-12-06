using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


//usage: create a UI score counter for player 1 when they make a correct match

public class ScoreText1 : MonoBehaviour
{
    private TextMeshProUGUI text;

    public static int Score;
    
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        Score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
        //text.text = Score.ToString();
    }
}
