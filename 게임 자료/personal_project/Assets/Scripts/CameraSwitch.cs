using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraSwitch : MonoBehaviour
{
    private GameObject pManager;

    private bool isUpdate = false;

    [SerializeField]
    public List<Button> buttons = new List<Button>();

    // Start is called before the first frame update
    void Start()
    {
        Camera.main.GetComponent<CharacterCamera>().CharacterTransform = transform;
        pManager = GameObject.FindGameObjectWithTag("PersonControl");
    }

    // Update is called once per frame
    void Update()
    {
        if (!isUpdate)
        {
            if (pManager.GetComponent<PersonManager>().persons.Count > 0)
            {
                StartCoroutine("UpdatePersonList");
            }
            else
            {
                buttons[0].GetComponent<Text>().text = null;
            }
        }
    }

    IEnumerator UpdatePersonList()
    {
        Debug.Log("UpdatePersonList Corougine");
        isUpdate = true;
        yield return null;
        int pCnt = pManager.GetComponent<PersonManager>().persons.Count;
        if (pCnt > 0)
        {
            int i = 0;
            if (pCnt < 5)
            {
                for(i=0; i<pCnt; i++)
                {
                    buttons[i].GetComponent<Text>().text = pManager.GetComponent<PersonManager>().rMap[pCnt-i-1] + "\n"
                        + pManager.GetComponent<PersonManager>().dMap[pCnt - i - 1] + "\n(" + pManager.GetComponent<PersonManager>().mNumberList[pCnt - i - 1].GetComponent<Text>().text+")";
                    buttons[i].GetComponentInChildren<Image>().enabled = true;
                }
                for(int j=i; j<5; j++)
                {
                    buttons[j].GetComponentInChildren<Text>().text = null;
                    buttons[j].GetComponentInChildren<Image>().enabled = false;
                }
            }
            else
            {
                for(i=0; i<5; i++)
                {
                    buttons[i].GetComponent<Text>().text = pManager.GetComponent<PersonManager>().rMap[pCnt - i - 1] + "\n"
                         + pManager.GetComponent<PersonManager>().dMap[pCnt - i - 1] + "\n(" + pManager.GetComponent<PersonManager>().mNumberList[pCnt - i - 1].GetComponent<Text>().text + ")";
                    buttons[i].GetComponentInChildren<Image>().enabled = true;
                }
            }
        }

        isUpdate = false;
    }

    public void PivotClick()
    {
        Camera.main.GetComponent<CharacterCamera>().CharacterTransform = transform;
        for (int i = 0; i < 5; i++)
        {
            buttons[i].GetComponent<Animator>().SetBool("ClickBling", false);
        }
    }

    public void P1Click()
    {
        if (pManager.GetComponent<PersonManager>().personTransform.Count > 0)
        {
            Camera.main.GetComponent<CharacterCamera>().CharacterTransform = pManager.GetComponent<PersonManager>().personTransform[pManager.GetComponent<PersonManager>().personTransform.Count-1];

            for (int i = 0; i < 5; i++)
            {
                buttons[i].GetComponent<Animator>().SetBool("ClickBling", false);
            }
            buttons[0].GetComponent<Animator>().SetBool("ClickBling", true);
        }
    }
    public void P2Click()
    {
        if (pManager.GetComponent<PersonManager>().personTransform.Count > 1)
        {
            Camera.main.GetComponent<CharacterCamera>().CharacterTransform = pManager.GetComponent<PersonManager>().personTransform[pManager.GetComponent<PersonManager>().personTransform.Count - 2];

            for (int i = 0; i < 5; i++)
            {
                buttons[i].GetComponent<Animator>().SetBool("ClickBling", false);
            }
            buttons[1].GetComponent<Animator>().SetBool("ClickBling", true);
        }
    }
    public void P3Click()
    {
        if (pManager.GetComponent<PersonManager>().personTransform.Count > 2)
        {
            Camera.main.GetComponent<CharacterCamera>().CharacterTransform = pManager.GetComponent<PersonManager>().personTransform[pManager.GetComponent<PersonManager>().personTransform.Count - 3];

            for (int i = 0; i < 5; i++)
            {
                buttons[i].GetComponent<Animator>().SetBool("ClickBling", false);
            }

            buttons[2].GetComponent<Animator>().SetBool("ClickBling", true);
        }
    }
    public void P4Click()
    {
        if (pManager.GetComponent<PersonManager>().personTransform.Count > 3)
        {
            Camera.main.GetComponent<CharacterCamera>().CharacterTransform = pManager.GetComponent<PersonManager>().personTransform[pManager.GetComponent<PersonManager>().personTransform.Count - 4];

            for (int i = 0; i < 5; i++)
            {
                buttons[i].GetComponent<Animator>().SetBool("ClickBling", false);
            }
            buttons[3].GetComponent<Animator>().SetBool("ClickBling", true);

        }
    }
    public void P5Click()
    {
        if (pManager.GetComponent<PersonManager>().personTransform.Count > 4)
        {
            Camera.main.GetComponent<CharacterCamera>().CharacterTransform = pManager.GetComponent<PersonManager>().personTransform[pManager.GetComponent<PersonManager>().personTransform.Count - 5];

            for (int i = 0; i < 5; i++)
            {
                buttons[i].GetComponent<Animator>().SetBool("ClickBling", false);
            }
            buttons[4].GetComponent<Animator>().SetBool("ClickBling", true);
        }
    }
}
