using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByTime : MonoBehaviour
{
    [Header("銷毀時間")]
    public float timer;
    void Start()
    {
        Destroy(gameObject, timer);
    }
}