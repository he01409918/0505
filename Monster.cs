using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monster : MonoBehaviour
{
    private NavMeshAgent nav;
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        Movement();
    }
    private void Movement()
    {
        nav.SetDestination(GameCore.Instance.player.position);
    }
}
