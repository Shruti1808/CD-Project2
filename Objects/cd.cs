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
    private static List<Song> _songs = new List<Song>{};

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
    public int GetId()
    {
      return _id;
    }
    public List<Song> GetSongs()
    {
      return _songs;
    }
    public static List<Album> GetAll()
    {
      return _albumList;
    }

    public void Save()
    {
      _albumList.Add(this);
    }
    public static Album Find(int searchId)
    {
      return _albumList[searchId-1];
    }
    public void AddSong(Song song)
    {
      _songs.Add(song);
    }

  }
}
