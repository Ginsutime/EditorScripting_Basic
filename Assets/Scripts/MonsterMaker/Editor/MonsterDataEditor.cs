using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MonsterData))]
public class MonsterDataEditor : Editor
{
    private SerializedProperty _name;
    private SerializedProperty _monsterType;
    private SerializedProperty _chanceToDropItem;
    private SerializedProperty _rangeOfAwareness;
    private SerializedProperty _canEnterCombat;
    private SerializedProperty _damage;
    private SerializedProperty _health;
    private SerializedProperty _speed;
    private SerializedProperty _battleCry;
    private SerializedProperty _abilities;

    private void OnEnable()
    {
        // FindProperty lets us search for private variables
        _name = serializedObject.FindProperty("_name");
        _monsterType = serializedObject.FindProperty("_monsterType");
        _chanceToDropItem = serializedObject.FindProperty("_chanceToDropItem");
        _rangeOfAwareness = serializedObject.FindProperty("_rangeOfAwareness");
        _canEnterCombat = serializedObject.FindProperty("_canEnterCombat");
        _damage = serializedObject.FindProperty("_damage");
        _health = serializedObject.FindProperty("_health");
        _speed = serializedObject.FindProperty("_speed");
        _battleCry = serializedObject.FindProperty("_battleCry");
        _abilities = serializedObject.FindProperty("_abilities");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.UpdateIfRequiredOrScript(); // Update if we make a change

        EditorGUILayout.LabelField(_name.stringValue.ToUpper(), EditorStyles.boldLabel);
        EditorGUILayout.Space(10);

        // difficulty bar assuming all combat stats are equal (for sake of example)
        float difficulty = _health.intValue + _damage.intValue + _speed.intValue;
        ProgressBar(difficulty / 100, "Difficulty");

        EditorGUILayout.LabelField("General Stats", EditorStyles.boldLabel);
        EditorGUILayout.PropertyField(_name, new GUIContent("Name"));
        if (_name.stringValue == string.Empty)
        {
            EditorGUILayout.HelpBox("Caution: No name specified. Please name the monster!",
                MessageType.Warning);
        }

        EditorGUILayout.PropertyField(_monsterType, new GUIContent("Monster Type"));
        if (_monsterType.enumValueIndex == 0)
            EditorGUILayout.HelpBox("No MonsterType selected!", MessageType.Warning);

        EditorGUILayout.LabelField("Item Drop Chance: ");
        _chanceToDropItem.floatValue = EditorGUILayout.Slider(_chanceToDropItem.floatValue, 0, 100);
        EditorGUILayout.PropertyField(_rangeOfAwareness, new GUIContent("Awareness"));
        EditorGUILayout.PropertyField(_canEnterCombat, new GUIContent("Can Enter Combat?"));

        EditorGUILayout.Space(10);
        if (_canEnterCombat.boolValue == true)
        {
            EditorGUI.indentLevel++;
            EditorGUILayout.LabelField("Combat Stats", EditorStyles.boldLabel);
            EditorGUILayout.BeginHorizontal();

            EditorGUIUtility.labelWidth = 70;
            EditorGUILayout.PropertyField(_health, new GUIContent("Health"));
            if (_health.intValue < 0)
                EditorGUILayout.HelpBox("Negative health not allowed!", MessageType.Warning);
            EditorGUILayout.PropertyField(_damage, new GUIContent("Damage"));
            EditorGUILayout.PropertyField(_speed, new GUIContent("Speed"));

            EditorGUILayout.EndHorizontal();
            if (GUILayout.Button("Random Stats"))
            {
                RandomizeStats();
            }
            EditorGUI.indentLevel--;
        }

        EditorGUILayout.Space(10);
        EditorGUILayout.LabelField("Dialogue", EditorStyles.boldLabel);
        EditorGUILayout.PropertyField(_battleCry, new GUIContent("Battle Cry"));
        EditorGUILayout.PropertyField(_abilities, new GUIContent("Abilities"));

        serializedObject.ApplyModifiedProperties(); // If we made a change, apply it
    }

    void ProgressBar(float value, string label)
    {
        Rect rect = GUILayoutUtility.GetRect(18, 40, "TextField");
        EditorGUI.ProgressBar(rect, value, label);
        EditorGUILayout.Space(10);
    }

    void RandomizeStats()
    {
        _health.intValue = UnityEngine.Random.Range(1, 25);
        _damage.intValue = UnityEngine.Random.Range(1, 25);
        _speed.intValue = UnityEngine.Random.Range(1, 25);
    }
}
