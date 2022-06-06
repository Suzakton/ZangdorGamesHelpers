using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEditor.IMGUI.Controls;
using UnityEngine;
using ZangdorGames.EditorHelpers.Utilities;

namespace ZangdorGames.EditorHelpers.Tools
{
    /// <summary>
    /// Editor window used to manage our todos
    /// </summary>
    public class ToDoMiniEditorWindow : EditorWindow
    {
        /// <summary>
        /// Path of the TODO list tool in the package.
        /// </summary>
        private const string PACKAGE_PATH = "Packages/com.zangdorgames.helpers/Editor/TodoMiniUpgraded";

        /// <summary>
        /// Identifier of the new task textfield
        /// </summary>
        private const string CONTROL_NEW_TASK_TEXTFIELD = "miniNewTask";

        /// <summary>
        /// Identifier of all the task textfield
        /// </summary>
        private const string CONTROL_TASK_TEXTFIELD = "miniTaskArea";

        /// <summary>
        /// True if the data need to be refreshed (task deleted, new import...)
        /// </summary>
        public static bool ShouldRefreshData = true;

        /// <summary>
        /// Densities at wich task can be displayed
        /// </summary>
        public enum DisplayDensity { Default, Compact }

        /// <summary>
        /// Scriptable containing all datas
        /// </summary>
        private ToDoMiniData _data = null;

        /// <summary>
        /// New task text
        /// </summary>
        private string _newTask = "";

        /// <summary>
        /// Current search text
        /// </summary>
        private string _currentSearch;

        /// <summary>
        /// Is true if return was pressed last frame
        /// </summary>
        private bool _returnWasPressed = false;

        /// <summary>
        /// Show / Hide completed tasks
        /// </summary>
        private bool _shouldDrawCompletedTasks = false;

        /// <summary>
        /// Index of the last text area focused
        /// </summary>
        private int _lastTextAreaIndex = -1;

        /// <summary>
        /// Tell when to focus on the new taks text area
        /// </summary>
        private bool _shouldRefocusOnNewTask = true;

        /// <summary>
        /// Scroll position on the todo list window
        /// </summary>
        private Vector2 _scrollPosition;

        /// <summary>
        /// Style for the ongoing tasks
        /// </summary>
        private GUIStyle _ongoingTaskStyle;

        /// <summary>
        /// Style for the completed tasks
        /// </summary>
        private GUIStyle _completedTaskStyle;

        /// <summary>
        /// Search field UI
        /// </summary>
        private SearchField _searchField;

        /// <summary>
        /// Refocus getter
        /// </summary>
        public bool ShouldRefocusOnNewTask { get => _shouldRefocusOnNewTask; set => _shouldRefocusOnNewTask = value; }

        /// <summary>
        /// Size of the buttons (for style)
        /// </summary>
        private int ButtonsCompactFontSize
        {
            get
            {
#if UNITY_2019_1_OR_NEWER
                return 11;
#else
                return 9;
#endif
            }
        }

        /// <summary>
        /// Data getter, create scriptable if not found at PACKAGE_PATH and reload data if needed
        /// </summary>
        private ToDoMiniData Data
        {
            get
            {
                if (_data == null || ShouldRefreshData)
                {
                    _data = GetOrCreateData(PACKAGE_PATH);
                    ShouldRefreshData = false;
                }
                return _data;
            }
        }


        /// <summary>
        /// Return true if Enter key is pressed
        /// </summary>
        private bool IsPressingReturn { get { return Event.current.keyCode == KeyCode.Return || Event.current.keyCode == KeyCode.KeypadEnter; } }


        /// <summary>
        /// Get the scriptable for data. Create it if needed
        /// </summary>
        /// <param name="path">The path to load or create the data</param>
        /// <returns></returns>
        private ToDoMiniData GetOrCreateData(string path)
        {
            ToDoMiniData data = AssetDatabaseUtility.GetOrCreateScriptableObjectAsset<ToDoMiniData>($"{path}/ToDoMiniData.asset");
            AssetDatabase.Refresh();
            return data;
        }

