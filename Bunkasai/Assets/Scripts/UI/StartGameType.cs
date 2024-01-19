using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(MenuController))]
public class StartGameType : Editor
{
    SerializedObject obj;
    MenuController menuController;
    SerializedProperty iterator;
    List<string> propertyNames;
    GameType tryGetValue;
    //When value == dict option. it will show the correspond variable out on the Inspector
    //The string must as same as the variable you want to show
    //You can put mutiple variable with same option in dict
    //But you can't put same variable in different option
    Dictionary<string, GameType> specialPropertys = new Dictionary<string, GameType>
    {
        {"CustomizePanel",GameType.Customize },
        {"CustomizeButton",GameType.Customize }
    };
    private void OnEnable()
    {
        //target means itself
        obj = new SerializedObject(target);
        iterator = obj.GetIterator();
        iterator.NextVisible(true);
        propertyNames = new List<string>();
        do
        {
            propertyNames.Add(iterator.name);
        } while (iterator.NextVisible(false));
        menuController = (MenuController)target;
    }
    public override void OnInspectorGUI()
    {
        obj.Update();
        GUI.enabled = false;
        foreach (var name in propertyNames)
        {
            if (specialPropertys.TryGetValue(name, out tryGetValue) && tryGetValue != menuController.gameType) continue;
            EditorGUILayout.PropertyField(obj.FindProperty(name));
            if (!GUI.enabled) GUI.enabled = true;
        }
        obj.ApplyModifiedProperties();
    }
}
