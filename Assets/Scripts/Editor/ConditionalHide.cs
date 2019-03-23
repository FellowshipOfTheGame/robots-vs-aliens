using UnityEditor;

[CustomEditor(typeof(AddLoadBehaviourToButton))]
public class ConditionalHide : Editor
{
    override public void OnInspectorGUI()
    {
        var addLoadBehaviourToButton = target as AddLoadBehaviourToButton;

        EditorGUILayout.HelpBox("Only one of the options can be selected (Restriction pending)", MessageType.Info);

        addLoadBehaviourToButton.AddRestartScene = EditorGUILayout.Toggle("Add Restart Scene", addLoadBehaviourToButton.AddRestartScene);

        addLoadBehaviourToButton.AddLoadScene = EditorGUILayout.Toggle("Add Load Scene", addLoadBehaviourToButton.AddLoadScene);

        if (addLoadBehaviourToButton.AddLoadScene)
        {
            addLoadBehaviourToButton.SceneName = EditorGUILayout.TextField("Scene Name", addLoadBehaviourToButton.SceneName);
        }

    }
}
