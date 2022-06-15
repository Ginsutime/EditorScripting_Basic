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
        // add before base elements
        base.OnInspectorGUI();
        // add below base elements
        EditorGUILayout.LabelField("- - - - - - - - - - - -");
    }
}
