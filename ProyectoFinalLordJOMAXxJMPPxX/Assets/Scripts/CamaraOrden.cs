using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CamaraOrden : MonoBehaviour
{
    private class Node
    {
        public Transform Pocision;
        public Node next;
        public Node prev;

        public Node(Transform data)
        {
            this.Pocision = data;
        }
    }

    private Node head;
    private Node tail;
    private Node currentNode;

    public Transform[] positions;
    public float transitionDuration = 1f; // Duración de la transición en segundos
    public Ease transitionEase = Ease.InOutSine; // Tipo de easing para la transición

    void Start()
    {
        if (positions.Length == 0)
        {
            return;
        }

        // Crear los nodos y enlazarlos en una lista doblemente enlazada circular
        head = new Node(positions[0]);
        tail = head;

        for (int i = 1; i < positions.Length; i++)
        {
            Node newNode = new Node(positions[i]);
            tail.next = newNode;
            newNode.prev = tail;
            tail = newNode;
        }

        // Hacer la lista circular
        tail.next = head;
        head.prev = tail;

        currentNode = head;
        MoveToCurrentPosition();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            MovePrev();
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            MoveNext();
        }
    }

    private void MoveNext()
    {
        if (currentNode != null)
        {
            currentNode = currentNode.next;
            MoveToCurrentPosition();
        }
    }

    private void MovePrev()
    {
        if (currentNode != null)
        {
            currentNode = currentNode.prev;
            MoveToCurrentPosition();
        }
    }

    private void MoveToCurrentPosition()
    {
        if (currentNode != null)
        {
            Transform target = currentNode.Pocision;
            transform.DOMove(target.position, transitionDuration).SetEase(transitionEase);
            transform.DORotateQuaternion(target.rotation, transitionDuration).SetEase(transitionEase);
        }
    }
}
