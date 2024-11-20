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
    public GameObject TileOrigin = null;


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

        TileList = new List<Tile>();

        GameObject tmpGameObject = null;
        Tile tempTile = null;

        for (int i = 0; i < Width; i++)
        {
            for (int j = 0; j < Height; j++)
            {
                tmpGameObject = Instantiate<GameObject>(TileOrigin, transform);
                tmpGameObject.SetActive(true);

                tempTile = new Tile();
                tempTile.TileGameObject = tmpGameObject;

                tempTile.E_Type = ETILE_TYPE.NOMAL;
                tempTile.Pos = new Vector3(i, 0f, j);
                tmpGameObject.transform.position = tempTile.Pos;

                TileList.Add(tempTile);
            }
        }
    }
}
