using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ESKILL_TYPE
{
    NONE,
    PROJECTILE,
    BOMB,
}

public class Skill : MonoBehaviour
{
    public ESKILL_TYPE Skill_Type = ESKILL_TYPE.NONE;

    public void Call()
    {
        Action();
    }

    protected void Action()
    {

    }

    protected void TimeOut()
    {

    }
}
