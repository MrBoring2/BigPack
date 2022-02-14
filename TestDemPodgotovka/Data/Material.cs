namespace TestDemPodgotovka.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.IO;
    using System.Linq;
    using System.Windows.Media.Imaging;

    [Table("Material")]
    public partial class Material : BaseEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Material()
        {
            MaterialCountHistory = new HashSet<MaterialCountHistory>();
            ProductMaterial = new HashSet<ProductMaterial>();
            Supplier = new HashSet<Supplier>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        public int CountInPack { get; set; }

        [Required]
        [StringLength(10)]
        public string Unit { get; set; }

        public double? CountInStock { get; set; }

        public double MinCount { get; set; }

        public string Description { get; set; }

        public decimal Cost { get; set; }

        [Column(TypeName = "image")]
        public byte[] Image { get; set; }

        public int MaterialTypeID { get; set; }


        public virtual MaterialType MaterialType { get; set; }

        public byte[] GetImage
        {
            get
            {
                if (Image == null)
                {
                    var bitmap = new BitmapImage(new Uri("pack://application:,,,/Resources/Images/picture.png", UriKind.RelativeOrAbsolute));
                    using (var ms = new MemoryStream())
                    {
                        PngBitmapEncoder ecoder = new PngBitmapEncoder();
                        ecoder.Frames.Add(BitmapFrame.Create(bitmap));
                        ecoder.Save(ms);
                        return ms.ToArray();
                    }
                }
                else
                {
                    return Image;
                }
            }
        }

        public string SuppliersAsString
        {
            get
            {
                string suppliers = "Поставщики: ";

                if (Supplier.Count > 0)
                {
                    foreach (var item in Supplier)
                    {
                        suppliers += item.Title;
                        if (item != Supplier.LastOrDefault())
                        {
                            suppliers += ", ";
                        }
                    }
                }
                else
                {
                    suppliers += "отсутствуют";
                }
                return suppliers;
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MaterialCountHistory> MaterialCountHistory { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductMaterial> ProductMaterial { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Supplier> Supplier { get; set; }
    }
}
