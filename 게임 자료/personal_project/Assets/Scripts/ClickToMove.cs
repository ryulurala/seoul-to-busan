using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ClickToMove : MonoBehaviour
{
    private Animator mAnimator;

    private NavMeshAgent mNavMeshAgent;

    public Camera minimapCamera;
    
    private bool mRunning = false;

    // Start is called before the first frame update
    void Start()
    {
        mAnimator = GetComponent<Animator>();
        mNavMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = minimapCamera.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        if(Input.GetMouseButtonDown(0))
        {
            if(Physics.Raycast(ray, out hit, 100))
            {
                mNavMeshAgent.destination = hit.point;
                Debug.Log("Hit!");
            }
        }

        if(mNavMeshAgent.remainingDistance <= mNavMeshAgent.stoppingDistance)
        {
            mRunning = false;
        }
        else
        {
            mRunning = true;
        }

        mAnimator.SetBool("running", mRunning);
    }
}
