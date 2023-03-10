using UnityEditor;
using UnityEngine;

namespace Slides
{
    [CustomEditor(typeof(CameraController))]
    public class CameraControllerEditor : Editor
    {
        private CameraController controller;

        private void OnEnable()
        {
            controller = target as CameraController;
        }

        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            EditorGUILayout.Space(10);

            if (GUILayout.Button("Set Camera Position / Rotation"))
            {
                Transform camera = Camera.main.transform;
                camera.position = controller.targetPosition;
                camera.rotation = Quaternion.Euler(controller.targetRotation);
            }
        }
    }
}
