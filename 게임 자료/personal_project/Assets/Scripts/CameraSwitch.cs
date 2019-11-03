using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    static public int current = 0;

    // Start is called before the first frame update
    void Start()
    {
        Camera.main.GetComponent<CharacterCamera>().CharacterTransform = transform;
    }

    public void UpClick()
    {
        Camera.main.GetComponent<CharacterCamera>().CharacterTransform = GameObject.Find("Person").GetComponent<PersonManager>().personTransform[--current];
    }

    public void MiddleClick()
    {
        Camera.main.GetComponent<CharacterCamera>().CharacterTransform = transform;
    }

    public void DownClick()
    {
        Camera.main.GetComponent<CharacterCamera>().CharacterTransform = GameObject.Find("Person").GetComponent<PersonManager>().personTransform[++current];
    }
}
