using System;
using System.Collections.Generic;
using UnityEngine;

namespace ZangdorGames.EditorHelpers.Tools
{
    /// <summary>
    /// The scriptable holder of all the data we need for our todo list
    /// </summary>
    public class ToDoMiniData : ScriptableObject
    {
        /// <summary>
        /// A task description
        /// </summary>
        [Serializable]
        public class ToDoItem
        {
            /// <summary>
            /// The task name
            /// </summary>
            [SerializeField] private string _task = "";

            /// <summary>
            /// True is the task is complete, false otherwise
            /// </summary>
            [SerializeField] private bool _isComplete = false;

            public string Task { get => _task; set => _task = value; }
            public bool IsComplete { get => _isComplete; set => _isComplete = value; }

            public ToDoItem(string task)
            {
                _task = task;
            }
        }

        /// <summary>
        /// Density at which we display the tasks
        /// </summary>
        [SerializeField] private ToDoMiniEditorWindow.DisplayDensity _displayDensity = ToDoMiniEditorWindow.DisplayDensity.Default;

        /// <summary>
        /// True if we save the completed task, false otherwise
        /// </summary>
        [SerializeField] private bool _keepCompletedTasks = true;

        /// <summary>
        /// List of all the tasks
        /// </summary>
        [SerializeField] private List<ToDoItem> _items = new List<ToDoItem>();

        public ToDoMiniEditorWindow.DisplayDensity DisplayDensity { get => _displayDensity; set => _displayDensity = value; }
        public bool KeepCompletedTasks { get => _keepCompletedTasks; set => _keepCompletedTasks = value; }
        public List<ToDoItem> Items { get => _items; set => _items = value; }

        /// <summary>
        /// Add a task in the list
        /// </summary>
        /// <param name="task">The name of the task to add</param>
        public void AddTask(string task)
        {
            ToDoItem item = new ToDoItem(task);
            _items.Add(item);
        }

        /// <summary>
        /// Remove all completed task of the list
        /// </summary>
        public void DeleteCompletedTasks()
        {
            List<int> indexesToRemove = new List<int>();
            for (int i = 0; i < _items.Count; i++)
                if (_items[i].IsComplete)
                    indexesToRemove.Add(i);
            for (int i = indexesToRemove.Count - 1; i >= 0; i--)
                _items.RemoveAt(indexesToRemove[i]);
        }
    }

    

    
}