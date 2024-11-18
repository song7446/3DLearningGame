using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    // ������ ���� �������ִ� Ŭ����

    private int Stage = 0; // ���� �������� ��ȣ 

    private GameObject Player = null;
    private List<GameObject> Enemy = null;

    // ����, �ʱ�ȭ�� ���ִ� �κ�
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

    // ���� ������ �ִ� ���� ��� ���� �Լ� 
    public GameObject GetClosestEnemy(float dist) // dist ���� ��Ȳ�� �˻��ϴ� �Ÿ� ���� ���ذ�
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
