using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : IHeapItem<Node>
{
    public float gCost; // ���� ������ ���µ� �ɸ� ���
    public float hCost; // ���� ������ �������������� �ɸ��� ���
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
