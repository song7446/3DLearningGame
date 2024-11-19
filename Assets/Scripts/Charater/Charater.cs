using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ECHARACTER_STATE
{
    NONE,
    IDLE,
    MOVE,
    ATTACK,
    DEAD
}

public class Charater : MonoBehaviour
{
    [System.Serializable]
    public class StatClass
    {
        public int HP = 0;
        public int MP = 0;
        public int Attack = 0;
        public int Defense = 0;
    }

    public ECHARACTER_STATE State = ECHARACTER_STATE.NONE;
    public StatClass Stat = null;

    public void Update()
    {
        
    }

    public void Idle()
    {

    }
    public void Move()
    {

    }
    public void Attack()
    {

    }
    public void Die()
    {

    }
}
