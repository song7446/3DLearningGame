using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ETILE_TYPE
{
    NONE,
    NOMAL,
    TRAP,
    COLLIDER,
    MAX,
}

// 임의로 정한 크기는 1로 고정
// 가로 크키가 100이면 가로 타입 100개 
// 세로 크키가 100이면 세로 타일 100개
public class Tile
{
    public Vector3 Pos;
    public ETILE_TYPE E_Type;
    public GameObject TileGameObject;
}

public class Stage : MonoBehaviour
{
    // 하나의 큰 스테이지가 있고 임의로 정한 크키로 구획을 나눈다 
    // 하나의 구획이 타일 
    // 타일에 속성값 부여함으로써 일반적으로 통로 길 함정 갈 수 없는길 
    // 스테이지 구성을 해준다

    public int Width = 0;
    public int Height = 0;

    public List<Tile> TileList = null;

    public void Create(int width, int height)
    {
        Width = width;
        Height = height;

        int wLastIdx = Width - 1;
        int hLastIdx = Height - 1;

        int createWallCount = 0;
        float widthWallPos = 0f;
        float heightWallPos = 0f;

        TileList = new List<Tile>();

        MonoObjectPool<Transform> tilePool = StageManager.Instance.TilePool;
        MonoObjectPool<Transform> wallPool = StageManager.Instance.WallPool;

        Vector3 stagePos = transform.position;

        Transform tmpTransform = null;
        Tile tempTile = null;

        for (int i = 0; i < Width; i++)
        {
            for (int j = 0; j < Height; j++)
            {
                createWallCount = 0;
                widthWallPos = 0f;
                heightWallPos = 0f;

                if (i == 0)
                {
                    ++createWallCount;
                    widthWallPos = -1f;
                }
                else if (i == wLastIdx)
                {
                    ++createWallCount;
                    widthWallPos = 1f;
                }

                if (j == 0)
                {
                    createWallCount += createWallCount > 0 ? 2 : 1;
                    heightWallPos = -1f;
                }
                else if (j == hLastIdx)
                {
                    createWallCount += createWallCount > 0 ? 2 : 1;
                    heightWallPos = 1f;
                }

                if (createWallCount > 0)
                {
                    if (createWallCount > 1)
                    {
                        tmpTransform = wallPool.Get(); //Instantiate<GameObject>(WallOrigin, transform);                       
                        tmpTransform.transform.position = stagePos + new Vector3(i, 0f, j + heightWallPos);
                        tmpTransform.gameObject.SetActive(true);

                        tmpTransform = wallPool.Get(); //Instantiate<GameObject>(WallOrigin, transform);
                        tmpTransform.transform.position = stagePos + new Vector3(i + widthWallPos, 0f, j);
                        tmpTransform.gameObject.SetActive(true);
                    }

                    tmpTransform = wallPool.Get(); //Instantiate<GameObject>(WallOrigin, transform);
                    tmpTransform.transform.position = stagePos + new Vector3(i + widthWallPos, 0f, j + heightWallPos);
                    tmpTransform.gameObject.SetActive(true);

                }
                tmpTransform = tilePool.Get(); //Instantiate<GameObject>(TileOrigin, transform);

                tempTile = new Tile();
                tempTile.TileGameObject = tmpTransform.gameObject;
                tempTile.E_Type = ETILE_TYPE.NOMAL;
                tempTile.Pos = new Vector3(i, 0f, j);

                tmpTransform.transform.localPosition = stagePos + tempTile.Pos;
                tmpTransform.gameObject.SetActive(true);

                TileList.Add(tempTile);
            }
        }
    }
}
