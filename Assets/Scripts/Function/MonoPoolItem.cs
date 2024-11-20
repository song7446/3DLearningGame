using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoPoolItem : MonoBehaviour 
{
    // T Ÿ���� �ν��Ͻ��� �˰� �־���Ѵ�
    // monoobjectpool�� set�Լ��� ȣ���ؾ��Ѵ�

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
