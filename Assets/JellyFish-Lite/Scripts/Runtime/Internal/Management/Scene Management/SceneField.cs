// Created by Kearan Petersen : https://www.blumalice.wordpress.com | https://www.linkedin.com/in/kearan-petersen/
// Original concept by https://answers.unity.com/users/382789/glitchers.html

using System;
using UnityEngine;
using Object = UnityEngine.Object;
#if UNITY_EDITOR
using UnityEditor;

#endif

namespace JellyFish.Internal.Management
{
    [Serializable]
    public class SceneField
    {
        [SerializeField]
        private Object m_SceneAsset;

        [SerializeField]
        private string m_SceneName = "";

        public string SceneName
        {
            get
            {
                if (string.IsNullOrEmpty(m_SceneName)) m_SceneName = m_SceneAsset?.name;

                return m_SceneName;
            }
            set => m_SceneName = value;
        }

        public Object SceneAsset
        {
            get => m_SceneAsset;
            set => m_SceneAsset = value;
        }

        // makes it work with the existing Unity methods (LoadLevel/LoadScene)
        public static implicit operator string(SceneField sceneField)
        {
            return sceneField.SceneName;
        }
    }

#if UNITY_EDITOR
    [CustomPropertyDrawer(typeof(SceneField))]
    public class SceneFieldPropertyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect _position, SerializedProperty _property, GUIContent _label)
        {
            EditorGUI.BeginProperty(_position, GUIContent.none, _property);

            SerializedProperty sceneAsset = _property.FindPropertyRelative("m_SceneAsset");
            SerializedProperty sceneName  = _property.FindPropertyRelative("m_SceneName");

            _position = EditorGUI.PrefixLabel(_position, GUIUtility.GetControlID(FocusType.Passive), _label);

            if (sceneAsset != null)
            {
                sceneAsset.objectReferenceValue =
                    EditorGUI.ObjectField(_position, sceneAsset.objectReferenceValue, typeof(SceneAsset), false);

                if (sceneAsset.objectReferenceValue != null)
                    sceneName.stringValue = (sceneAsset.objectReferenceValue as SceneAsset).name;
            }

            EditorGUI.EndProperty();
        }
    }
#endif
}