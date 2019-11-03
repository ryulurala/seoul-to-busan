using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CaveDefault : MonoBehaviour
{
    [SerializeField]
    GameObject caveNumberList= null;

    [SerializeField]
    GameObject caveNumberPrefab = null;
    GameObject caveNumber;

    [SerializeField]
    private int defaultPopulation;

    [SerializeField]
    private int maxPopulation;

    public int population;

    [SerializeField]
    private float increaseSpeed;

    private bool isDefault = true;

    Camera mCamera;

    // Start is called before the first frame update
    void Start()
    {
        caveNumber = Instantiate(caveNumberPrefab, this.transform.position, Quaternion.identity, caveNumberList.transform);
        mCamera = Camera.main;
        caveNumber.GetComponent<BarController>().maxNumber = maxPopulation;

    }

    // Update is called once per frame
    void Update()
    {
        if (isDefault)
        {
            if (population > defaultPopulation)
            {
                population -= defaultPopulation;
                isDefault = false;
            }
            else
            {
                defaultPopulation -= population;
            }
            caveNumber.GetComponentInChildren<Text>().text = defaultPopulation.ToString();
            
            caveNumber.transform.position = mCamera.WorldToScreenPoint(this.transform.position + new Vector3(0, 0.6f, 0));
        }
        else if (!isDefault)
        {
            population += (int)(increaseSpeed * Time.deltaTime);
            caveNumber.GetComponentInChildren<Text>().text = population.ToString();
            caveNumber.transform.position = mCamera.WorldToScreenPoint(this.transform.position + new Vector3(0, 0.6f, 0));
        }
    }
}
