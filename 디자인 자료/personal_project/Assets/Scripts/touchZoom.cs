using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touchZoom : MonoBehaviour
{
    Vector3 touchStart;
    public Camera cam;
    public float groundZ = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            touchStart = GetWorldPosition(groundZ);
        }
 
        if (Input.GetMouseButtonUp(0))
        {
            Vector3 direction = touchStart - GetWorldPosition(groundZ);
            Camera.main.transform.position += direction;
        }
    }
    
    private Vector3 GetWorldPosition(float z)
    {
        Ray mouserPos = cam.ScreenPointToRay(Input.mousePosition);
        Plane ground = new Plane(Vector3.forward, new Vector3(0, 0, z));
        float distance;
        ground.Raycast(mouserPos, out distance);
        return mouserPos.GetPoint(distance);
    }
}
