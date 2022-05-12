using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCore : MonoBehaviour
{
    public static GameCore Instance;
    [Header("玩家位置")]
    public Transform player;
    
    [Header("怪物殭屍Prefab")]
    public GameObject[] monsters;
    [Header("生成怪物的座標")]
    public Transform[] monstersPoint;
    [Header("生成怪物間隔")]
    public float nextZombieTime = 5;

    private void Start()
    {
        Instance = this;
        InitMonster();
    }
    public void InitMonster()
    {
        int randomMonster = Random.Range(0, monsters.Length);
        int randomPoint = Random.Range(0, monstersPoint.Length);
        GameObject newZombie = Instantiate(monsters[randomMonster], monstersPoint[randomPoint].position, monstersPoint[randomPoint].rotation);
        Invoke(nameof(InitMonster), nextZombieTime);
    }
}
