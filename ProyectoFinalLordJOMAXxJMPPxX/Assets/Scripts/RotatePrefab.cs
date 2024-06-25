using UnityEngine;

public class RotatePrefab : MonoBehaviour
{
    public Transform rotation;

    void Start()
    {
        transform.rotation = Quaternion.Euler(-90, 0, 0);
    }

  
}
