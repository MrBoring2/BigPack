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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using TestDemPodgotovka.Data;
using TestDemPodgotovka.Models;

namespace TestDemPodgotovka.Views
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MaterialsListWindow : Window, INotifyPropertyChanged
    {
        private readonly TestDemContext _context;
        private string displayedCountOfMaterials;
        private readonly int itemsPerPage;
        private string search;
        private int currentPage; 
            private int maxPage;
        private Sort selectedSort;
        private Visibility btnVisibility;
        private string selectedFilter;
        private Material selectedMaterial;
        private ObservableCollection<int> pages;
        private ObservableCollection<Sort> sortParams;
        private ObservableCollection<string> filterParams;
        private ObservableCollection<Material> displayedMaterials;
        public MaterialsListWindow()
        {
            InitializeComponent();
            _context = new TestDemContext();
            itemsPerPage = 15;
            currentPage = 1;
            search = string.Empty;
            LoadData();
            LoadPages();
            BtnVisibility = Visibility.Collapsed;
            DataContext = this;
        }

        public string Search { get { return search; } set { search = value; OnPropertyChanged(); RefreshMaterials(); } }
        public int CurrentPage { get { return currentPage; } set { currentPage = value > 0 ? value : 1; OnPropertyChanged(); RefreshMaterials(); } }
        public string DisplayedCountOfMaterials { get => displayedCountOfMaterials; set { displayedCountOfMaterials = value; OnPropertyChanged(); } }
        public Sort SelectedSort { get { return selectedSort; } set { selectedSort = value; OnPropertyChanged(); RefreshMaterials(); } }
        public Visibility BtnVisibility { get => btnVisibility; set { btnVisibility = value; OnPropertyChanged(); } }
        public string SelectedFilter { get { return selectedFilter; } set { selectedFilter = value; OnPropertyChanged(); RefreshMaterials(); } }
        public ObservableCollection<int> Pages { get { return pages; } set { pages = value; OnPropertyChanged(); } }
        public ObservableCollection<int> DisplayedPages => new ObservableCollection<int>(Pages.Take(maxPage > 0 ? maxPage : 1));
        public ObservableCollection<Sort> SortParams { get { return sortParams; } set { sortParams = value; OnPropertyChanged(); } }
        public ObservableCollection<string> FilterParams { get { return filterParams; } set { filterParams = value; OnPropertyChanged(); } }
        public ObservableCollection<Material> DisplayedMaterials { get { return displayedMaterials; } set { displayedMaterials = value; OnPropertyChanged(); } }
        public Material SelectedMaterial { get => selectedMaterial; set { selectedMaterial = value; OnPropertyChanged(); } }
        public List<Material> Materials { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        private void LoadData()
        {
            LoadFilterParams();
            LoadSortParams();
            LoadMaterials();
            OnPropertyChanged(nameof(SelectedSort));
            OnPropertyChanged(nameof(SelectedFilter));
            OnPropertyChanged(nameof(Search));
            OnPropertyChanged(nameof(CurrentPage));
        }
        private void LoadMaterials()
        {

            Materials = _context.Material.ToList();
            RefreshMaterials();

        }
        private void LoadFilterParams()
        {
            using (var db = new TestDemContext())
            {
                var types = db.MaterialType.ToList();
                FilterParams = new ObservableCollection<string>();
                FilterParams.Add("Все");
                foreach (var item in types)
                {
                    FilterParams.Add(item.Title);
                }
                selectedFilter = FilterParams.FirstOrDefault();
            }
        }
        private void LoadSortParams()
        {
            SortParams = new ObservableCollection<Sort>
            {
                new Sort("Наименование по возрастанию", "Title", true),
                new Sort("Наименование по убыванию", "Title", false),
                new Sort("Остаток на складе по возрастанию", "CountInStock", true),
                new Sort("Остаток на складе по убыванию", "CountInStock", false),
                new Sort("Стоимость по возрастанию", "Cost", true),
                new Sort("Стоимость по убыванию", "Cost", false)
            };
            selectedSort = SortParams.FirstOrDefault();
        }
        private void LoadPages()
        {
            Pages = new ObservableCollection<int>();
            foreach (int index in Enumerable.Range(1, maxPage))
            {
                Pages.Add(index);
            }
            CurrentPage = Pages.FirstOrDefault();
        }
        private void RefreshMaterials()
        {
            var materials = SortMaterials(Materials);
            //var materials = Materials;
            materials = FilterMaterals(materials);
            DisplayedCountOfMaterials = $"{materials.Count} из {Materials.Count}";

            if (maxPage != (int)Math.Ceiling((float)materials.Count / (float)itemsPerPage))
            {
                maxPage = (int)Math.Ceiling((float)materials.Count / (float)itemsPerPage);
                OnPropertyChanged(nameof(DisplayedPages));
            }
            DisplayedMaterials = new ObservableCollection<Material>(materials.Skip((CurrentPage - 1) * itemsPerPage).Take(itemsPerPage).ToList());

            if (CurrentPage > maxPage)
            {
                currentPage = maxPage;
                OnPropertyChanged(nameof(CurrentPage));
            }

        }

        private List<Material> SortMaterials(List<Material> materials)
        {
            if (SelectedSort.IsAscending)
            {
                return materials.OrderBy(p => p.GetProperty(SelectedSort.Property)).ToList();
            }
            else return materials.OrderByDescending(p => p.GetProperty(SelectedSort.Property)).ToList();
        }
        private List<Material> FilterMaterals(List<Material> materials)
        {
            return materials.Where(
                p => p.Title.ToLower()
                .Contains(Search.ToLower()))
                .Where(p => SelectedFilter != "Все" ? p.MaterialType.Title.Equals(SelectedFilter) : p.MaterialType.Title.Contains(""))
                .ToList();
        }

        private int MaxPage()
        {
            var materials = FilterMaterals(Materials);
           
            return (int)Math.Ceiling((float)materials.Count / (float)itemsPerPage);
        }

        private void paginator_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentPage > 0)
            {
                CurrentPage--;
            }
        }

        private void forward_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentPage + 1 <= maxPage)
            {
                CurrentPage++;
            }
        }


        private void minCountChange_Click(object sender, RoutedEventArgs e)
        {
            var max = materialsList.SelectedItems.Cast<Material>().Max(p => p.MinCount);
            var changeWindow = new MinCountChangeWindow(max);
            if (changeWindow.ShowDialog() == true)
            {
                foreach (var item in materialsList.SelectedItems.Cast<Material>())
                {
                    item.MinCount = changeWindow.Count;
                }
                using (var db = new TestDemContext())
                {
                    db.SaveChanges();
                }
                //RefreshMaterials();
            }
        }

        private void materialsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (materialsList.SelectedItems.Count > 1)
            {
                BtnVisibility = Visibility.Visible;
            }
            else
            {
                BtnVisibility = Visibility.Collapsed;
            }
        }

        private void addMaterial_Click(object sender, RoutedEventArgs e)
        {
            var materialWindow = new MaterialWindow();
            if (materialWindow.ShowDialog() == true)
            {
                LoadMaterials();
                RefreshMaterials();
            }
        }

        private void ListViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var materialWindow = new MaterialWindow(SelectedMaterial);
            if (materialWindow.ShowDialog() == true)
            {
                LoadMaterials();
                RefreshMaterials();
            }
        }


        //private void Import()
        //{
        //    using (var db = new TestDemContext())
        //    {
        //        var images = Directory.GetFiles(@"C:\Users\MrBoring\Desktop\КОД 1.6._ВАРИАНТ_6\Сессия 1\materials");
        //        foreach (var item in db.Material)
        //        {
        //            if (item.Image != null)
        //            {
        //                var image = images.FirstOrDefault(p => p.Contains(item.Image));
        //                if (image != null)
        //                {
        //                    item.ImageF = File.ReadAllBytes(image);
        //                }
        //            }
        //        }
        //        db.SaveChanges();
        //    }
        //}
    }
}