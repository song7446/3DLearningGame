using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 이진트리
public class Heap<T> where T : IHeapItem<T>
{
    private T[] Items;
    private int CurrentItemCount;

    public void Init(int size)
    {
        Items = new T[size];
    }

    public void Add(T item)
    {
        item.HeapIndex = CurrentItemCount;
        Items[CurrentItemCount] = item;
        SortUP(item);
        CurrentItemCount++;
    }

    public T RemoveFirst()
    {
        T firstItem = Items[0];
        CurrentItemCount--;

        Items[0] = Items[CurrentItemCount];
        Items[0].HeapIndex = 0;
        SortDown(Items[0]);

        return firstItem;
    }

    public void Clear()
    {
        CurrentItemCount = 0;
    }

    // 밑에서부터 위로 정렬
    public void SortUP(T item)
    {
        int parentIndex = (int)((item.HeapIndex - 1) * 0.5f);

        while (true)
        {
            T parentItem = Items[parentIndex];
            if (item.CompareTo(parentItem) > 0)
            {
                Swap(item, parentItem);
            }
            else
            {
                break;
            }

            parentIndex = (int)((item.HeapIndex - 1) * 0.5f);
        }

        //              0
        //      1               2
        //  3       4       5       6

        // 3 - 1 = 2
        // 2 * 0.5f = 1

        // 4 - 1 = 3
        // 3 * 0.5 = 1.5f == 1
    }

    // 위에서부터 아래로 정렬
    public void SortDown(T item)
    {
        int childLeftIndex = 0;
        int childRightIndex = 0;
        int swapIndex = 0;

        while (true)
        {
            childLeftIndex = item.HeapIndex * 2 + 1;
            childRightIndex = item.HeapIndex * 2 + 2;

            if (childLeftIndex < CurrentItemCount)
            {
                swapIndex = childLeftIndex;

                if (childRightIndex < CurrentItemCount)
                {
                    if (Items[childLeftIndex].CompareTo(Items[childRightIndex]) < 0)
                    {
                        swapIndex = childRightIndex;
                    }
                }
                if (item.CompareTo(Items[swapIndex]) < 0)
                {
                    Swap(item, Items[swapIndex]);
                }
                else
                {
                    return;
                }
            }
        }
    }

    public bool Contains(T item)
    {
        return Equals(Items[item.HeapIndex], item);
    }

    private void Swap(T itemA, T itemB)
    {
        Items[itemA.HeapIndex] = itemB;
        Items[itemB.HeapIndex] = itemA;
        int prevAIndex = itemA.HeapIndex;
        itemA.HeapIndex = itemB.HeapIndex;
        itemB.HeapIndex = prevAIndex;
    }
}

public interface IHeapItem<T> : IComparable<T>
{
    public int HeapIndex
    {
        get;
        set;
    }
}
