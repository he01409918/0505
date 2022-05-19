using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monster : MonoBehaviour
{
    private Animator anim;
    private NavMeshAgent nav;

    public float hp = 100f;

    private Rigidbody rb;

    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        anim.enabled = false;
        hp = 100;
        Invoke(nameof(OnEnableAnimator), Random.Range(0f, 0.5f));
    }

    void Update()
    {
        Movement();
    }
    private void Movement()
    {
        if (nav != null &&hp>0)
        {
            nav.SetDestination(GameCore.Instance.player.position);
        }
    }
    private void OnEnableAnimator()
    {
        anim.enabled = true;
    }
    public void OnGetHit(float value)
    {
        if (hp > 0)
        {
            hp -= value;
            if (hp <= 0)
            {
                Die();
            }
        }
    }

    private void Die()
    {
        anim.enabled = false;
        rb.isKinematic = false;
        Vector3 randomV3 = new Vector3(Random.Range(-5f, 5f), Random.Range(3f, 5f), Random.Range(-5f, 5f));
        rb.AddForce(randomV3 , ForceMode.Impulse);
        rb.AddTorque(randomV3  , ForceMode.Impulse);
        nav.speed = 0;
        nav.enabled = false;
        Destroy(gameObject, 5);
    }

}
