using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputControl : MonoBehaviour
{
    // MonoSingleton���� ���� �ʴ� ������ dondestroy�� �Ǳ� ������ ���� ������� �����ϱ� ����(������ �÷��� �� ���� ������ ��)
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
        // Ű���峪 ���콺�� �ƴ� �ٸ� �Էµ� ���� �� �ִ� GetAxis
        MoveInput.Set(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")); // -1 ~ 1
        MouseInput.Set(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        Pause = Input.GetButtonDown("Pause");

        if(Input.GetButtonDown("Fire1"))
        {
            Attack = true;
        }
    }
}
