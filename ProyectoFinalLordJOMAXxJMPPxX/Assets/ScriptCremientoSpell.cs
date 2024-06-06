using UnityEngine;
using DG.Tweening;

public class SimpleController : MonoBehaviour
{
    [SerializeField] private float duration;
    [SerializeField] private Ease easeValue = Ease.Linear;

    private Vector3 originalScale;

    private void Start()
    {
        
        originalScale = transform.localScale;
       
        transform.localScale = Vector3.zero;

        Vector3 targetScale = Vector3.one;
        
        transform.DOScale(targetScale, duration)
            .SetEase(easeValue)
            .OnComplete(() => ReturnToOriginalScale());
    }
    private void ReturnToOriginalScale()
    {
       
        transform.DOScale(originalScale, duration)
            .SetEase(easeValue);
    }
}
