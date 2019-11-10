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
    GameObject bonfire;

    private GameObject personManager;

    [SerializeField]
    private int defaultPopulation;

    [SerializeField]
    private int maxPopulation;

    public int population;

    [Range(4.0f, 8.0f)]
    [SerializeField]
    private float increaseSpeed;

    public bool isDefault;
    private bool isFire = false;

    bool isTextColoring;

    Camera mCamera;

    // Start is called before the first frame update
    void Start()
    {
        isDefault = true;
        mCamera = Camera.main;
        caveNumber = Instantiate(caveNumberPrefab, this.transform.position, Quaternion.identity, caveNumberList.transform);
        caveNumber.GetComponent<BarController>().maxNumber = maxPopulation;

        // Default일 때
        caveNumber.GetComponentInChildren<Text>().color = Color.white;
        caveNumber.GetComponent<Image>().enabled = false;
        caveNumber.GetComponentsInChildren<Image>()[1].enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Default일 때
        if (isDefault)
        {
            
            if (population > defaultPopulation)
            {
                population -= defaultPopulation;
                defaultPopulation = 0;
                isDefault = false;
            }
            else
            {
                defaultPopulation -= population;
                population = 0;
            }

            caveNumber.GetComponentInChildren<Text>().text = defaultPopulation.ToString();

            caveNumber.transform.position = mCamera.WorldToScreenPoint(this.transform.position + new Vector3(0, 0.6f, 0));
        }

        // Default 아닐 때
        else if (!isDefault)
        {
            if (population < maxPopulation)
            {
                population += (int)(10.0f * increaseSpeed * Time.deltaTime);

                if (!isTextColoring)
                {
                    caveNumber.GetComponents<Image>()[0].enabled = true;
                    caveNumber.GetComponentsInChildren<Image>()[1].enabled = true;
                    
                    caveNumber.GetComponentInChildren<Text>().color = Color.cyan;
                }

                caveNumber.GetComponentInChildren<Text>().text = population.ToString();
                caveNumber.transform.position = mCamera.WorldToScreenPoint(this.transform.position + new Vector3(0, 0.6f, 0));

                if (!isFire)
                {
                    bonfire.SetActive(true);
                    isFire = true;
                }
            }
        }
    }
}