        private void OnGUI()
        {
            CreateGUIStyles();
            DrawSearchAndSettings();

            // Draw search results, or tasks.
            _scrollPosition = EditorGUILayout.BeginScrollView(_scrollPosition);
            if (!string.IsNullOrEmpty(_currentSearch))
            {
                DrawSearchResults();
            }
            else
            {
                DrawCurrentTasks();

                if (Data.Items.Count > 0 && Data.KeepCompletedTasks)
                    DrawCompletedTasksButton();

                if (Data.Items.Count > 0 && Data.KeepCompletedTasks && _shouldDrawCompletedTasks)
                    DrawCompletedTasks();
            }
            EditorGUILayout.EndScrollView();

            DrawNewTaskPanel();

            if (focusedWindow == this && GUIUtility.hotControl != 0)
            {
                // If a task area is selected, save when we change control or when we lose focus.
                if (GUI.GetNameOfFocusedControl() == CONTROL_TASK_TEXTFIELD)
                    _lastTextAreaIndex = GUIUtility.hotControl;
                else if (_lastTextAreaIndex >= 0 && _lastTextAreaIndex != GUIUtility.hotControl)
                {
                    _lastTextAreaIndex = -1;
                    Save();
                }

                // Stop the search if we are into the newTask field.
                if (GUI.GetNameOfFocusedControl() == CONTROL_NEW_TASK_TEXTFIELD)
                {
                    EmptySearch();
                    _shouldRefocusOnNewTask = true;
                }
            }
        }

        void OnLostFocus()
        {
            // Save the previous text area.
            if (_lastTextAreaIndex >= 0)
            {
                _lastTextAreaIndex = -1;
                Save();
            }

            EmptySearch();
        }

        void OnDestroy()
        {
            if (Data)
                Save();
        }

        /// <summary>
        /// Create gui styles
        /// </summary>
        private void CreateGUIStyles()
        {
            if (_ongoingTaskStyle == null)
            {
                _ongoingTaskStyle = new GUIStyle(GUI.skin.label)
                {
                    alignment = TextAnchor.MiddleLeft,
                    wordWrap = true
                };
                if (Data.DisplayDensity == DisplayDensity.Compact)
                {
                    RectOffset taskPadding = _ongoingTaskStyle.padding;
                    taskPadding.top = 3;
                    taskPadding.bottom = 0;
                    _ongoingTaskStyle.padding = taskPadding;
                    RectOffset taskMargin = _ongoingTaskStyle.margin;
                    taskMargin.top = taskMargin.bottom = 0;
                    _ongoingTaskStyle.margin = taskMargin;
                }
            }
            if (_completedTaskStyle == null)
            {
                _completedTaskStyle = new GUIStyle(_ongoingTaskStyle);
                _completedTaskStyle.normal.textColor = _completedTaskStyle.hover.textColor = Color.grey;
            }
        }

        /// <summary>
        /// Draw the search bar and the settings button
        /// </summary>
        private void DrawSearchAndSettings()
        {
            GUILayout.BeginHorizontal(GUI.skin.FindStyle("Toolbar"));

            // Searchbar.
#if UNITY_2019_1_OR_NEWER
            GUILayout.Space(3);
#endif
            Rect searchRect = GUILayoutUtility.GetRect(1, 1, 18, 18, GUILayout.ExpandWidth(true));
            searchRect.y += 2;
            if (_searchField == null)
                _searchField = new SearchField();
            _currentSearch = _searchField.OnToolbarGUI(searchRect, _currentSearch);

            // Settings cog.
#if UNITY_2019_1_OR_NEWER
            GUILayout.Space(-3);
#else
            GUILayout.Space(5);
#endif
            if (GUI.Button(
                EditorGUILayout.GetControlRect(false, 20, GUILayout.MaxWidth(20)),
                EditorGUIUtility.IconContent("_Popup"),
                GUI.skin.FindStyle("IconButton")))
            {
                GenericMenu menu = new GenericMenu();
                menu.AddItem(new GUIContent("Settings"), false, () =>
                {
                    // Open the inspector and select the Data object.
                    EditorApplication.ExecuteMenuItem(
#if UNITY_2018_1_OR_NEWER
                    "Window/General/Inspector"
#else
                    "Window/Inspector"
#endif
                    );
                    if (Selection.activeObject == Data)
                        EditorGUIUtility.PingObject(Data);
                    else
                        Selection.SetActiveObjectWithContext(Data, null);
                });
                menu.ShowAsContext();
            }
#if UNITY_2019_1_OR_NEWER
            GUILayout.Space(-2);
#else
            GUILayout.Space(-5);
#endif
            GUILayout.EndHorizontal();
        }

