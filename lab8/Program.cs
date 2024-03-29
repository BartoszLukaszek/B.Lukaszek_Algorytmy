﻿using System;

namespace lab8
{
internal class Program
{
    private static void Main(string[] args)
    {
        Heap heap = new Heap();
        heap.Insert(6);
        heap.Insert(7);
        heap.Insert(8);
        heap.Insert(4);
        heap.Insert(2);
       
        if (heap.Remove() == 8)
        {
            Console.WriteLine("OK");
        }
        else
        {
            Console.WriteLine("ERROR");
        }
        PriorityQueue<int, int> queue = new PriorityQueue<int, int>(new IntDescending());
        queue.Enqueue(6, 6);
        queue.Enqueue(7, 7);
        queue.Enqueue(8, 8);
        queue.Enqueue(4, 4);
        queue.Enqueue(2, 2);
        while (queue.Count > 0)
        {
            Console.WriteLine(queue.Dequeue());
        }

        //Zad 1

        PriorityQueue<string, int> queue2 = new PriorityQueue<string, int>();
    queue2.Enqueue("Adam", 6);
    queue2.Enqueue("Robert", 2);
    queue2.Enqueue("Ewa", 1);
    while (queue2.Count > 0)
    {
        Console.WriteLine(queue2.Dequeue());
    }

    //Zad 2

    PriorityQueue<string, string> queueAlphabet = new PriorityQueue<string, string>(new AlphabeticComparer());
    queueAlphabet.Enqueue("Adam", "6");
    queueAlphabet.Enqueue("Robert", "2");
    queueAlphabet.Enqueue("Ewa", "1");
    while (queueAlphabet.Count > 0)
    {
        Console.WriteLine(queueAlphabet.Dequeue());
    }

    
    //"Adam" 6
    //"Ronert" 2
    //"Ewa" 1

//1
    //Zdefiniuj kolejke prioterowa dla łańcuchów o podanych priorytetach. w int
//2    
    //Zdefiniuj kolejke prioterowa dla łańcuchów o priorytecie leksograficzym tzn. najwysZy proirytet ma łańcuch pierwszy w porzadku alfabetycznym
//3    
    //Zdefiniuj kolejke prioterowa dla obiektow klasy Student o priorytecie w polu Ects im wyzsa liczba pkt tym wyzszy priorytet
}

class Student
{
    public string Name { get; set; }
    public int Ects { get; set; }
}


class AlphabeticComparer : IComparer<string>
{
    public int Compare(string x, string y)
    {
       return String.Compare(y, x);
    }

    
}




class IntDescending : IComparer<int>
{
    public int Compare(int x, int y)
    {
        return y.CompareTo(x);
    }
}
class Heap
{

    private int[] heap = new int[100];

    private int last = -1;

    bool IsEmpty()
    {
        return last < 0;
    }

    bool IsFull()
    {
        return last >= heap.Length - 1;
    }

    public bool Insert(int value)
    {
        if (IsFull())
        {
            return false;
        }

        last++;
        heap[last] = value;
        RebuildUp(last);
        return true;
    }

    public int Remove()
    {
       
       int returnValue = heap[0];
         heap[0] = heap[last];
            last--;
            
            RebuildDown(0);
            return returnValue;
            

    }

    void RebuildDown(int i)
    {
        int value = heap[i];
        while (i < last)
        {
            int left = Left(i);
            int right = Right(i);
            if (left > last)
            {
                break;
            }
            int maxChild = left;
            if (right <= last && heap[right] > heap[left])
            {
                maxChild = right;
            }
            if (heap[maxChild] > value)
            {
                (heap[i], heap[maxChild]) = (heap[maxChild], heap[i]);
                i = maxChild;
            }
            else
            {
                break;
            }
        }
    }

    void RebuildUp(int i)
    {
        int value = heap[i];
        while (i > 0 )
        {
            int parentValue = heap[Parent(i)];
            if (parentValue < value)
            {
                (heap[i], heap[Parent(i)]) = (heap[Parent(i)], heap[i]);
                i = Parent(i);
            }
            else
            {
                break;
            }
        }
    }

    int Parent(int i)
    {
        return (i - 1) / 2;
    }
    int Left(int i)
    {
        return 2 * i + 1;
    }
    int Right(int i)
    {
        return 2 * i + 2;
    }


}
}
}

