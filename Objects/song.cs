using System;
using System.Collections.Generic;

namespace CDProject.Objects
{
  public class Song
  {
    private string _name;

    public Song (string name)
    {
      _name = name;
    }

    public string GetName()
    {
      return _name;
    }

    public void SetName(string newName)
    {
      _name = newName;
    }
  }
}
