using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// UI ���� �� ���� ���Ӱ� UI���� ���� Ŭ���� 
public class UIManager : MonoSingleton<UIManager>
{
    // 1. ���α׷��� �����ϸ� (GameStart Button UI)
    // 2. ������ ����ȴٸ� ���� ���ῡ ���� UI
    // 3. ������ �÷��̾� ü��UI

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
