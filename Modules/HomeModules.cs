using Nancy;
using System.Collections.Generic;
using ToDoList.Objects;

namespace ToDoList
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => {
        return View["index.cshtml"];
      };
      Get["/tasks"] = _ => {
        List<Task> allTasks = Task.GetAll();
        return View["tasks.cshtml", allTasks];
      };
      Get["/tasks/new"] = _ => {
        return View["task_form.cshtml"];
      };
      Post["/tasks"] = _ => {
        Task newTask = new Task(Request.Form["new-task"]);
        List<Task> allTasks = Task.GetAll();
        if (allTasks.Count == 0)
        {
          return View["index.cshtml"];
        }
        else
        {
          return View["tasks.cshtml", allTasks];
        }
      };
      Get["/tasks/{id}"] = parameters => {
        Task task = Task.Find(parameters.id);
        return View["/task.cshtml", task];
      };
      Get["/tasks/remove/{id}"] = parameters => {
        Task.RemoveTask(parameters.id);
        return View["/remove.cshtml"];
      };
    }
  }
}
