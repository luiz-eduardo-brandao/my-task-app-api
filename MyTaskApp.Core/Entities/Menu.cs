using System.Text.Json.Serialization;

namespace MyTaskApp.Core.Entities
{
    public class Menu
    {
        public Menu(int id, int? idFatherMenu, string title, string? route, string icon)
        {
            Id = id;
            IdFatherMenu = idFatherMenu;
            Title = title;
            Route = route;
            Icon = icon;

            SubMenu = new List<Menu>();
        }

        public int Id { get; set; }
        public int? IdFatherMenu { get; set; }
        public string Title { get; set; }
        public string? Route { get; set; }
        public string Icon { get; set; }

        [JsonIgnore]
        public Menu FatherMenu { get; set; }
        public List<Menu> SubMenu { get; set; }
    }
}
