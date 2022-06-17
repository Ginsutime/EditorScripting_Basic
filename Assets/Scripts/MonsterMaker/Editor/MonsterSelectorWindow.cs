using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MonsterSelectorWindow : EditorWindow
{
    private MonsterType _selectedMonsterType = MonsterType.None;

    [MenuItem("Window/Monster Selector")]
    public static void ShowWindow()
    {
        GetWindow<MonsterSelectorWindow>("Monster Selector");
    }

    private void OnGUI()
    {
        // Window code goes here - acts like Update
        EditorGUILayout.Space(10);
        GUILayout.Label("Selection Filters:", EditorStyles.boldLabel);
        _selectedMonsterType = (MonsterType)EditorGUILayout.EnumPopup(
            "MonsterType to select:", _selectedMonsterType);
    }
}
