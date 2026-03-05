using UnityEngine;
using UnityEditor;
using System.Linq;

[CustomPropertyDrawer(typeof(SceneDropdownAttribute))]
public class SceneDropdownDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        var scenes = EditorBuildSettings.scenes
        .Where(scene => scene.enabled)
            .Select(scene => System.IO.Path.GetFileNameWithoutExtension(scene.path))
            .ToArray();

        int index = Mathf.Max(0, System.Array.IndexOf(scenes, property.stringValue));

        index = EditorGUI.Popup(position, label.text, index, scenes);

        property.stringValue = scenes[index];
    }
}
