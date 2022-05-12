using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCore : MonoBehaviour
{
    public static GameCore Instance;
    [Header("玩家位置")]
    public Transform player;
    /*
    [Header("怪物殭屍Prefab")]
    public GameObject[] monsters;
    [Header("生成怪物的座標")]
    public Transform[] zombiePoint;
    [Header("生成怪物間隔")]
    public float nextZombieTime = 5;*/

    private void Start()
    {
        Instance = this;
        InitZombie();
    }
    public void InitZombie()
    {
        /*int randomMonster = Random.Range(0, monsters.Length);
        int randomPoint = Random.Range(0, zombiePoint.Length);
        GameObject newZombie = Instantiate(monsters[randomMonster], zombiePoint[randomPoint].position, zombiePoint[randomPoint].rotation);
        Invoke(nameof(InitZombie), nextZombieTime);*/
    }
}
