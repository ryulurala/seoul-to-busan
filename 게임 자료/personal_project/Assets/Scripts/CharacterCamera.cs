using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCamera : MonoBehaviour
{

    public Transform CharacterTransform;

    private Vector3 cameraOffset;

    [Range(0.01f, 1.0f)]
    public float SmoothFactor = 0.5f;

    public bool LookAtPlayer = false;
    // Start is called before the first frame update
    void Start()
    {
        cameraOffset = transform.position - CharacterTransform.position;
    }

    // LateUpdate is called after Update methods
    void LateUpdate()
    {
        Vector3 newPos = CharacterTransform.position + cameraOffset;

        transform.position = Vector3.Slerp(transform.position, newPos, SmoothFactor);

        if (LookAtPlayer)
        {
            transform.LookAt(CharacterTransform);
        }
    }
}
