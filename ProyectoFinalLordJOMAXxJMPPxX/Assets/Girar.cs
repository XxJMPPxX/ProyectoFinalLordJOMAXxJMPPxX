using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Girar : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed = 30f; 

    void Update()
    {
       
        float angle = rotationSpeed * Time.deltaTime;

       
        Quaternion deltaRotation = Quaternion.Euler(0, 0, angle);

        
        transform.rotation *= deltaRotation;
    }
}
