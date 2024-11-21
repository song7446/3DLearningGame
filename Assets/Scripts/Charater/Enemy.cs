using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Charater
{
    private void Start()
    {
        Init();
    }

    public override void Init()
    {
        State = ECHARACTER_STATE.IDLE;

        Stat.Speed = 1f;
        Stat.Range = 1f;
        Stat.Attack = 1;
        Stat.HP = 1;
    }
    public override void Clear()
    {

    }

    // 고정 프레임 속도로 호출됨 
    // 보통  0.02초 마다 
    // lifecycle
    private void FixedUpdate()
    {
        switch (State)
        {
            case ECHARACTER_STATE.IDLE:
                {
                    Idle();
                }
                break;
            case ECHARACTER_STATE.MOVE:
                {
                    Move();
                }
                break;
            case ECHARACTER_STATE.ATTACK:
                {
                    Attack();
                }
                break;
            case ECHARACTER_STATE.DEAD:
                {
                    Die();
                }
                break;
        }
    }

    public void Update()
    {

    }

    public override void SetState(ECHARACTER_STATE state)
    {
        State = state;
    }

    public override void Idle()
    {
        if (Target == null)
            Search();

        if (Target != null)
            SetState(ECHARACTER_STATE.MOVE);
    }

    protected override void Search()
    {
        Charater target = null;
        switch (Charater_Type)
        {
            case ECHARATER_TYPE.NONE:
                break;
            case ECHARATER_TYPE.PLAYER:
                target = GameManager.Instance.GetClosestEnemy(float.MaxValue);
                break;
            case ECHARATER_TYPE.ENEMY:
                target = GameManager.Instance.GetPlayer();
                break;
        }

        Target = target;

        if (Target != null)
            Debug.Log(Target.gameObject.name);
    }


    public override void Move()
    {
        Vector3 dirVec = Target.transform.position - transform.position;

        // magnitude 벡터의 길이값 
        float dist = dirVec.magnitude;

        if (dist > 1f) // 공격 거리 
        {
            MovePos(dirVec.normalized);
        }
        else
        {
            SetState(ECHARACTER_STATE.ATTACK);
        }

        // normalized 방향만 알게 해주는 함수 
        MovePos(dirVec.normalized);
    }
    protected override void MovePos(Vector3 dir)
    {
        transform.position += dir * Stat.Speed * Time.deltaTime;
    }

    public override void Attack()
    {
        Debug.Log("ATTACK " + gameObject.name);
        Target.SetDamage(Stat.Attack); // 공력력        
    }

    public override void SetDamage(int damageValue)
    {
        Debug.Log("SetDamage " + gameObject.name);
        bool isDead = Stat.SetDamage(damageValue); // 체력값

        if (isDead)
        {
            Die();
        }

    }

    public override void Die()
    {
        Debug.Log("Die " + gameObject.name);
        gameObject.SetActive(false);
    }
}
