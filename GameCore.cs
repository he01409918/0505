using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameCore : MonoBehaviour
{
    public static GameCore Instance;
    [Header("玩家位置")]
    public Transform player;
    
    [Header("怪物Prefabs")]
    public GameObject[] monsters;
    [Header("生成怪物的座標")]
    public Transform[] monstersPoint;
    [Header("生成怪物間隔")]
    public float nextZombieTime = 5;
    [Header("顯示擊殺數的文本")]
    public Text killText;

    [Header("文字傷害Prefab")]
    public GameObject damageTextPrefab;

    private int currentKillCount;

    private void Start()
    {
        Instance = this;
        InitMonster();
        OnUpdateKillText(0);
    }
    public void InitMonster()
    {
        int randomMonster = Random.Range(0, monsters.Length);
        int randomPoint = Random.Range(0, monstersPoint.Length);
        GameObject newZombie = Instantiate(monsters[randomMonster], monstersPoint[randomPoint].position, monstersPoint[randomPoint].rotation);
        Invoke(nameof(InitMonster), nextZombieTime);
    }

    public void OnUpdateKillText(int value)
    {
        currentKillCount += value;
        killText.text = $"擊殺數 : {currentKillCount}";
    }
    public void InitDamageText(Vector3 position , float value)
    {
        GameObject _damageTextPrefab = Instantiate(damageTextPrefab, position, Quaternion.identity);
        _damageTextPrefab.transform.LookAt(Camera.main.transform);
        _damageTextPrefab.GetComponentInChildren<Text>().text = value.ToString();
    }
}
