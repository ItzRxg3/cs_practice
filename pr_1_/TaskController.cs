using System;
using System.Collections.Generic;

namespace pr_1_
{
	public class TaskController
	{
		private readonly List<Task> _tasks;

		public TaskController()
		{
			_tasks = new List<Task>
			{
				new Task1(),
				new Task2(),
				new Task3(),
				new Task4()
			};
		}

		public void RunAllTasks()
		{
			foreach (var task in _tasks)
			{
				task.Execute();
			}
		}
	}

}