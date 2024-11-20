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
    public GameObject TileOrigin = null;


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
