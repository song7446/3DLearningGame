using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    // 모노 싱글턴
    private static T instance = null;

    public static T Instance
    {
        get 
        {
            if (instance == null)
            {
                instance = FindObjectOfType<T>();
                if (instance == null)
                {
                    GameObject tGameObject = new GameObject(typeof(T).Name);
                    instance = tGameObject.AddComponent<T>();
                }

                // 씬을 이동해도 삭제되지 않음 
                DontDestroyOnLoad(Instance.gameObject);
            }
            return instance; 
        }
    }

}
