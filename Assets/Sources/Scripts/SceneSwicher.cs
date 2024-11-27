using UnityEditor;
using UnityEditor.SceneManagement;

public class SceneSwitcher
{
    [MenuItem("Scene/main")]
    public static void Main()
    {
        EditorSceneManager.OpenScene("Assets/Sources/Scenes/SampleScene.unity");
    }
}

