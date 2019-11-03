using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveManager : MonoBehaviour
{
    
    public List<GameObject> caveList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        caveList.Add(GameObject.Find("S_C"));
        caveList.Add(GameObject.Find("In_C"));
        caveList.Add(GameObject.Find("G_C"));
        caveList.Add(GameObject.Find("GA_C"));
        caveList.Add(GameObject.Find("CHB_C"));
        caveList.Add(GameObject.Find("CHN_C"));
        caveList.Add(GameObject.Find("DAEJEON_C"));
        caveList.Add(GameObject.Find("GB_C"));
        caveList.Add(GameObject.Find("GN_C"));
        caveList.Add(GameObject.Find("DAEGU_C"));
        caveList.Add(GameObject.Find("WOO_C"));
        caveList.Add(GameObject.Find("BU_C"));
        caveList.Add(GameObject.Find("JB_C"));
        caveList.Add(GameObject.Find("JN_C"));
        caveList.Add(GameObject.Find("GW_C"));
        caveList.Add(GameObject.Find("JE_C"));
        caveList.Add(GameObject.Find("Dok_C"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
