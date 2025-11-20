using ShopList.Gui.Models;
using System.Collections.ObjectModel;


namespace ShopList.Gui.ViewModels
{
    internal class ShopListViewModel
    {
        public ObservableCollection<Item> Items { get; }

        public ShopListViewModel()
        {
            Items = new ObservableCollection<Item>();
            CargarDatos();
        }

        public void CargarDatos()
        {
            Items.Add(new Item()
            {
                Id = 1,
                Nombre = "Leche",
                Cantidad = 2
            });

            Items.Add(new Item()
            {
                Id = 2,
                Nombre = "Pan de caja",
                Cantidad = 1
            });

            Items.Add(new Item()
            {
                Id = 3,
                Nombre = "Jamón",
                Cantidad = 500
            });

        }
    }
}
