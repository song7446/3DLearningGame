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
}
