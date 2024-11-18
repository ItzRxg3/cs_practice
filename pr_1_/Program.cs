using System;

namespace pr_1_
{
    internal class Program
    {
	    private static TaskController _controller = new TaskController();
	    
        public static void Main(string[] args)
        {
	        _controller.RunAllTasks();
        }
    }
}