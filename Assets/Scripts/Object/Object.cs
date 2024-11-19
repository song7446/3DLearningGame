using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EOBJECT_TYPE
{
    NONE,
    DOOR,
    BOX,
    ITEM,
}

public class Object : MonoBehaviour
{
    public ECHARACTER_STATE Object_Type = ECHARACTER_STATE.NONE;

    public void InterAction() 
    {
        Action();
    }

    // InterAction이라는 부모 함수가 있기 때문에 protected 사용
    protected void Action()
    {

    }

    public void TimeOut()
    {

    }
}
