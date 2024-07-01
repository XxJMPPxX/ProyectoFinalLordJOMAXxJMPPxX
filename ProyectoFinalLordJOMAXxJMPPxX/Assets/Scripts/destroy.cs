using UnityEngine;
using System.Collections;

public class SelfDestruct : MonoBehaviour
{
    private void Awake()
    {
        StartCoroutine(DestroyAfterDelay(4f));
    }

    private IEnumerator DestroyAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}
