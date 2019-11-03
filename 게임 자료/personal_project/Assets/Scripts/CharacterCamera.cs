using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCamera : MonoBehaviour
{

    public Transform CharacterTransform;

    [Range(0.01f, 1.0f)]
    public float SmoothSpeed = 0.125f;

    private Vector3 cameraOffset; // 화면 Set!

    // Start is called before the first frame update
    void Start()
    {
        cameraOffset = new Vector3(0, 5.0f, -6.0f);
    }

    // LateUpdate is called after Update methods
    void LateUpdate()
    {
        
        Vector3 newPos = CharacterTransform.position + cameraOffset;

        transform.position = Vector3.Slerp(transform.position, newPos, SmoothSpeed);

        transform.LookAt(CharacterTransform);
    }
}
