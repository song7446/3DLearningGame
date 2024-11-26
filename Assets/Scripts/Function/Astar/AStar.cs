using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AStar : MonoBehaviour
{
    // 넓이 탐색 BFS
    // 휴리스틱으로 수치를 구해서 다음으로 가야하는 위치의 최적의 경로를 구함

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
