using CommunityToolkit.Mvvm.ComponentModel;
using ShopList.Gui.Models;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
//using System.ComponentModel;
//using System.Windows.Input;

namespace ShopList.Gui.ViewsModels
{
    public partial ShopListViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _nombreDelArticulo= string.Empty
        [ObservableProperty]



        private int _CantidadAComprar = 1;

        //public event PropertyChangedEventHandler? PropertyChanged;

        public ObservableCollection<Item> Items { get; }

        //public string NombreDelArticulo
        //{
        //    get => _nombreDelArticulo;
        //    set
        //    {
        //        if (_nombreDelArticulo != value)
        //        {
        //            _nombreDelArticulo = value;
        //            OnPropertyChanged(nameof(NombreDelArticulo));
        //        }
        //    }
        //}

        //public int CantidadAComprar
        //{
        //    get => _CantidadAComprar;
        //    set
        //    {
        //        if (_CantidadAComprar != value)
        //        {
        //            _CantidadAComprar = value;
        //            OnPropertyChanged(nameof(CantidadAComprar));
        //        }
        //    }
        //}

        //public ICommand AgregarShopListItemCommand { 
        //    get; private set; 
        //}

        //public ShopListViewModel()
        //{
        //    Items = new ObservableCollection<Item>();
        //    CargarDatos();
        //    AgregarShopListItemCommand = new Command(AgregarShoplistItem);
        //}

        private Random generador = new Random();

        public void AgregarShoplistItem()
        {
            if (string.IsNullOrEmpty(_nombreDelArticulo)
                || CantidadAComprar <= 0)
            {
                return;
            }

            var item = new Item
            {
                Id = generador.Next(),
                Nombre = NombreDelArticulo,
                Cantidad = CantidadAComprar,
                Comprado = false
            };

            Items.Add(item);
            NombreDelArticulo = string.Empty;
            CantidadAComprar = 1;

        }

        public void EliminarShopListItem()
        {

        }


        private void CargarDatos()
        {
            Items.Add(new Item()
            {
                Id = 1,
                Nombre = "Leche",
                Cantidad = 2,
                Comprado = false
            });

            Items.Add(new Item()
            {
                Id = 2,
                Nombre = "Pan de caja",
                Cantidad = 1,
                Comprado = true
            });

            Items.Add(new Item()
            {
                Id = 3,
                Nombre = "Jamón",
                Cantidad = 500,
                Comprado = false
            });
        }


        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(
                this, new PropertyChangedEventArgs(propertyName)
            );
        }
    }
}