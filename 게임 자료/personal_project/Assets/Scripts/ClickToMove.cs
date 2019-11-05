using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ClickToMove : MonoBehaviour
{
    private Animator mAnimator;

    private NavMeshAgent mNavMeshAgent;

    public bool mRunning = true;

    public GameObject destination;
    // Start is called before the first frame update
    void Start()
    {
        mAnimator = GetComponent<Animator>();
        mNavMeshAgent = GetComponent<NavMeshAgent>();
        destination = GameObject.Find("Person").GetComponent<PersonManager>().destMap;
        mNavMeshAgent.SetDestination(destination.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
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
