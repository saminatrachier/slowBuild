using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerWin : MonoBehaviour
{

    public TextMeshProUGUI endText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (dnaChain.winner == true)
        {
            endText.text = "Player 1 has won!";
        }
        else if (dnaChain2.winner2 == true)
        {
            endText.text = "Player 2 has won!";
        }
        else
        {
            endText.text = "Yeet!";
        }
    }
}
