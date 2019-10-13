using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minimap : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform map;

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 newPosition = map.position;
        newPosition.z = map.position.z;
        newPosition.y = transform.position.y;
        transform.position = newPosition;

        //transform.rotation = Quaternion.Euler(90f, map.eulerAngles.y, 0f);
    }
}
