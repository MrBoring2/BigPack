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
        private byte[] image;
        private double? amountInStock;
        private string unit;
        private int amountInPack;
        private int minCount;
        private double costForOne;
        private Visibility btnVisibility;
        private string search;
        private MaterialType selectedType;
        private Supplier selectedSupplier;
        private ObservableCollection<Supplier> selectedSuppliersForMaterial;


        public MaterialWindow()
        {
            _context = new TestDemContext();
            isEdit = false;
            InitializeComponent();
        }
        public MaterialWindow(Material material) : base()
        {
            this.Material = material;
            isEdit = true;
            Name = material.Title;
            Image = material.GetImage;
            AmountInPack = material.CountInPack;
            AmountInStock = material.CountInStock;
            CostForOne = (double)material.Cost;
            Unit = material.Unit;
            MinCount = (int)material.MinCount;
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
        public List<Supplier> Suppliers { get; set; }
        public MaterialType Selectedtype { get => selectedType; set { selectedType = value; OnPropertyChanged(); } }
        public Supplier SelectedSupplier { get => selectedSupplier; set { selectedSupplier = value; OnPropertyChanged(); } }
        public ObservableCollection<Supplier> SelectedSuppliersForMaterial { get => selectedSuppliersForMaterial; set { selectedSuppliersForMaterial = value; OnPropertyChanged(); } }
        public string Search { get => search; set { search = value; OnPropertyChanged(); } }
        public List<MaterialType> Types { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
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

            if (isEdit)
            {
                
                var material = _context.Material.Find(Material.ID);
                if(material != null)
                {
                    _context.Entry(material).CurrentValues.SetValues(Material);
                }
            }
        }
    }
}
