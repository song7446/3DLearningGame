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

// ���Ƿ� ���� ũ��� 1�� ����
// ���� ũŰ�� 100�̸� ���� Ÿ�� 100�� 
// ���� ũŰ�� 100�̸� ���� Ÿ�� 100��
public class Tile
{
    public Vector3 Pos;
    public ETILE_TYPE E_Type;
    public GameObject TileGameObject;
}

public class Stage : MonoBehaviour
{
    // �ϳ��� ū ���������� �ְ� ���Ƿ� ���� ũŰ�� ��ȹ�� ������ 
    // �ϳ��� ��ȹ�� Ÿ�� 
    // Ÿ�Ͽ� �Ӽ��� �ο������ν� �Ϲ������� ��� �� ���� �� �� ���±� 
    // �������� ������ ���ش�

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
