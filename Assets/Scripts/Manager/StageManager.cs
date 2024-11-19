using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// stage 생성, 삭제 
public class StageManager : MonoSingleton<StageManager>
{
    public List<GameObject> Stage = null;

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

    public void SetStage(GameObject stage)
    {
        Stage.Add(stage);
    }

    public void CreateStage()
    {
        Stage.Add(new GameObject());
    }
}
