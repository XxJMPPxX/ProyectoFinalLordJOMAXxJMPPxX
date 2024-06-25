using System.Collections.Generic;
using UnityEngine;

public class ElementManager : MonoBehaviour
{
    private Queue<GameObject> elementQueue = new Queue<GameObject>();
    public Transform shootPoint; // Punto desde donde se instanciará el objeto al disparar

    [SerializeField]
    private string[] elementsInQueue = new string[maxElements]; // Arreglo para mostrar en el inspector

    private const int maxElements = 3;

    private void OnTriggerEnter(Collider other)
    {
        if ((other.CompareTag("hielo") || other.CompareTag("fuego")) && elementQueue.Count < maxElements)
        {
            AddElementToQueue(other.gameObject);
        }
    }

    private void AddElementToQueue(GameObject element)
    {
        if (elementQueue.Count < maxElements)
        {
            elementQueue.Enqueue(element);
            UpdateInspectorList();
        }
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && elementQueue.Count > 0)
        {
            ShootElement();
        }
    }

    private void ShootElement()
    {
        if (elementQueue.Count > 0)
        {
            GameObject elementToShoot = elementQueue.Dequeue();
            Instantiate(elementToShoot, shootPoint.position, shootPoint.rotation);
            Destroy(elementToShoot);
            UpdateInspectorList();
        }
    }

    private void UpdateInspectorList()
    {
        GameObject[] elementsArray = elementQueue.ToArray();
        for (int i = 0; i < maxElements; i++)
        {
            if (i < elementsArray.Length)
            {
                elementsInQueue[i] = elementsArray[i] != null ? elementsArray[i].name : "Empty";
            }
            else
            {
                elementsInQueue[i] = "Empty";
            }
        }
    }
}
