using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// 게임의 흐름을 제어하는 매니저 
public enum EGAME_STATE
{
    NONE,
    START,
    GAME,
    END
}

public class SystemManager : MonoSingleton<SystemManager>
{
    // 외부에서 바꿀 수 있도록 시리얼라이즈 필드 설정 
    [SerializeField]
    private EGAME_STATE GameState = EGAME_STATE.NONE;

    // 시작, 초기화를 해주는 부분
    private void Init()
    {

    }

    public void SetState(EGAME_STATE state)
    {
        GameState = state;
        ProcessState();
    }

    public EGAME_STATE GetState()
    {
        return GameState;
    }

    // 씬 이동
    private void ProcessState()
    {
        switch (GameState)
        {
            case EGAME_STATE.START:
                {
                    SceneManager.LoadScene("Start");
                }
                break;
            case EGAME_STATE.GAME:
                {
                    SceneManager.LoadScene("Game");
                }
                break;
            case EGAME_STATE.END:
                {
                    SceneManager.LoadScene("End");
                }
                break;
        }
    }
}
