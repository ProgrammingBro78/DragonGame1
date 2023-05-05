using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class pathfinding : MonoBehaviour
 
{
    public Transform goal;
    public Animator animator;
    NavMeshAgent agent;

    public bool run_towards = false;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {
      
        
    }
}
