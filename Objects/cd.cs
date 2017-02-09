using System;
using System.Collections.Generic;

namespace CDProject.Objects
{
  public class Album
  {
    private string _title;
    private string  _artist;
    private int _id;
    private static List<Album> _albumList = new List<Album>{};

    public Album (string title, string artist)
    {
      _title = title;
      _artist = artist;
    }
    public string GetTitle()
    {
      return _title;
    }

    public void SetTitle(string newTitle)
    {
      _title = newTitle;
      _albumList.Add(this);
      _id = _albumList.Count;
    }
    public string GetArtist()
    {
      return _artist;
    }

    public void SetArtist(string newArtist)
    {
      _artist = newArtist;
    }
    public static List<Album> GetAll()
    {
      return _albumList;
    }

    public void Save()
    {
      _albumList.Add(this);
    }
  }
}
