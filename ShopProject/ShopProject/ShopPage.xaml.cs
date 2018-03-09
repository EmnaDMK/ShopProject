using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShopProject
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShopPage : ContentPage
    {

        public List<ProductPair> ProdList, l1;
        public List<Product> tempdata2;
       


        //public List<MenuBarTitles> TitBar;
        public ShopPage()
        {
            InitializeComponent();
            GetProduct();
            ProductsList.ItemsSource = ProdList;
            //GetTitlesBar();
            //Titles.ItemsSource = TitBar;
          


            
        }


        //void GetTitlesBar()
        //{
        //    TitBar = new List<MenuBarTitles>
        //    {
        //        new MenuBarTitles{Title = "Shop"},
        //        new MenuBarTitles{Title = "Bags"},
        //        new MenuBarTitles{Title = "Accessoreis"},
        //        new MenuBarTitles{Title = "Bags"},
        //        new MenuBarTitles{Title = "Accessoreis"},
        //    new MenuBarTitles{Title = "Accessoreis"}

        //    };
        //}
        void GetProduct()
        {
            ProdList = new List<ProductPair>
                //{
                //    new ProductPair(
                //    new Product { Name="Gucci er" , ShortDescription="Almost New", Price="3000.00 SAR", ImageURL="icon.png"},
                //    new Product { Name="Gucci Hand Bag Light Brown" , ShortDescription="Almost New", Price="3000.00 SAR", ImageURL="icon.png"}),
                //    new ProductPair(
                //    new Product { Name="Gucci er" , ShortDescription="Almost New", Price="3000.00 SAR", ImageURL="icon.png"},
                //    new Product { Name="Gucci Hand Bag Light Brown" , ShortDescription="Almost New", Price="3000.00 SAR", ImageURL="icon.png"})

                //};
                {
                    new ProductPair(
                        new Product
                        {
                            Name = "BROWNIE HIP SUNGLASSES",
                            ShortDescription = "Almost New",
                            Price = "770.00 SAR",
                            ImageURL = "Pic1.png",
                            Category = "Accessoreis"
                        },
                        new Product
                        {
                            Name = "BROWNIE GLASSES HOLDER",
                            ShortDescription = "Acceptable",
                            Price = "2200 SAR",
                            ImageURL = "Pic2.png",
                            Category = "Accessoreis"
                        }),
                    new ProductPair(
                        new Product
                        {
                            Name = "HANDBAG NATURAL LEATHER",
                            ShortDescription = "New",
                            Price = "770.00 SAR",
                            ImageURL = "Pic3.png",
                            Category = "Bags"
                        },
                        new Product
                        {
                            Name = "CONCORD HANDWATCH",
                            ShortDescription = "Almost New",
                            Price = "3000.00 SAR",
                            ImageURL = "Pic4.png",
                            Category = "Accessoreis"
                        }),
                    new ProductPair(
                        new Product
                        {
                            Name = "EVENING SHOES HIGH HEAL",
                            ShortDescription = "Almost New",
                            Price = "2200 SAR",
                            ImageURL = "Pic5.png",
                            Category = "Shoes"
                        },
                        new Product
                        {
                            Name = "HANDBAG NATURAL LEATHER",
                            ShortDescription = "Almost New",
                            Price = "770.00 SAR",
                            ImageURL = "Pic6.png",
                            Category = "Bags"
                        })

                };

        }

     
        private void TapGestureRecognizer_OnTapped(object sender, EventArgs e)
        {
            if (sender.Equals(ShoesLabel))
            {
                ShoesLabel.TextColor = Color.White;
                ShoesLabel.FontSize = 20;
                getdatabycategory("Shoes");
                BagLabel.TextColor = Color.Gray;
                BagLabel.FontSize = 14;
                AccessoreisLabel.TextColor = Color.Gray;
                AccessoreisLabel.FontSize = 14;
            

        }
            else if (sender.Equals(BagLabel))
            {
                BagLabel.TextColor = Color.White;
                BagLabel.FontSize = 20;
                getdatabycategory("Bags");
                ShoesLabel.TextColor = Color.Gray;
                ShoesLabel.FontSize = 14;
                AccessoreisLabel.TextColor = Color.Gray;
                AccessoreisLabel.FontSize = 14;
            }
            else if (sender.Equals(AccessoreisLabel))
            {
                AccessoreisLabel.TextColor = Color.White;
                AccessoreisLabel.FontSize = 20;
                getdatabycategory("Accessoreis");
                ShoesLabel.TextColor = Color.Gray;
                ShoesLabel.FontSize = 14;
                BagLabel.TextColor = Color.Gray;
                BagLabel.FontSize = 14;
            }
        }




        void getdatabycategory(string category)
        {
            tempdata2 = new List<Product>();

            foreach (var prod in ProdList)
            {


                if (prod.Item1.Category.Equals(category))
                {
                    tempdata2.Add(prod.Item1);
                    prod.Item2.IsVisible = false;
                }

                if (prod.Item2.Category.Equals(category))
                {
                    tempdata2.Add(prod.Item2);
                    prod.Item1.IsVisible = false;
                }

            }
            l1 = new List<ProductPair>();

            for (int i = 0; i <= tempdata2.Count; i = i + 2)
            {
                if (i < tempdata2.Count - 1)
                {
                    ProductPair pp = new ProductPair(tempdata2[i], tempdata2[i + 1]);
                    l1.Add(pp);
                }
                else if (i == tempdata2.Count - 1)
                {
                    ProductPair pp = new ProductPair(tempdata2[i], null);
                    l1.Add(pp);
                }
            }

            ProductsList.ItemsSource = l1;
        }





        private void FrameTapGestureRecognizer_OnTapped(object sender, EventArgs e)

        {

            Frame senderFrame = (Frame)sender;

            Product Prod = new Product();

            //ItemPair bk = senderFrame.BindingContext as ItemPair;

            Prod = senderFrame.BindingContext as Product;

            DisplayAlert("Frame Tapped ", "Product Name : " + Prod.Name + " Product Category : " + Prod.Category,
                "Ok");

        }

        
        private void SearchBar_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            //thats all you need to make a search  

            if (string.IsNullOrEmpty(e.NewTextValue))
            {
                ProductsList.ItemsSource = ProdList;
            }

            else
            {

                tempdata2 = new List<Product>();

                foreach (var prod in ProdList)
                {


                    if (prod.Item1.Name.ToLower().Contains(e.NewTextValue.ToLower()))
                    {
                        tempdata2.Add(prod.Item1);
                        prod.Item2.IsVisible = false;
                    }

                    if (prod.Item2.Name.ToLower().Contains(e.NewTextValue.ToLower()))
                    {
                        tempdata2.Add(prod.Item2);
                        prod.Item1.IsVisible = false;
                    }

                }
                l1 = new List<ProductPair>();
                for (int i = 0; i <= tempdata2.Count; i = i + 2)
                {
                    if (i < tempdata2.Count - 1)
                    {
                        ProductPair pp = new ProductPair(tempdata2[i], tempdata2[i + 1]);
                        l1.Add(pp);
                    }
                    else if (i == tempdata2.Count - 1)
                    {
                        ProductPair pp = new ProductPair(tempdata2[i], null);
                        l1.Add(pp);
                    }
                }

                ProductsList.ItemsSource = l1;

            }

        }



    }





}