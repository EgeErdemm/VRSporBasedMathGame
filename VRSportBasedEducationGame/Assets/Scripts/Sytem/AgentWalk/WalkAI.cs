using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WalkAI : MonoBehaviour
{
    [SerializeField] CubeEater cubeDetection;
    [SerializeField] Transform home;
    public Transform target=null; // Gideceði hedef
    private NavMeshAgent agent;
    [SerializeField] Transform carringTranform;
    private bool arrivedCube;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    public void GoGetCube()
    {
        if (target == null)
        {
            arrivedCube = false;
            target = cubeDetection.transformOfCube;
            agent.SetDestination(target.position);
        }
    }

    public void GoDropCube() 
    {
        if (target == null)
        {
            arrivedCube = true;
            target = home;
            agent.SetDestination(target.position);
        }
    }


    void Update()
    {
        if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
        {
            arrivedCube = false;
            GoDropCube();
            target = null;
        }

        if(arrivedCube && cubeDetection.transformOfCube !=null)
        {
            cubeDetection.transformOfCube.position = carringTranform.position;
            Debug.Log("cube holding");
        }
    }

}
