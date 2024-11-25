using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputControl : MonoBehaviour
{
    // MonoSingleton으로 하지 않는 이유는 dondestroy가 되기 때문에 씬에 상관없이 존재하기 때문(게임을 플레이 할 때만 있으면 됨)
    public static InputControl Instance
    {
        get {  return instance; }
    }

    public static InputControl instance = null;


    public Vector2 MouseInput = Vector2.zero;
    public Vector2 MoveInput = Vector2.zero;

    public bool Attack = false;

    public bool Pause = false;

    private void Awake()
    {
        if (instance != null) 
        {
            if (instance != this) 
            {
                Debug.LogError("Input Control is not Only : " + instance.gameObject.name);
            }           
        }
        instance = this;
    }

    void Update()
    {
        // 키보드나 마우스가 아닌 다른 입력도 받을 수 있다 GetAxis
        MoveInput.Set(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")); // -1 ~ 1
        MouseInput.Set(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        Pause = Input.GetButtonDown("Pause");

        if(Input.GetButtonDown("Fire1"))
        {
            Attack = true;
        }
    }
}