        /// <summary>
        /// Draw search result or ongoing task if no search
        /// </summary>
        private void DrawCurrentTasks()
        {
            // Draw tasks.
            bool hasUncompletedTasks = false;
            for (int i = 0; i < Data.Items.Count; i++)
            {
                ToDoMiniData.ToDoItem item = Data.Items[i];
                if (item.IsComplete)
                    continue;

                hasUncompletedTasks = true;
                DrawTask(i);
            }

            // Draw a message if there are no tasks.
            if (!hasUncompletedTasks)
                EditorGUILayout.LabelField("No uncompleted tasks.", EditorStyles.largeLabel);
        }

        /// <summary>
        /// Draw an ongoing tasks
        /// </summary>
        /// <param name="i"></param>
        private void DrawTask(int i)
        {
            EditorGUILayout.BeginHorizontal();

            // Toggle.
            if (EditorGUILayout.Toggle(Data.Items[i].IsComplete, GUILayout.Width(12)))
            {
                if (Data.KeepCompletedTasks)
                {
                    Data.Items[i].IsComplete = true;
                    Save();
                }
                else
                {
                    DeleteTask(i);
                    return;
                }
            }

            // Task content.
            GUI.SetNextControlName(CONTROL_TASK_TEXTFIELD);
            Data.Items[i].Task = EditorGUILayout.TextArea(Data.Items[i].Task, _ongoingTaskStyle);

            // Draw ↑↓✖.
            DrawUpDown(i);
            GUILayout.Space(Data.DisplayDensity == DisplayDensity.Default ? 1 : -2);
            DrawDelete(i);
            EditorGUILayout.EndHorizontal();
        }

        /// <summary>
        /// Drawn the up and down buttons used to move taks
        /// </summary>
        /// <param name="i">The index of the task for which we draw the buttons</param>
        private void DrawUpDown(int i)
        {
            GUIStyle upDownStyle = new GUIStyle(GUI.skin.button)
            {
                fixedWidth = Data.DisplayDensity == DisplayDensity.Compact ? 13 : 15,
                padding = new RectOffset(5, 3, 2, 3),
            };
            if (Data.DisplayDensity == DisplayDensity.Compact)
            {
                upDownStyle.fixedHeight = 16;
                upDownStyle.fontSize = ButtonsCompactFontSize;
            }
            if (GUILayout.Button("↑", upDownStyle) && i > 0)
            {
                Undo.RecordObject(Data, "Move task up");
                Data.Items.Insert(0, Data.Items[i]);
                Data.Items.RemoveAt(i + 1);
                Save();
            }
            GUILayout.Space(-4);
            if (GUILayout.Button("↓", upDownStyle) && i < Data.Items.Count)
            {
                Undo.RecordObject(Data, "Move task up");
                Data.Items.Add(Data.Items[i]);
                Data.Items.RemoveAt(i);

                Save();
            }
        }

        /// <summary>
        /// Draw the button used to delete task
        /// </summary>
        /// <param name="index">The index of the task for which we draw the button</param>
        private void DrawDelete(int index)
        {
            GUIStyle deleteButtonStyle = new GUIStyle(GUI.skin.button);
            deleteButtonStyle.fixedWidth = Data.DisplayDensity == DisplayDensity.Compact ? 18 : 20;
            if (Data.DisplayDensity == DisplayDensity.Compact)
            {
                deleteButtonStyle.fixedHeight = 16;
                deleteButtonStyle.fontSize = ButtonsCompactFontSize;
            }
            deleteButtonStyle.padding = new RectOffset(4, 3, 2, 3);
            if (GUILayout.Button("✖", deleteButtonStyle))
                DeleteTask(index);
        }

        /// <summary>
        /// Delete a task from the data
        /// </summary>
        /// <param name="index">The index of the task to delete</param>
        private void DeleteTask(int index)
        {
            Undo.RecordObject(Data, "Delete task");
            Data.Items.RemoveAt(index);
            Save();
        }

        /// <summary>
        /// Show / hide completed tasks button
        /// </summary>
        private void DrawCompletedTasksButton()
        {
            if (!_shouldDrawCompletedTasks)
            {
                if (GUILayout.Button("Show completed tasks"))
                    _shouldDrawCompletedTasks = true;
            }
            else if (GUILayout.Button("Hide completed tasks"))
                _shouldDrawCompletedTasks = false;
        }

