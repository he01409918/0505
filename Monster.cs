using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monster : MonoBehaviour
{

    private Animator anim;
    private NavMeshAgent nav;
    private Rigidbody rb;
    private Renderer rend;

    public float hp = 100f;

    public GameObject getHitEffect;

    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        rend = GetComponentInChildren<Renderer>();
        anim.enabled = false;
        Invoke(nameof(OnEnableAnimator), Random.Range(0f, 0.5f));
    }

    void Update()
    {
        Movement();
        if (Input.GetKeyDown(KeyCode.C))
        {
            OnGetHit(100);
        }
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
            StartCoroutine(DoSkinFlash());
            hp -= value;
            if (hp <= 0)
            {
                Die();
            }
        }
    }

    private void Die()
    {
        GameCore.Instance.OnUpdateKillText(1);
        Instantiate(getHitEffect, transform.position + Vector3.up *1, transform.rotation);
        
        /*anim.enabled = false;
        rb.isKinematic = false;
        Vector3 randomV3 = new Vector3(Random.Range(-5f, 5f), Random.Range(3f, 5f), Random.Range(-5f, 5f));
        rb.AddForce(randomV3 , ForceMode.Impulse);
        rb.AddTorque(randomV3  , ForceMode.Impulse);
        nav.speed = 0;
        nav.enabled = false;
        */
        Destroy(gameObject);
    }

    IEnumerator DoSkinFlash()
    {
        rend.material.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        rend.material.color = Color.white; 
    }

}
