using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace ZangdorGames.EditorHelpers.Tools
{
    /// <summary>
    /// Custom editor for our todos data
    /// </summary>
    [CustomEditor(typeof(ToDoMiniData))]
    class ToDoMiniDataEditor : Editor
    {
        /// <summary>
        /// The path where the exported json file will be saved
        /// </summary>
        private const string PATH_DIRECTORY = "Assets/";

        /// <summary>
        /// Name of the exported json file
        /// </summary>
        private const string EXPORT_FILENAME = "Exported todos.json";


        /// <summary>
        /// Data structure used to export the task to a json file
        /// </summary>
        [Serializable]
        private class TodoMiniDataExport
        {
            public List<ToDoMiniData.ToDoItem> tasks;

            public TodoMiniDataExport(ToDoMiniData data)
            {
                tasks = data.Items;
            }
        }

        /// <summary>
        /// The path where the exported json file will be saved
        /// Return the root of the project if the path PATH_DIRECTORY is invalid
        /// </summary>
        private string SavingDirectory
        {
            get
            {
                if (Directory.Exists(Application.dataPath + PATH_DIRECTORY))
                    return Application.dataPath + PATH_DIRECTORY;
                else
                    return Application.dataPath + "/";
            }
        }

        public override void OnInspectorGUI()
        {
            ToDoMiniData data = (ToDoMiniData)target;

            GUILayout.Space(5);
            GUILayout.Label("Settings", EditorStyles.boldLabel);

            GUILayout.Space(2);
            EditorGUI.BeginChangeCheck();
            EditorGUILayout.PropertyField(serializedObject.FindProperty("_displayDensity"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("_keepCompletedTasks"));
            serializedObject.ApplyModifiedProperties();
            if (EditorGUI.EndChangeCheck())
            {
                if (!data.KeepCompletedTasks)
                    DeleteCompletedTasks(ref data);
                UpdateToDoWindow();
            }

            // Clear completed tasks.
            if (GUILayout.Button("☑ Delete completed tasks"))
            {
                DeleteCompletedTasks(ref data);
                UpdateToDoWindow();
            }

            // Clear all tasks.
            GUILayout.Space(2);
            if (GUILayout.Button("✖ Delete all tasks"))
            {
                Undo.RecordObject(data, "Delete all tasks");
                data.Items.Clear();
                EditorUtility.SetDirty(data);
                UpdateToDoWindow();
            }

            // Import/export.
            GUILayout.Space(10);
            GUILayout.Label("Import/export", EditorStyles.boldLabel);
            GUILayout.BeginHorizontal();

            // Import tasks.
            DrawDropArea("Import (drop a file here)", (TextAsset droppedTextAsset) => ImportData(droppedTextAsset, ref data));
            GUILayout.Space(5);

            // Export tasks.
            GUIStyle buttonStyle = new GUIStyle(GUI.skin.button);
            buttonStyle.margin = new RectOffset();
            if (GUILayout.Button("Export", buttonStyle, GUILayout.Height(30)))
                ExportData(ref data);
            GUILayout.EndHorizontal();
        }

        /// <summary>
        /// Delete completed task and save the scriptable
        /// </summary>
        /// <param name="data">The data where the completed task will be deleted from</param>
        private void DeleteCompletedTasks(ref ToDoMiniData data)
        {
            Undo.RecordObject(data, "Delete completed tasks");
            data.DeleteCompletedTasks();
            EditorUtility.SetDirty(data);
            AssetDatabase.SaveAssets();
        }

        /// <summary>
        /// Import a json text asset and add the task to the current data list
        /// </summary>
        /// <param name="import"></param>
        /// <param name="existingData"></param>
        private void ImportData(TextAsset import, ref ToDoMiniData existingData)
        {
            TodoMiniDataExport parsedData = (TodoMiniDataExport)JsonUtility.FromJson(import.text, typeof(TodoMiniDataExport));
            Undo.RecordObject(existingData, "ToDo Mini import");
            existingData.Items.AddRange(parsedData.tasks);
            UpdateToDoWindow();
        }

        /// <summary>
        /// Export task into a json file
        /// </summary>
        /// <param name="data">The data to export</param>
        private void ExportData(ref ToDoMiniData data)
        {
            string dataInJson = JsonUtility.ToJson(new TodoMiniDataExport(data));
            string fileName = GetSafeFileName(SavingDirectory, EXPORT_FILENAME);
            File.WriteAllText(SavingDirectory + fileName, dataInJson);
            AssetDatabase.Refresh();
            EditorGUIUtility.PingObject(AssetDatabase.LoadAssetAtPath(PATH_DIRECTORY + fileName, typeof(UnityEngine.Object)));
        }

        /// <summary>
        /// Create a drop area that will invoke the action on a object drop
        /// </summary>
        /// <typeparam name="T">Type of the waited object</typeparam>
        /// <param name="boxText">Text to show in the drop area</param>
        /// <param name="ObjectAction">Action to invoke on drop</param>
        private void DrawDropArea<T>(string boxText, Action<T> ObjectAction) where T : UnityEngine.Object
        {
            Event currentEvent = Event.current;
            Rect boxRect = GUILayoutUtility.GetRect(50, 30, GUILayout.ExpandWidth(true));
            GUIStyle boxStyle = new GUIStyle(GUI.skin.box);
            boxStyle.alignment = TextAnchor.MiddleCenter;
            GUI.Box(boxRect, boxText, boxStyle);

            switch (currentEvent.type)
            {
                case EventType.DragUpdated:
                case EventType.DragPerform:
                    if (!boxRect.Contains(currentEvent.mousePosition))
                        break;

                    DragAndDrop.visualMode = DragAndDropVisualMode.Copy;
                    if (currentEvent.type == EventType.DragPerform)
                    {
                        DragAndDrop.AcceptDrag();

                        foreach (UnityEngine.Object droppedObject in DragAndDrop.objectReferences)
                            if (droppedObject is T)
                                ObjectAction((T)droppedObject);
                    }
                    break;
            }
        }

        /// <summary>
        /// Force a refresh and a focus on the Todo list editor window
        /// </summary>
        private void UpdateToDoWindow()
        {
            ToDoMiniEditorWindow.ShouldRefreshData = true;
            EditorWindow.GetWindow(typeof(ToDoMiniEditorWindow));
        }

        /// <summary>
        /// Provide a filename that doesn't exist in the directory
        /// </summary>
        /// <param name="directory">Directory where to look for identical filename</param>
        /// <param name="desiredFileName">Filename we would like to create</param>
        /// <returns></returns>
        private string GetSafeFileName(string directory, string desiredFileName)
        {
            FileInfo file = new FileInfo(directory + desiredFileName);
            int fileIndex = 0;
            while (file.Exists)
            {
                fileIndex++;
                file = new FileInfo(directory + desiredFileName.Insert(desiredFileName.Length - file.Extension.Length, " (" + fileIndex + ")"));
            }
            return file.Name;
        }
    }
}