using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrolOnly : MonoBehaviour
{
    Transform target;
    NavMeshAgent agent;
    int currentNode;
    int previousNode;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        currentNode = Random.Range(2, GameManager.gm.nodes.Length);
        previousNode = currentNode;
    }

    // Update is called once per frame
    void Update()
    {
        Patrol();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "node")
        {
            currentNode = Random.Range(2, GameManager.gm.nodes.Length);
            while(currentNode == previousNode)
            {
                currentNode = Random.Range(2, GameManager.gm.nodes.Length);
            }
            previousNode = currentNode;
        }
    }

    void Patrol()
    {

        agent.destination = GameManager.gm.nodes[currentNode].position;
    }
}
