using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Roullete : MonoBehaviour
{
    public static int StartCave;

    public GameObject WheelActive;

    public RectTransform wheel;
    public Text finalText;

    List<Text> contents;

    public float initSpeed;
    public float breakSpeed;
    public float keepSpeedTimeMin, KeepSpeedTieMax;

    float currentTime;
    float currentSpeed;

    bool rolling;
    bool isCouroutine = true;

    // Start is called before the first frame update
    void Start()
    {
        contents = new List<Text>();

        for (int i = 0; i < wheel.childCount; i++)
        {
            contents.Add(wheel.GetChild(i).GetComponent<Text>());

            Debug.Log(contents[i].text);
        }

    }

    void Update()
    {
        if (rolling)
        {
            currentTime -= Time.deltaTime;

            if (currentTime <= 0)
            {
                currentSpeed -= breakSpeed * Time.deltaTime;
            }

            wheel.Rotate(0, 0, -currentSpeed * Time.deltaTime);

            if (currentSpeed <= 0)
            {
                rolling = false;

                float halfAng = 360 / contents.Count * 0.5f;
                float minAng = 360;
                Text targetText = null;

                for(int i=0; i<contents.Count; i++)
                {
                    Vector3 localDir = Quaternion.Euler(0, 0, halfAng + (i * 360 / contents.Count)) * Vector3.up;

                    float ang = Vector3.Angle(wheel.TransformDirection(localDir), Vector3.up);

                    if (ang <= minAng)
                    {
                        minAng = ang;
                        targetText = contents[i];
                        StartCave = i;
                    }
                }
                finalText.text = targetText.text;

            }
        }
        else
        {
            if (!isCouroutine)
            {
                StartCoroutine("delayTime");
            }
        }
    }

    IEnumerator delayTime()
    {
        isCouroutine = true;
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("GameStage");

        isCouroutine = false;
    }

    public void TitleClick()
    {
        WheelActive.SetActive(true);
        GetComponentsInChildren<Text>()[0].enabled = false;
        GetComponentsInChildren<Text>()[1].enabled = false;
        isCouroutine = false;

        currentSpeed = initSpeed;
        currentTime = UnityEngine.Random.Range(keepSpeedTimeMin, KeepSpeedTieMax);
        rolling = true;
    }
}
