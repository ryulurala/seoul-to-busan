using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Population : MonoBehaviour
{
    [SerializeField]
    private int maxNumber;

    [SerializeField]
    private Text objNumber;

    [SerializeField]
    private float increaseSpeed;

    private float temp;

    private bool emptyPlace;

    // Start is called before the first frame update
    void Start()
    {
        emptyPlace = true;
    }
    // Update is called once per frame
    void Update()
    {
        temp += (0.1f * increaseSpeed * Time.deltaTime);
        objNumber.text = ((int)temp).ToString();
    }
}
