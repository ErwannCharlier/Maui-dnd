using MauiDnd.Models;
using System;
using System.Threading.Tasks;

namespace MauiDnd.Views.CrurdCharacter
{
    public partial class EditCharacter : ContentPage
    {
        public Character Character { get; set; }

        public EditCharacter(Character character)
        {
            InitializeComponent();
            Character = character;
            BindingContext = this;
            PopulateClassPickerAsync(); 
        }
        private async Task PopulateClassPickerAsync()
        {
            List<Class> classes = await GetClasses();
            foreach (Class c in classes)
            {
                ClassPicker.Items.Add(c.Name);
            }
        }
        private async void SaveChanges_Clicked(object sender, EventArgs e)
        {
            DndClient dndClient = DndClient.Client();
            await dndClient.UpdateCharacterAsync(Character);
            await DisplayAlert("Success", "Changes saved successfully", "OK");
            await Navigation.PushAsync(new Personnage());
        }
        private async Task<List<Class>> GetClasses()
        {
            DndClient dndClient = DndClient.Client();
            return await dndClient.GetClassAsync();
        }
        private async void Inventory_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MauiDnd.Views.CrurdCharacter.Inventory(Character.Id));

        }
        private async void ClassPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedClassName = (string)ClassPicker.SelectedItem;
            if (selectedClassName != null)
            {
                DndClient dndClient = DndClient.Client();
                Class newClass = await dndClient.GetClassByNameAsync(selectedClassName);
                if (newClass != null)
                {
                    Character.Class = newClass;
                    Character.ClassId = newClass.Id;
                }
            }
        }
    }
}
