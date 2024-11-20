using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

// stage ����, ���� 
public class StageManager : MonoSingleton<StageManager>
{
    public List<Stage> Stage = null;

    public MonoObjectPool<Transform> TilePool = null;
    public MonoObjectPool<Transform> WallPool = null;

    public GameObject TileOrigin = null;
    public GameObject WallOrigin = null;

    public void Init()
    {

    }

    public void Claer()
    {

    }

    public GameObject GetStage()
    {
        if (Stage.Count <= 0)
        {
            CreateStage();
        }

        return null;
    }

    public void SetStage(Stage stage)
    {
        Stage.Add(stage);
    }

    public void CreateStage()
    {
        TilePool = new MonoObjectPool<Transform>();
        TilePool.Init(TileOrigin.transform);

        WallPool = new MonoObjectPool<Transform>();
        WallPool.Init(WallOrigin.transform);

        // 1.Resources
        // Resources.Load("");
        // ������Ʈ �����ҽ� ����� ���Ͽ� resources�ȿ� �ִ� ������ ���� ����
        // ���� �۽���� �ٽ� ���� ������Ʈ 
        // ���� ������ �ö���.
        Stage stageOrigin = Resources.Load<Stage>("Prefabs/Stage/Stage");

        // 2.�ܺ����� ex)Prefabs
        // UnityEditor.AssetDatabase.LoadAssetAtPath<Stage>("");
        // ���忡 ���Ե��� �ʴ´�
        // ���� �ۿ� ���µ� 
        // ��ġ���� �ٿ�ε� 
        // ���¹��� ��ġ����
        // �ֱ� addressable
        // Stage stageOrigin =  UnityEditor.AssetDatabase.LoadAssetAtPath<Stage>("Assets/Prefabs/Stage/Stage.prefab");

        Stage = new List<Stage>();

        Vector3 stagePos = Vector3.zero;
        for (int i = 0; i < 3; i++)
        {
            Stage instance = Instantiate<Stage>(stageOrigin);
            instance.transform.position = stagePos;

            int randomWidth = Random.Range(10, 31);
            int randomHeight = Random.Range(10, 31);

            instance.Create(randomWidth, randomHeight);

            stagePos.z += randomHeight + 1;

            Stage.Add(instance);
        }
    }
}
