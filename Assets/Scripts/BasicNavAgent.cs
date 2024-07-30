using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BasicNavAgent : MonoBehaviour
{
    NavMeshAgent agent;
    GameObject[] CoverPoints;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        CoverPoints = GameObject.FindGameObjectsWithTag("CoverPoint");
        agent.destination = CoverPoints[Random.Range(0, CoverPoints.Length)].transform.position;
        //agent.destination = GameObject.FindGameObjectWithTag("Player").transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //agent.destination = GameObject.FindGameObjectWithTag("Player").transform.position;
    }
}
