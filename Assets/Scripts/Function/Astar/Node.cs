using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : IHeapItem<Node>
{
    public float gCost; // 현재 노드까지 오는데 걸린 비용
    public float hCost; // 현재 노드부터 최종목적지까지 걸리는 비용
    public float fCost { get => gCost+hCost; }

    public int HeapIndex { get; set; }

    public int CompareTo(Node other)
    {
        int compare = fCost.CompareTo(other.fCost);

        if (compare == 0) 
        {
            compare = hCost.CompareTo(other.hCost);
        }

        return -compare;
    }
}
