using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;
using System.IO;
using Xamarin.Forms.Xaml;

using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Fuel_monitor
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RefuelingListPage : ContentPage
       

    {
        SQLiteConnection database;
        private string databasePath;


        public RefuelingListPage()
        {
            InitializeComponent();

            databasePath = DependencyService.Get<ISQLiteDb>().GetLocalFilePath("BazaSQLite.db3");

            database = new SQLiteConnection(databasePath);
            database.CreateTable<Models.Refueling_data>();


        }

        private ObservableCollection<Models.Refueling_data> _refuels;

        protected override void OnAppearing()
        {
             
            database.CreateTable<Models.Refueling_data>();

            var refuels = database.Table<Models.Refueling_data>().ToList();
            _refuels = new ObservableCollection<Models.Refueling_data>(refuels);
            refuelsListView.ItemsSource = _refuels;

            base.OnAppearing();
        }


        //protected override void OnAppearing()
        //{
        //    var refuels = database.Table<Models.Refueling_data>().ToList;
        //    _refuels = new ObservableCollection<RefuelingListPage>(refuels);
        //    refuelsListView.ItemSource = _refuels;

        //    base.OnAppearing();
        //}
        //await _connection.CreateTableAsync<Recipe>();

        //var recipes = await _connection.Table<Recipe>().ToListAsync();
        //_recipes = new ObservableCollection<Recipe>(recipes);
        //recipesListView.ItemsSource = _recipes;

        //You'll need to define the ItemsSource of your listview first by binding it to the sqlite data, 
        //preferably stored in a ObservableCollection of type your model. Then put the BindingContext = MyViewModel(); 
        //and then call your ObservableCollection through xaml with


        //listView.ItemsSource = new List<Models.Refueling_data>();
        //{
        //    new Models.Refueling_data { Przebieg = 259966, Zatankowano = 22, Cena_litra = 2, Koszt = 44, Data_tankowania = new DateTime(2019, 6, 13) },
        //    new Models.Refueling_data { Przebieg = 359966, Zatankowano = 22, Cena_litra = 2, Koszt = 44, Data_tankowania = new DateTime(2019, 6, 13) },
        //    new Models.Refueling_data { Przebieg = 459966, Zatankowano = 22, Cena_litra = 2, Koszt = 44, Data_tankowania = new DateTime(2019, 6, 13) },
        //    new Models.Refueling_data { Przebieg = 559966, Zatankowano = 22, Cena_litra = 2, Koszt = 44, Data_tankowania = new DateTime(2019, 6, 13) }                
        //};
    }

   
	
}