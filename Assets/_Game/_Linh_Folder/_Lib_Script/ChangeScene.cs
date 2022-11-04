#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;


public class ChangeScene : Editor {

    [MenuItem("Open Scene/FirstScene #1")]
    public static void OpenLoading()
    {
        OpenScene("FirstScene");
    }

    [MenuItem("Open Scene/Shop #2")]
    public static void OpenHome()
    {
        OpenScene("Coffee Shop");
    }
    
    [MenuItem("Open Scene/Game #3")]
    public static void OpenGame()
    {
        OpenScene("Main Scene");
    }
    
    private static void OpenScene (string sceneName) {
		if (EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo ()) {
			EditorSceneManager.OpenScene ("Assets/_Game/Scenes/" + sceneName + ".unity");
		}
	}
}
#endif