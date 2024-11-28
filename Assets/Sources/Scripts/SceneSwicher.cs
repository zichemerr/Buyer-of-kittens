using UnityEditor;
using UnityEditor.SceneManagement;

public class SceneSwitcher
{
    [MenuItem("Scene/main")]
    public static void Main()
    {
        EditorSceneManager.OpenScene("Assets/Sources/Scenes/SampleScene.unity");
    }
   
    [MenuItem("Scene/test")]
    public static void TestScene()
    {
        EditorSceneManager.OpenScene("Assets/Sources/Scenes/TestScene.unity");
    }
}

