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
}
