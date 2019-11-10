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
        StartCoroutine("OneTime");
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

    IEnumerator OneTime()
    {
        Debug.Log("OneTime");
        yield return new WaitForSeconds(1f);
        switch (Roullete.StartCave)
        {
            case 0:
                caveList[6].GetComponent<CaveDefault>().isDefault = false;
                break;
            case 1:
                caveList[1].GetComponent<CaveDefault>().isDefault = false;
                break;
            case 2:
                caveList[2].GetComponent<CaveDefault>().isDefault = false;
                break;
            case 3:
                caveList[12].GetComponent<CaveDefault>().isDefault = false;
                break;
            case 4:
                caveList[13].GetComponent<CaveDefault>().isDefault = false;
                break;
            case 5:
                caveList[9].GetComponent<CaveDefault>().isDefault = false;
                break;
            case 6:
                caveList[8].GetComponent<CaveDefault>().isDefault = false;
                break;
            case 7:
                caveList[7].GetComponent<CaveDefault>().isDefault = false;
                break;
        }
    }
}
