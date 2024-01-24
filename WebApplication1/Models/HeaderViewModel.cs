namespace WebApplication1.Models
{
    public class HeaderViewModel
    {
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public List<MenuOptionViewModel>  Menus { get; set; }
    }
    public class MenuOptionViewModel
    {
        public string DisplayText { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
    }
}
