using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    // ��� �̱���
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

                // ���� �̵��ص� �������� ���� 
                DontDestroyOnLoad(Instance.gameObject);
            }
            return instance; 
        }
    }

}
