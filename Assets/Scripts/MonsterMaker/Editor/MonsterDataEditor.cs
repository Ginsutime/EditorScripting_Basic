using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MonsterData))]
public class MonsterDataEditor : Editor
{
    public override void OnInspectorGUI()
    {
        MonsterData data = (MonsterData)target;

        EditorGUILayout.LabelField(data.Name.ToUpper(), EditorStyles.boldLabel);
        EditorGUILayout.Space(10);

        // difficulty bar assuming all combat stats are equal (for sake of example)
        float difficulty = data.Health + data.Damage + data.Speed;
        ProgressBar(difficulty / 100, "Difficulty");

        // add before base elements
        base.OnInspectorGUI();
        // add below base elements
    }

    void ProgressBar(float value, string label)
    {
        Rect rect = GUILayoutUtility.GetRect(18, 40, "TextField");
        EditorGUI.ProgressBar(rect, value, label);
        EditorGUILayout.Space(10);
    }
}
