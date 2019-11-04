using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CaveManager : MonoBehaviour
{
    public Text populationNumber;
    public Text landNumber;

    public List<GameObject> caveList = new List<GameObject>();

    private int totalPopulation;
    private int totalLand;
    private bool isOwn = false;

    // Start is called before the first frame update
    void Start()
    {
        totalPopulation = 0;
        totalLand = -1;
        caveList.Add(GameObject.Find("S_C")); // 1
        caveList.Add(GameObject.Find("In_C")); // 2
        caveList.Add(GameObject.Find("G_C")); // 3
        caveList.Add(GameObject.Find("GA_C")); // 4
        caveList.Add(GameObject.Find("CHB_C")); // 5
        caveList.Add(GameObject.Find("CHN_C")); // 6
        caveList.Add(GameObject.Find("DAEJEON_C")); // 7
        caveList.Add(GameObject.Find("GB_C")); // 8
        caveList.Add(GameObject.Find("GN_C")); // 9
        caveList.Add(GameObject.Find("DAEGU_C")); // 10
        caveList.Add(GameObject.Find("WOO_C")); // 11
        caveList.Add(GameObject.Find("BU_C")); // 12
        caveList.Add(GameObject.Find("JB_C")); // 13
        caveList.Add(GameObject.Find("JN_C")); // 14
        caveList.Add(GameObject.Find("GW_C")); // 15
        caveList.Add(GameObject.Find("JE_C")); // 16
        caveList.Add(GameObject.Find("Dok_C")); // 17
    }

    // Update is called once per frame
    void Update()
    {
        if (!isOwn)
        {
            for (int i = 0; i < caveList.Count; i++)
            {
                if (caveList[i].GetComponent<CaveDefault>().population > 0)
                {
                    isOwn = true;
                }
            }
        }
        else
        {
            for (int i = 0; i < caveList.Count; i++)
            {
                if (caveList[i].GetComponent<CaveDefault>().population > 0)
                {
                    totalPopulation += caveList[i].GetComponent<CaveDefault>().population;
                    totalLand++;
                }
            }
            populationNumber.text = totalPopulation.ToString();
            landNumber.text = totalLand.ToString();
            totalPopulation = 0;
            totalLand = 0;
        }
    }
}
