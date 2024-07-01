using System;
using UnityEngine;

public class ElementManager : MonoBehaviour
{
    private class PriorityQueue<T>
    {
        public class Node
        {
            public T Value { get; set; }
            public Node Next { get; set; }
            public Node Previous { get; set; }

            public Node(T value)
            {
                Value = value;
                Next = null;
                Previous = null;
            }
        }

        public Node Head { get; private set; }
        public Node Tail { get; private set; }

        public void Enqueue(T value)
        {
            Node newNode = new Node(value);
            if (Head == null)
            {
                Head = newNode;
                Tail = newNode;
            }
            else
            {
                Tail.Next = newNode;
                newNode.Previous = Tail;
                Tail = newNode;
            }
        }

        public T Dequeue()
        {
            if (Head == null)
            {
                throw new NullReferenceException("The queue is empty.");
            }

            Node nodeToRemove = Head;
            Head = Head.Next;
            if (Head != null)
            {
                Head.Previous = null;
            }
            else
            {
                Tail = null;
            }
            return nodeToRemove.Value;
        }

        public int Count()
        {
            int count = 0;
            Node current = Head;
            while (current != null)
            {
                count++;
                current = current.Next;
            }
            return count;
        }
    }

    private PriorityQueue<GameObject> elementQueue = new PriorityQueue<GameObject>();
    public Transform shootPoint;
    public GameObject hieloPrefab;
    public GameObject fuegoPrefab;

    private const int maxElements = 3;
    [SerializeField]
    private GameObject[] elementsInQueue = new GameObject[maxElements];
    public Animator animator;

    private void OnTriggerEnter(Collider other)
    {
        if (elementQueue.Count() < maxElements)
        {
            if (other.CompareTag("hielo"))
            {
                AddElementToQueue(hieloPrefab);
            }
            else if (other.CompareTag("fuego"))
            {
                AddElementToQueue(fuegoPrefab);
            }
        }
    }

    private void AddElementToQueue(GameObject elementPrefab)
    {
        if (elementQueue.Count() < maxElements)
        {
            elementQueue.Enqueue(elementPrefab);
            UpdateInspectorList();
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && elementQueue.Count() > 0)
        {
            animator.SetBool("OnAttack", true);
            ShootElement();
        }
    }

    private void ShootElement()
    {
        if (elementQueue.Count() > 0)
        {
            GameObject elementPrefab = elementQueue.Dequeue();
            GameObject elementInstance = Instantiate(elementPrefab, shootPoint.position, shootPoint.rotation);
            UpdateInspectorList();
        }
    }

    private void UpdateInspectorList()
    {
        PriorityQueue<GameObject>.Node current = elementQueue.Head;
        int index = 0;
        while (index < maxElements)
        {
            if (current != null)
            {
                elementsInQueue[index] = current.Value;
                current = current.Next;
            }
            else
            {
                elementsInQueue[index] = null;
            }
            index++;
        }

        while (index < maxElements)
        {
            elementsInQueue[index] = null;
            index++;
        }
    }
}
