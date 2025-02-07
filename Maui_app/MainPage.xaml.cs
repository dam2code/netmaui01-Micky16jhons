using System;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Storage; // Necesario para usar Preferences

namespace Maui_app
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            // Cargar la nota guardada previamente si existe
            if (Preferences.ContainsKey("SavedNote"))
            {
                editor.Text = Preferences.Get("SavedNote", string.Empty);
            }
        }

        // Método para guardar la nota
        private void OnSaveButtonClicked(object sender, EventArgs e)
        {
            if (editor != null)  // Asegurar que el Editor no es nulo
            {
                string note = editor.Text;
                if (!string.IsNullOrWhiteSpace(note))
                {
                    Preferences.Set("SavedNote", note);
                    DisplayAlert("Success", "Note saved successfully!", "OK");
                }
                else
                {
                    DisplayAlert("Error", "Cannot save an empty note!", "OK");
                }
            }
        }

        // Método para borrar la nota
        private void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            if (editor != null)  // Asegurar que el Editor no es nulo
            {
                Preferences.Remove("SavedNote");
                editor.Text = string.Empty;
                DisplayAlert("Deleted", "Note deleted successfully!", "OK");
            }
        }
    }
}
