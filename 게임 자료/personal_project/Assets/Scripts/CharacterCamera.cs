using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCamera : MonoBehaviour
{
    [HideInInspector]
    public Transform CharacterTransform = null;

    [Range(0.01f, 1.0f)]
    public float SmoothSpeed = 0.125f;

    private Vector3 cameraOffset; // 화면 Set!
    private Vector3 pivot;

    // Start is called before the first frame update
    void Start()
    {
        cameraOffset = new Vector3(0, 5.0f, -6.0f);
        pivot = GameObject.FindGameObjectWithTag("Pivot").transform.position;
    }

    // LateUpdate is called after Update methods
    void LateUpdate()
    {
        
        Vector3 newPos = CharacterTransform.position + cameraOffset;

        if (CharacterTransform.position != pivot)
        {

            transform.position = Vector3.Slerp(transform.position, newPos, SmoothSpeed);

            transform.LookAt(CharacterTransform);
        }
        else
        {
            transform.position = Vector3.Slerp(transform.position, newPos, SmoothSpeed);
        }
    }
}
