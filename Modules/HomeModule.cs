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
      Post["/view_Cd"] = _ => {
        Album newAlbum = new Album(Request.Form["add-cd"], Request.Form["add-artist"]);
        newAlbum.Save();
        return View["view_Cd.cshtml", Album.GetAll()];
      };
      Get["/view_Cd"] = _ => {
          List<Album> allAlbums = Album.GetAll();
          return View["view_Cd.cshtml", allAlbums];
};
    }
  }
}
