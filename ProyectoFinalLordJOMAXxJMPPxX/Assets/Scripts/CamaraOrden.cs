using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraOrden : MonoBehaviour
{
    public Transform[] positions;
    private int currentIndex = 0;

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

        Transform target = GetCurrent();
        if (target != null)
        {
            transform.position = target.position;
            transform.rotation = target.rotation;
        }
    }

    private void MoveNext()
    {
        currentIndex = (currentIndex + 1) % positions.Length;
    }

    private void MovePrev()
    {
        currentIndex = (currentIndex - 1 + positions.Length) % positions.Length;
    }

    private Transform GetCurrent()
    {
        if (positions.Length == 0)
        {
            return null;
        }
        return positions[currentIndex];
    }
}
