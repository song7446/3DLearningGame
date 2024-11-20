using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoPoolItem : MonoBehaviour 
{
    // T 타입의 인스턴스를 알고 있어야한다
    // monoobjectpool의 set함수를 호출해야한다

    public UnityEngine.Events.UnityAction<MonoPoolItem> SetAction = null;
    public Component Instance = null;

    public void Init<T>(UnityEngine.Events.UnityAction<MonoPoolItem> setAction, T instance) where T : Component 
    {
        SetAction = setAction;
        Instance = instance;
    }

    private void OnDisable()
    {
        SetAction?.Invoke(this);
    }
}
