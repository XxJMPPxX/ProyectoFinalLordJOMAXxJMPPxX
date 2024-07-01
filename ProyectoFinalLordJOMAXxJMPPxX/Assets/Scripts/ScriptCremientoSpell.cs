using UnityEngine;
using DG.Tweening;

public class ScriptCrecimientoSpell : MonoBehaviour
{
    [SerializeField] private float duration;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private Ease easingType; 
    private Vector3 smallScale;
    private Vector3 targetScale = new Vector3(2f, 2f, 2f);

    void Start()
    {
        Vector3 originalScale = transform.localScale;
        smallScale = originalScale * 0.1f;
        transform.localScale = smallScale;

        
        transform.DOScale(targetScale, duration).SetEase(easingType);
    }

    void Update()
    {
        float angle = Time.time * rotationSpeed;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