        /// <summary>
        /// Draw all completed tasks
        /// </summary>
        void DrawCompletedTasks()
        {
            bool hasCompletedTasks = false;
            for (int i = 0; i < Data.Items.Count; i++)
            {
                if (!Data.Items[i].IsComplete)
                    continue;

                hasCompletedTasks = true;
                ToDoMiniData.ToDoItem item = Data.Items[i];
                EditorGUILayout.BeginHorizontal();
                if (EditorGUILayout.Toggle(item.IsComplete, GUILayout.Width(12)) == false)
                {
                    Data.Items[i].IsComplete = false;
                    Save();
                }

                GUI.SetNextControlName(CONTROL_TASK_TEXTFIELD);
                EditorGUILayout.TextArea(item.Task, _completedTaskStyle);

                DrawDelete(i);
                EditorGUILayout.EndHorizontal();
            }
            if (!hasCompletedTasks)
                EditorGUILayout.LabelField("No completed tasks.", EditorStyles.largeLabel);
        }

        /// <summary>
        /// Draw a completed task
        /// </summary>
        /// <param name="i">The index of the completed task to draw</param>
        private void DrawCompletedTask(int i)
        {
            EditorGUILayout.BeginHorizontal();

            // Toggle.
            if (EditorGUILayout.Toggle(Data.Items[i].IsComplete, GUILayout.Width(12)) == false)
            {
                Data.Items[i].IsComplete = false;
                Save();
            }

            // Task content.
            GUI.SetNextControlName(CONTROL_TASK_TEXTFIELD);
            EditorGUILayout.TextArea(Data.Items[i].Task, _completedTaskStyle);

            // Draw ✖.
            DrawDelete(i);
            EditorGUILayout.EndHorizontal();
        }

        /// <summary>
        /// Draw the new task panel
        /// </summary>
        private void DrawNewTaskPanel()
        {
            // Text field (focus on it if needed).
            GUI.SetNextControlName(CONTROL_NEW_TASK_TEXTFIELD);
            GUIStyle fieldStyle = new GUIStyle(GUI.skin.textField);
            fieldStyle.wordWrap = true;
            _newTask = EditorGUILayout.TextField(_newTask, fieldStyle, GUILayout.Height(40));
            if (_shouldRefocusOnNewTask)
            {
                EditorGUI.FocusTextInControl(CONTROL_NEW_TASK_TEXTFIELD);
                _shouldRefocusOnNewTask = false;
            }

            // "Add" button.
            if ((GUILayout.Button("+ Add task") || _returnWasPressed) && !string.IsNullOrEmpty(_newTask))
            {
                Data.AddTask(_newTask);
                _newTask = "";
                _shouldRefocusOnNewTask = true;
                Save();
            }
            GUILayout.Space(6);

            // Detect return press.
            if (_returnWasPressed && !IsPressingReturn)
                EditorGUI.FocusTextInControl(CONTROL_NEW_TASK_TEXTFIELD);
            _returnWasPressed = IsPressingReturn;
        }

        /// <summary>
        /// Draw all search result
        /// </summary>
        private void DrawSearchResults()
        {
            List<int> items = FindItems(_currentSearch);
            foreach (var item in items)
            {
                if (!Data.Items[item].IsComplete)
                    DrawTask(item);
                else
                    DrawCompletedTask(item);
            }
        }

        /// <summary>
        /// Force data to dirty and reload it
        /// </summary>
        private void Save()
        {
            EditorUtility.SetDirty(Data);
            AssetDatabase.SaveAssets();
            if (Selection.activeObject == Data)
                Selection.activeObject = null;
        }

        /// <summary>
        /// Look for all task that contain the search
        /// </summary>
        /// <param name="search">The string to look for in each task</param>
        /// <returns>A list of index of each task containing the string</returns>
        private List<int> FindItems(string search)
        {
            List<int> items = new List<int>();
            string[] searchItems = search.Split(' ');
            for (int i = 0; i < Data.Items.Count; i++)
            {
                bool correctItem = true;
                // The item is correct only if it matches all the search terms.
                for (int j = 0; j < searchItems.Length; j++)
                    if (!Regex.IsMatch(Data.Items[i].Task, searchItems[j], RegexOptions.IgnoreCase))
                    {
                        correctItem = false;
                        j = searchItems.Length;
                    }
                if (correctItem)
                    items.Add(i);
            }
            return items;
        }

        /// <summary>
        /// Reset the searchbar
        /// </summary>
        public void EmptySearch()
        {
            _currentSearch = "";
        }
    }
}