using UnityEditor;
using UnityEngine;

namespace Common.Logic.Event.Editor
{
    [CustomEditor(typeof(ActionEvent), editorForChildClasses: true)]
    public class ActionEventEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            GUI.enabled = Application.isPlaying;

            ActionEvent e = target as ActionEvent;
            if (GUILayout.Button("Raise"))
            {
                e.Raise();
            }
        }
    }
}