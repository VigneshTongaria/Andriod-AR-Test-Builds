using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

#if UNITY_EDITOR
public class CustomEditorWindow : EditorWindow
{
    [MenuItem("Tools/CustomWindow")]
    public static void ShowWindow()
    {
        GetWindow<CustomEditorWindow>("CustomEditorWindow");
    }
    private void OnGUI()
    {
        GUILayout.Label("Reload Item Database", EditorStyles.boldLabel);
        if(GUILayout.Button("Reload Item"))
        {
            GameObject.Find("Databases").GetComponent<LoadExcel>().LoadItemData();
        }
    }
}
#endif