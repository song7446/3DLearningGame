using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Charater
{    
    public InputControl InputControl = null;
    public Animator Animator = null;

    public Weapon Weapon = null;

    public override void Init()
    {
        Charater_Type = ECHARATER_TYPE.PLAYER;
        State = ECHARACTER_STATE.IDLE;
    }

    // 물리적 연산과 적용할 것이기 때문에 fixedupdate
    private void FixedUpdate()
    {
        
    }

    // 업데이트 이후 레이트 업데이트 이전에 호출 
    // 각 캐릭터들의 애니메이터들과 유기적으로 연동할것이기 때문에 사용? 
    private void OnAnimatorMove()
    {
        
    }

    public override void Attack()
    {

    }

    public override void Move()
    {

    }

    public void Dead()
    {

    }
}
