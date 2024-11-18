using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    // 전투에 대해 관리해주는 클래스

    private int Stage = 0; // 현재 스테이지 번호 

    private GameObject Player = null;
    private List<GameObject> Enemy = null;

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

    // 가장 가까이 있는 적군 얻기 위한 함수 
    public GameObject GetClosestEnemy(float dist) // dist 여러 상황에 검사하는 거리 조건 기준값
    {
        GameObject closestEnemy = null;
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

    public GameObject GetPlayer()
    {
        return null;
    }

    public void EnemyDie()
    {

    }
}
