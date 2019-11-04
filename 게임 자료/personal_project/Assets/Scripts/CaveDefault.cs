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

    private bool isDefault = false;

    Camera mCamera;

    // Start is called before the first frame update
    void Start()
    {
        mCamera = Camera.main;
        caveNumber = Instantiate(caveNumberPrefab, this.transform.position, Quaternion.identity, caveNumberList.transform);
        caveNumber.GetComponent<BarController>().maxNumber = maxPopulation;
        population = 50;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDefault)
        {
            Debug.Log("isDefault = false");
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
            Debug.Log("isDefault = false");
            population += (int)(increaseSpeed * Time.deltaTime);

            caveNumber.GetComponentInChildren<Text>().text = population.ToString();
            caveNumber.transform.position = mCamera.WorldToScreenPoint(this.transform.position + new Vector3(0, 0.6f, 0));
        }
    }
}
