using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ������ ���� �������ִ� Ŭ����
public class GameManager : MonoSingleton<GameManager>
{
    private int Stage = 0; // ���� �������� ��ȣ 

    public Charater Player = null;
    public List<Charater> Enemy = null;

    [ContextMenu("TEST")]
    public void Test()
    {
        StageManager.Instance.CreateStage();
    }

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

    /// <summary>
    /// ���� ������ �ִ� ���� ��� ���� �Լ� 
    /// </summary>
    /// <param name="dist">Ž�� ���� ��</param>
    /// <returns></returns>
    public Charater GetClosestEnemy(float dist) // dist ���� ��Ȳ�� �˻��ϴ� �Ÿ� ���� ���ذ�
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
