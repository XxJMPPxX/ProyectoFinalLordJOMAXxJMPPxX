using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class ChangeSceneOnClick : MonoBehaviour
{
    public string sceneName;
    public UnityEvent onClick;

    public void OnMouseDown()
    {
        SceneManager.LoadScene(sceneName);
        onClick.Invoke();
    }
}
