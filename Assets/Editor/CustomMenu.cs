using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

public class CustomMenu : MonoBehaviour
{
    // 유니티 커스텀 메뉴 %=컨트롤
    [MenuItem("Custom/HotKey/SetActive %q")]
    public static void SetActive()
    {
        GameObject[] gameObjects = Selection.gameObjects;

        for (int i = 0; i < gameObjects.Length; i++) 
        {
            gameObjects[i].SetActive(!gameObjects[i].activeSelf);
            EditorUtility.SetDirty(gameObjects[i]);
        }
    }

    // 트랜스폼 복사 
    [MenuItem("Custom/HotKey/CopyTransform %w")]
    public static void CopyTransform()
    {
        GameObject[] gameObjects = Selection.gameObjects;

        if (gameObjects.Length <= 0) 
            return;

        ComponentUtility.CopyComponent(gameObjects[0].transform);
    }

    // 트랜스폼 붙여넣기 #=쉬프트
    [MenuItem("Custom/HotKey/PasteTransform %#w")]
    public static void PasteTransform()
    {
        GameObject[] gameObjects = Selection.gameObjects;

        for (int i = 0; i < gameObjects.Length; i++) 
        {
            ComponentUtility.PasteComponentValues(gameObjects[i].transform);
        }

        ComponentUtility.CopyComponent(gameObjects[0].transform);
    }
}
