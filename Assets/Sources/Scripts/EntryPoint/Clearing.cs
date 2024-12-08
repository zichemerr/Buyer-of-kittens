using UnityEngine;
using UnityEngine.SceneManagement;

public class Clearing : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            PlayerPrefs.DeleteAll();
            SceneManager.LoadScene(0);
        }
    }

    [ContextMenu("Clear")]
    private void Clear()
    {
        PlayerPrefs.DeleteAll();
    }
}