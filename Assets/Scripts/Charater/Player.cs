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

    // ������ ����� ������ ���̱� ������ fixedupdate
    private void FixedUpdate()
    {
        
    }

    // ������Ʈ ���� ����Ʈ ������Ʈ ������ ȣ�� 
    // �� ĳ���͵��� �ִϸ����͵�� ���������� �����Ұ��̱� ������ ���? 
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
