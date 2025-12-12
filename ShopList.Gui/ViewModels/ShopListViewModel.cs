using SQLite;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ShopList.Gui.Models;
using ShopList.Gui.Persistence.Configuration;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ShopList.Gui.Persistence;

namespace ShopList.Gui.ViewModels
{
    public partial class ShopListViewModel : ObservableObject
    {

        [ObservableProperty]
        private string _nombreDelArticulo = string.Empty;
        [ObservableProperty]
        private int _cantidadAComprar;
        [ObservableProperty]
        private Item? _origenSeleccionado = null;

        [ObservableProperty]
        private ObservableCollection<Item>? _items = null;
        private ShopListDatabase? _database = null;




        public ShopListViewModel()
        {
            _database = new ShopListDatabase();
            Items = new ObservableCollection<Item>();
            // CargarDatos();
            GetItems();
            if (Items.Count > 0)
            {
                OrigenSeleccionado = Items[0];
            }

            else
            {
                OrigenSeleccionado = null!;

            }

            //AgregarShopListItemCommand = new Command(AgregarShopListItem);
        }
        [RelayCommand]

        public async void AgregarShopListItem()
        {
            if (string.IsNullOrEmpty(NombreDelArticulo) || CantidadAComprar <= 0)
            {
                return;
            }

            //Random generador = new Random();
            var item = new Item
            {
                // Id = generador.Next(),  
                Nombre = NombreDelArticulo,
                Cantidad = CantidadAComprar,
                Comprado = false,
            };
            await
                _database.SaveItemAsync(item);
            //Items.Add(item);
            GetItems();
            OrigenSeleccionado = item;
            NombreDelArticulo = String.Empty;
            CantidadAComprar = 1;
        }

        [RelayCommand]

        public void EliminarShopListItem()
        {
            if (OrigenSeleccionado == null) { return; }
            Item? nuevoSeleccionado;
            int indice = Items.IndexOf(OrigenSeleccionado);
            if (indice < Items.Count - 1)
            {

                nuevoSeleccionado = Items[indice + 1];
            }
            else
            {
                if (Items.Count > 1)
                {

                    nuevoSeleccionado = Items[Items.Count - 2];

                }
                else
                {
                    nuevoSeleccionado = null;
                }


            }
            Items.Remove(OrigenSeleccionado);
            OrigenSeleccionado = nuevoSeleccionado;


        }

        private async void GetItems()
        {
            IEnumerable<Item> itemsFromDb = await _database.GetAllItemsAsync();
            Items = new ObservableCollection<Item>(itemsFromDb);

        }




        private void CargarDatos()
        {
            Items.Add(new Item()
            {
                Id = 1,
                Nombre = "Leche",
                Cantidad = 2,
                Comprado = false,
            });

            Items.Add(new Item()
            {
                Id = 2,
                Nombre = "Huevos",
                Cantidad = 2,
                Comprado = false,

            });

            Items.Add(new Item()
            {
                Id = 3,
                Nombre = "Jamon",
                Cantidad = 500,
                Comprado = false,

            });
        }

        //private void OnPropertyChanged(string propertyName)
        //{
        //   PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        //}


    }
}