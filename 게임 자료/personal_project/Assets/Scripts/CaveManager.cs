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
        for (int i = 0; i < GameObject.FindGameObjectsWithTag("Cave").Length; i++)
        {
            caveList.Add(GameObject.FindGameObjectsWithTag("Cave")[i]);
        }
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
