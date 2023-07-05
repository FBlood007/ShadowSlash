using UnityEditor;
using UnityEngine;

[ExecuteInEditMode]
public class PlayerPrefRemove : EditorWindow
{
    [MenuItem("Tools/Player Pref Remover")]

    public static void DeletePlayerPref()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("All Player prefs deleted!");
    }
}
