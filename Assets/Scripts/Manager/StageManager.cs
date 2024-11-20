using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

// stage 생성, 삭제 
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
        // 프로젝트 빌드할시 빌드된 파일에 resources안에 있는 에셋이 전부 포함
        // 구글 앱스토어 다시 들어가서 업데이트 
        // 빌드 버전이 올랐다.
        Stage stageOrigin = Resources.Load<Stage>("Prefabs/Stage/Stage");

        // 2.외부폴더 ex)Prefabs
        // UnityEditor.AssetDatabase.LoadAssetAtPath<Stage>("");
        // 빌드에 포함되지 않는다
        // 게임 앱에 들어갔는데 
        // 패치파일 다운로드 
        // 에셋번들 패치파일
        // 최근 addressable
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
