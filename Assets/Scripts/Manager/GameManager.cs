using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 전투에 대해 관리해주는 클래스
public class GameManager : MonoSingleton<GameManager>
{
    private int Stage = 0; // 현재 스테이지 번호 

    public Charater Player = null;
    public List<Charater> Enemy = null;

    [ContextMenu("TEST")]
    public void Test()
    {
        StageManager.Instance.CreateStage();
    }

    // 시작, 초기화를 해주는 부분
    private void Init()
    {

    }

    public void Clear()
    {

    }

    public void StageSetting()
    {

    }

    public void FixedUpdate()
    {

    }

    public void StageStart()
    {

    }

    public void StageEnd()
    {

    }

    public GameObject GetEnemy()
    {
        return null;
    }

    /// <summary>
    /// 가장 가까이 있는 적군 얻기 위한 함수 
    /// </summary>
    /// <param name="dist">탐지 범위 값</param>
    /// <returns></returns>
    public Charater GetClosestEnemy(float dist) // dist 여러 상황에 검사하는 거리 조건 기준값
    {
        Charater closestEnemy = null;
        float tempDist = 0f;
        var playerPosition = Player.transform.position;
        Enemy.ForEach(enemy =>
        {
            tempDist = Vector3.Distance(playerPosition, enemy.transform.position);
            if(dist > tempDist)
            {
                dist = tempDist;
                closestEnemy = enemy;
            }
        });

        return closestEnemy;
    }

    public Charater GetPlayer()
    {
        return Player;
    }

    public void EnemyDie()
    {

    }
}
