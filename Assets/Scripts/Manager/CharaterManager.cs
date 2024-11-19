using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 생성, 삭제등 캐릭터에 대한 전반적인 클래스 
public class CharaterManager : MonoSingleton<CharaterManager>
{
    public GameObject Player = null;

    // 전체 적군에 대한 컨테이너
    public List<GameObject> Enemy = null;

    public void Init()
    {

    }

    public void Clear()
    {

    }

    public GameObject GetEnemy()
    {
        if (Enemy.Count <= 0)
        {
            CreateEnemy();
        }
        return null;
    }

    public GameObject GetPlayer()
    {
        if(Player == null)
        {
            CreatePlayer();
        }
        return null;
    }

    public void SetyEnemy(GameObject enemy)
    {
        Enemy.Add(enemy);
    }

    public void SetPlayer(GameObject player)
    {
        Player = player;
    }

    private void CreateEnemy()
    {
        for (int i = 0; i < 4; i++) 
        {
            Enemy.Add(new GameObject());
        }        
    }

    private void CreatePlayer()
    {
        Player = new GameObject();
    }
}

