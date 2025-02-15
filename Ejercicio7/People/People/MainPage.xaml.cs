﻿using People.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace People;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    public async Task OnNewButtonClicked(object sender, EventArgs args)
    {
        statusMessage.Text = "Agregando persona...";

        await App.PersonRepo.AddNewPerson(newPerson.Text);
        statusMessage.Text = App.PersonRepo.StatusMessage;
    }

    public async Task OnGetButtonClicked(object sender, EventArgs args)
    {
        statusMessage.Text = "Obteniendo lista...";

        List<Person> people = await App.PersonRepo.GetAllPeople();
        peopleList.ItemsSource = people;
        statusMessage.Text = "Datos cargados correctamente.";
    }
}
