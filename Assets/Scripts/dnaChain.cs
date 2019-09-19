using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//usage: put this on my DNA prefabs to spawn the prefabs randomly 
//also create matching pairs for 
//basically assign prefabs

public class dnaChain : MonoBehaviour
{
    List<GameObject> prefabList = new List<GameObject>();

    public GameObject PrefabA;

    public GameObject PrefabT;

    public GameObject PrefabC;

    public GameObject PrefabG;
    // Start is called before the first frame update
    void Start()
    {
        prefabList.Add(PrefabA);
        prefabList.Add(PrefabC);
        prefabList.Add(PrefabG);
        prefabList.Add(PrefabT);

        int prefabIndex = UnityEngine.Random.Range(0, 4);
        Instantiate(prefabList[prefabIndex]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
