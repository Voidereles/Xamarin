using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Fuel_monitor
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RefuelPage : ContentPage
    {
        SQLiteConnection database;
        private string databasePath;
        private Models.Refueling_data refuelTable = new Models.Refueling_data();
        //Strona z dodawaniem tankowania
        public RefuelPage()
        {
            InitializeComponent();

            databasePath = DependencyService.Get<ISQLiteDb>().GetLocalFilePath("BazaSQLite.db3");

            database = new SQLiteConnection(databasePath);
            database.CreateTable<Models.Refueling_data>();
        }

        public void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                refuelTable.Przebieg = Convert.ToInt32(Entry_Przebieg.Text);
                refuelTable.Zatankowano = float.Parse(Entry_Zatankowano.Text);
                refuelTable.Cena_litra = float.Parse(Entry_CenaLitra.Text);
                refuelTable.Koszt = float.Parse(Entry_Koszt.Text);
                refuelTable.Data_tankowania = Convert.ToDateTime(Entry_DataTankowania.Date);

                new Models.Refueling_data { Przebieg = refuelTable.Przebieg, Zatankowano = refuelTable.Zatankowano, Cena_litra = refuelTable.Cena_litra, Koszt = refuelTable.Koszt, Data_tankowania = refuelTable.Data_tankowania };

                database.Insert(refuelTable);
            }
            catch
            {
                DisplayAlert ("Alert", "Wprowadź dane", "OK");

            }
            
        }
    }
}