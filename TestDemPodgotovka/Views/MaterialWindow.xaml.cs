using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TestDemPodgotovka.Data;

namespace TestDemPodgotovka.Views
{
    /// <summary>
    /// Логика взаимодействия для MaterialWindow.xaml
    /// </summary>
    public partial class MaterialWindow : Window, INotifyPropertyChanged
    {
        private readonly TestDemContext _context;
        private bool isEdit;
        private string name;
        private string search;
        private byte[] image;
        private double? amountInStock;
        private string unit;
        private int amountInPack;
        private int minCount;
        private double costForOne;
        private Visibility btnVisibility;
        private MaterialType selectedType;
        private Supplier selectedSupplier;
        private ObservableCollection<Supplier> suppliers;
        private ObservableCollection<Supplier> selectedSuppliersForMaterial;


        public MaterialWindow()
        {
            InitializeComponent();
            Material = new Material();
            delete.Visibility = Visibility.Collapsed;
            _context = new TestDemContext();
            isEdit = false;
            DataContext = this;
            Title = "Добавление";
            SelectedSuppliersForMaterial = new ObservableCollection<Supplier>();
            Search = string.Empty;
            LoadTypes();
            LoadSuppliers();
        }



        public MaterialWindow(Material material) : this()
        {
            delete.Visibility = Visibility.Visible;

            this.Material = material;
            isEdit = true;
            MaterialName = material.Title;
            Title = $"Редактирование: {material.Title}";
            Image = material.GetImage;
            AmountInPack = material.CountInPack;
            AmountInStock = material.CountInStock;
            CostForOne = (double)material.Cost;
            Unit = material.Unit;
            MinCount = (int)material.MinCount;
            SelectedSuppliersForMaterial = new ObservableCollection<Supplier>(material.Supplier);
        }
        public int MinCount { get => minCount; set { minCount = value; OnPropertyChanged(); } }
        public string Unit { get => unit; set { unit = value; OnPropertyChanged(); } }
        public string MaterialName { get => name; set { name = value; OnPropertyChanged(); } }
        public byte[] Image { get => image; set { image = value; OnPropertyChanged(); } }
        public double? AmountInStock { get => amountInStock; set { amountInStock = value; OnPropertyChanged(); } }
        public int AmountInPack { get => amountInPack; set { amountInPack = value; OnPropertyChanged(); } }
        public double CostForOne { get => costForOne; set { costForOne = value; OnPropertyChanged(); } }
        public Visibility BtnVisibility { get => btnVisibility; set { btnVisibility = value; OnPropertyChanged(); } }
        public Material Material { get; set; }
        public ObservableCollection<Supplier> Suppliers
        {
            get => suppliers; set { suppliers = value; OnPropertyChanged(); }
        }
        public MaterialType SelectedType { get => selectedType; set { selectedType = value; OnPropertyChanged(); } }
        public Supplier SelectedSupplier { get => selectedSupplier; set { selectedSupplier = value; OnPropertyChanged(); } }
        public ObservableCollection<Supplier> SelectedSuppliersForMaterial { get => selectedSuppliersForMaterial; set { selectedSuppliersForMaterial = value; OnPropertyChanged(); } }
        public string Search { get => search; set { search = value; OnPropertyChanged(); OnPropertyChanged(nameof(DisplayedSuppliers)); } }

        public List<Supplier> DisplayedSuppliers => Suppliers.Where(p => p.Title.ToLower().Contains(Search.ToLower())).ToList();
        public List<MaterialType> Types { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        private void LoadSuppliers()
        {
            Suppliers = new ObservableCollection<Supplier>(_context.Supplier);
        }

        private void LoadTypes()
        {
            Types = new List<MaterialType>(_context.MaterialType);
            SelectedType = Types.FirstOrDefault();
        }
        private void loadImage_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                Image = File.ReadAllBytes(openFileDialog.FileName);
            }
        }
        private void removeFromList_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedSupplier != null)
            {
                SelectedSuppliersForMaterial.Remove(SelectedSupplier);
            }
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            Material.Title = MaterialName;
            Material.Cost = Convert.ToDecimal(CostForOne);
            Material.CountInPack = AmountInPack;
            Material.CountInStock = AmountInStock;
            Material.Image = Image;
            Material.MinCount = MinCount;
            Material.Unit = Unit;
            Material.MinCount = MinCount;
            Material.Supplier = SelectedSuppliersForMaterial;
            if (isEdit)
            {
                try
                {
                    var material = _context.Material.Find(Material.ID);
                    if (material != null)
                    {
                        _context.Entry(material).CurrentValues.SetValues(Material);
                        _context.SaveChanges();
                        this.DialogResult = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                if (Validate())
                {
                    var material = new Material
                    {
                        Title = MaterialName,
                        Unit = Unit,
                        Image = Image,
                        MaterialTypeID = SelectedType.ID,
                        Description = "",
                        Cost = Convert.ToDecimal(CostForOne),
                        CountInPack = AmountInPack,
                        CountInStock = AmountInStock,
                        MinCount = MinCount
                    };
                    material.Supplier = new List<Supplier>();
                    foreach (var item in SelectedSuppliersForMaterial)
                    {
                        material.Supplier.Add(item);
                    }
                    _context.Material.Add(material);
                    _context.SaveChanges();
                    this.DialogResult = true;
                }
            }
        }
        private bool Validate()
        {
            return true;
        }

        private void suppliers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var id = ((sender as ComboBox).SelectedItem as Supplier).ID;
            if (SelectedSuppliersForMaterial.FirstOrDefault(p => p.ID == id) == null)
            {
                SelectedSuppliersForMaterial.Add((sender as ComboBox).SelectedItem as Supplier);
            }
            else
            {
                MessageBox.Show("Данный поставщике уже есть в списке!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            _context.Material.Remove(_context.Material.FirstOrDefault(p=>p.ID == Material.ID));
            _context.SaveChanges();
            DialogResult = true;
        }
    }
}
