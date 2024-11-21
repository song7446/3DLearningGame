using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ECHARATER_TYPE
{
    NONE,
    PLAYER,
    ENEMY,
}

public enum ECHARACTER_STATE
{
    NONE,
    IDLE,
    MOVE,
    ATTACK,
    DEAD
}

[System.Serializable]
public class StatClass
{
    public int HP = 0;
    public int MP = 0;
    public int Attack = 0;
    public int Defense = 0;
    public float Range = 0;
    public float Speed = 0;

    /// <summary>
    /// 데미지를 받았을 때 처리하는 함수
    /// 반환값이 true면 사망 false 면 살아있다 
    /// </summary>

    public bool SetDamage(int damageVlaue)
    {
        HP -= damageVlaue;

        return HP <= 0;
    }
}

public class Charater : MonoBehaviour
{
    public ECHARATER_TYPE Charater_Type = ECHARATER_TYPE.NONE;
    public ECHARACTER_STATE State = ECHARACTER_STATE.NONE;
    public StatClass Stat = null;

    public Charater Target = null;

    [ContextMenu("TestTest")]
    public void Test()
    {

    }


    public virtual void Init()
    {

    }
    public virtual void Clear()
    {

    }

    public virtual void SetState(ECHARACTER_STATE state)
    {
    }

    public virtual void Idle()
    {

    }

    protected virtual void Search()
    {

    }


    public virtual void Move()
    {

    }
    protected virtual void MovePos(Vector3 dir)
    {

    }

    public virtual void Attack()
    {
        
    }

    public virtual void SetDamage(int damageValue)
    {

    }

    public virtual void Die()
    {
    }
}
