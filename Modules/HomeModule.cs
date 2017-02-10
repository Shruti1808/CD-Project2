using Nancy;
using System.Collections.Generic;
using CDProject.Objects;

namespace CDProject
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => View["index.cshtml"];
      Get["/cd_form"] = _ => View["Add_Cd.cshtml"];
      Get["/album/new"] = _ => {
        return View["Add_Cd.cshtml"];
      };

      Post["/view_Cd"] = _ => {
        Album newAlbum = new Album(Request.Form["add-cd"], Request.Form["add-artist"]);
        newAlbum.Save();
        return View["view_Cd.cshtml", Album.GetAll()];
      };
      Get["/albums/{id}"] = parameters => {
        Dictionary<string, object> model = new Dictionary<string, object>();
        var selectedAlbum = Album.Find(parameters.id);
        var albumSongs = selectedAlbum.GetSongs();
        model.Add("album", selectedAlbum);
        model.Add("songs", albumSongs);
        return View["album.cshtml", model];
      };
      Get["/view_Cd"] = _ => {
          List<Album> allAlbums = Album.GetAll();
          return View["view_Cd.cshtml", allAlbums];
      };
      Get["/albums/{id}/songs/new"] = parameters => {
        Dictionary<string, object> model = new Dictionary<string, object>();
        Album selectedAlbum = Album.Find(parameters.id);
        List<Song>  allSongs = selectedAlbum.GetSongs();
        model.Add("album", selectedAlbum);
        model.Add("songs", allSongs);
        return View["album_songs_form.cshtml", model];
      };
      Post["/songs"] = _ => {
        Dictionary<string, object> model = new Dictionary<string, object>();
        Album selectedAlbum = Album.Find(Request.Form["category-id"]);
        List<Song> albumSongs = selectedAlbum.GetSongs();
        string taskDescription = Request.Form["task-description"];
        Song newSong = new Song(taskDescription);
        albumSongs.Add(newSong);
        model.Add("songs", albumSongs);
        model.Add("category", selectedAlbum);
        return View["category.cshtml", model];
      };


    }
  }
}
