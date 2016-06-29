using System.Collections.Generic;

namespace ToDoList.Objects
{
  public class Task
  {

    private string _description;
    private int _id;
    private static List<Task> _instances = new List<Task> {};

    public Task(string description)
    {
      _description = description;
      _instances.Add(this);
      _id = _instances.Count;
    }
    public string GetDescription()
    {
      return _description;
    }
    public void SetDescription(string newDescription)
    {
      _description = newDescription;
    }
    public void SetId(int newId)
    {
      _id = newId;
    }
    public int GetId()
    {
      return _id;
    }
    public static List<Task> GetAll()
    {
      return _instances;
    }
    public static void ClearAll()
    {
      _instances.Clear();
    }
    public static Task Find(int searchId)
    {
      return _instances[searchId -1];
    }
    public static void RemoveTask(int searchId)
    {
      Task taskToRemove = Find(searchId);
      _instances.Remove(taskToRemove);
      for (int index = 0; index < _instances.Count; index++)
      {
        _instances[index].SetId(index + 1);
      }
    }
  }
}
