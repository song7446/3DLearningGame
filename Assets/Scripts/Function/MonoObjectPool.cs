using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoObjectPool<T> where T : Component
{
    private Stack<MonoPoolItem> instanceStack = new Stack<MonoPoolItem>();

    private T OriginAsset = null;
    private GameObject Parent = null;

    public void Init(T origin)
    {
        Parent = new GameObject(string.Format("{0}_pool", origin.gameObject.name));
        OriginAsset = origin;
        Create();
    }

    public T Get()
    {
        if(instanceStack.Count == 0)
        {
            Create();
        }

        return instanceStack.Pop().Instance as T;
    }

    public void Set(MonoPoolItem instance)
    {
        instanceStack.Push(instance);
    }

    public void Create()
    {
        MonoPoolItem tmpPoolItem = null;
        T tmpInstance = null;
        for (int i = 0; i < 5; i++) 
        {
            tmpInstance = GameObject.Instantiate<T>(OriginAsset, Parent.transform);
            tmpInstance.gameObject.SetActive(false);

            tmpPoolItem = tmpInstance.gameObject.AddComponent<MonoPoolItem>();
            tmpPoolItem.Init(Set, tmpInstance);

            instanceStack.Push(tmpPoolItem);
        }
    }
}
