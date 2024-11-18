using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// ������ �帧�� �����ϴ� �Ŵ��� 
public enum EGAME_STATE
{
    NONE,
    START,
    GAME,
    END
}

public class SystemManager : MonoSingleton<SystemManager>
{
    // �ܺο��� �ٲ� �� �ֵ��� �ø�������� �ʵ� ���� 
    [SerializeField]
    private EGAME_STATE GameState = EGAME_STATE.NONE;

    // ����, �ʱ�ȭ�� ���ִ� �κ�
    private void Init()
    {

    }

    private void Clear()
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

    // �� �̵�
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
                    StartCoroutine(LoadSceneAsyncCor("Game"));
                }
                break;
            case EGAME_STATE.END:
                {
                    SceneManager.LoadScene("End");
                }
                break;
        }
    }

    // �񵿱� �� �ε� �ڷ�ƾ
    IEnumerator LoadSceneAsyncCor(string sceneName)
    {
        AsyncOperation handle = SceneManager.LoadSceneAsync(sceneName);

        handle.allowSceneActivation = false;

        while (handle.progress < 0.9) 
        {
            Debug.Log(handle.progress);
            yield return null;
        }

        // �ε���
        float progress = handle.progress + 0.1f;
        Debug.Log(handle.progress);

        handle.allowSceneActivation = true;
    }
}
