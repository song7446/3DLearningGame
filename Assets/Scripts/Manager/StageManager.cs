using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

// stage 생성, 삭제 
public class StageManager : MonoSingleton<StageManager>
{
    public Stage TestOrigin = null;
    public List<Stage> Stage = null;

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
        Stage = new List<Stage>();
        Stage instance = Instantiate<Stage>(TestOrigin);
        instance.transform.position = Vector3.zero;

        int randomWidth = Random.Range(10, 31);
        int randomHeight = Random.Range(10, 31);

        instance.Create(randomWidth, randomHeight);

        Stage.Add(instance);
    }
}
