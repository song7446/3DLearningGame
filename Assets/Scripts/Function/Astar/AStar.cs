using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AStar : MonoBehaviour
{
    // ���� Ž�� BFS
    // �޸���ƽ���� ��ġ�� ���ؼ� �������� �����ϴ� ��ġ�� ������ ��θ� ����

    public Node[,] NodeArray;

    private Heap<Node> OpenSet;
    private HashSet<Node> CloseSet;

    private int Width = 0;
    private int Height = 0;

    public void Init()
    {

    }

    public void Clear()
    {

    }

    public void FindPath()
    {

    }
}
