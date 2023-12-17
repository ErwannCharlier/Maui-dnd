namespace MauiDnd.Views;

public partial class Menu : ContentPage
{
   
    
        public Menu()
        {
            InitializeComponent();
        }

        private void SeConnecter_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Login());
            //DisplayAlert("Message", "Connexion", "OK");
        }

        private void CreerCompte_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CreatLogin());
        }
    
}

