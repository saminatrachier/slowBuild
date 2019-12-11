using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LilBoyScript1 : MonoBehaviour
{
    public GameObject normal;
    public GameObject teeth;
    public GameObject wings;
    public GameObject horns;
    public GameObject tail;
    public GameObject arms;

    public bool chosen = false;
    // Start is called before the first frame update
    void Start()
    {
        normal.SetActive(true);
        chosen = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Mutation2.Mutation == 3)
        {
            int random = Random.Range(1, 6);
            if (random == 1 && chosen == false)
            {
                normal.SetActive(false);
                wings.SetActive(false);
                horns.SetActive(false);
                tail.SetActive(false);
                arms.SetActive(false);
                teeth.SetActive(true);
                chosen = true;
            }
            else if (random == 2 && chosen == false)
            {
                normal.SetActive(false);
                wings.SetActive(true);
                horns.SetActive(false);
                tail.SetActive(false);
                arms.SetActive(false);
                teeth.SetActive(false);
                chosen = true;
            }
            else if (random == 3 && chosen == false)
            {
                normal.SetActive(false);
                wings.SetActive(false);
                horns.SetActive(true);
                tail.SetActive(false);
                arms.SetActive(false);
                teeth.SetActive(false);
                chosen = true;
            }
            else if (random == 4 && chosen == false)
            {
                normal.SetActive(false);
                wings.SetActive(false);
                horns.SetActive(false);
                tail.SetActive(true);
                arms.SetActive(false);
                teeth.SetActive(false);
                chosen = true;
            }
            else if (random == 5 && chosen == false)
            {
                normal.SetActive(false);
                wings.SetActive(false);
                horns.SetActive(false);
                tail.SetActive(false);
                arms.SetActive(true);
                teeth.SetActive(false);
                chosen = true;
            }
        }
        else
        {
            chosen = false;
        }
    }
}
