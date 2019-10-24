using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowNumber : MonoBehaviour
{
    [SerializeField]
    GameObject numberPrefab = null;

    public List<Transform> mObjectList = new List<Transform>();
    List<GameObject> mNumberList = new List<GameObject>();

    Camera mCamera = null;

    // Start is called before the first frame update
    void Start()
    {
        mCamera = Camera.main;

        GameObject[] objects = GameObject.FindGameObjectsWithTag("Object");
        for(int i=0; i<objects.Length; i++)
        {
            mObjectList.Add(objects[i].transform);
            GameObject mNumber = Instantiate(numberPrefab, objects[i].transform.position, Quaternion.identity, transform);
            mNumberList.Add(mNumber);
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i=0; i<mObjectList.Count; i++)
        {
            mNumberList[i].transform.position = mCamera.WorldToScreenPoint(mObjectList[i].position + new Vector3(0, 1f, 0));
        }
    }
}
