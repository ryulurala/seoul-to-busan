using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BarController : MonoBehaviour
{
    public Text numberText;
    public Image whiteBar;

    private float whiteBarWidth;

    [SerializeField]
    private int maxNumber;

    // Start is called before the first frame update
    void Start()
    {
        whiteBarWidth = whiteBar.rectTransform.sizeDelta.x;
    }

    // Update is called once per frame
    void Update()
    {
        Refresh();
    }

    void Refresh()
    {
        whiteBar.rectTransform.sizeDelta = new Vector2(float.Parse(numberText.text) / maxNumber * whiteBarWidth , whiteBar.rectTransform.sizeDelta.y);
    }
}
