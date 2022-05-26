using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float damage = 100;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Monster"))
        {
            Monster monster = other.GetComponent<Monster>();
            float value = Random.Range(damage * 0.9f, damage * 1.1f);
            monster.OnGetHit(value);
        }
    }
}
