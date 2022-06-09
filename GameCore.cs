using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    [Header("閃爍動畫")]
    public Animator cameraAnimator;

    [Header("失敗動畫")]
    public Animator gameoverAnimator;

    [Header("玩家血量")]
    public float hp;

    [Header("勝利擊殺數")]
    public int winKillCount = 5;

    private bool isFinish = false;

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
        if (currentKillCount >= winKillCount && !isFinish)
        {
            Debug.LogError("Win");
            isFinish = true;
        }
        killText.text = $"擊殺數 : {currentKillCount}";
    }
    public void InitDamageText(Vector3 position , float value)
    {
        GameObject _damageTextPrefab = Instantiate(damageTextPrefab, position, Quaternion.identity);
        _damageTextPrefab.transform.LookAt(Camera.main.transform);
        _damageTextPrefab.GetComponentInChildren<Text>().text = value.ToString("0");
    }

    public void OnCameraFlash()
    {
        cameraAnimator.Play("Flash");
    }

    public void PlayerGetHit(float value)
    {
        if (hp > 0)
        {
            hp -= value;
            if (hp <=0)
            {
                gameoverAnimator.Play("GameOver");
                Invoke(nameof(LoadScene), 5);
            }
        }
    }

    private void LoadScene()
    {
        SceneManager.LoadScene(0);
    }

    private void RelaseAllMonster()
    {
        CancelInvoke(nameof(InitMonster));
        Monster[] monster = FindObjectsOfType<Monster>();
        for (int i = 0; i < monster.Length; i++)
        {
            monster[i].OnGetHit(999);
        }
    }
}
