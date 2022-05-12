using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monster : MonoBehaviour
{
    private Animator anim;
    private NavMeshAgent nav;
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        anim.enabled = false;
        Invoke(nameof(OnEnableAnimator), Random.Range(0f, 0.5f));
    }

    void Update()
    {
        Movement();
    }
    private void Movement()
    {
        nav.SetDestination(GameCore.Instance.player.position);
    }
    private void OnEnableAnimator()
    {
        anim.enabled = true;
    }
}
