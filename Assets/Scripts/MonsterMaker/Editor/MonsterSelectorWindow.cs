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
        EditorGUILayout.Space(10);

        if (GUILayout.Button("Select All"))
        {
            SelectAllMonsters();
        }
    }

    private void SelectAllMonsters()
    {
        // Collect all monsters in scene
        Monster[] monsters = FindObjectsOfType<Monster>();
        // Create temporary list to store valid monsters as we check
        List<GameObject> finalSelection = new List<GameObject>();
        // Check each monster, store if type matches
        foreach (Monster monster in monsters)
        {
            if (monster.Data.MonsterType == _selectedMonsterType)
            {
                finalSelection.Add(monster.gameObject);
            }
        }
        // Create a selection from valid monsters
        Selection.objects = finalSelection.ToArray();
    }
}
