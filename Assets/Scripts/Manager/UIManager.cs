using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// UI 관리 및 실제 게임과 UI간의 연동 클래스 
public class UIManager : MonoSingleton<UIManager>
{
    // 1. 프로그램을 시작하면 (GameStart Button UI)
    // 2. 전투가 종료된다면 전투 종료에 대한 UI
    // 3. 전투중 플레이어 체력UI

    public Button GameStartButton = null;

    public Button BattleEndButton = null;

    public Slider PlayerHP_Bar = null;

    public void onClickGameStartButton()
    {
        SystemManager.Instance.SetState(EGAME_STATE.GAME);
    }

    public void onClickGameEndButton() 
    {
        SystemManager.Instance.SetState(EGAME_STATE.END);
    }

    public void SetPlayerHPBar(float curhp)
    {
        PlayerHP_Bar.value = curhp;
    }
}
