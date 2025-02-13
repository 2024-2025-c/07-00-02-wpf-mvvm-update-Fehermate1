using CommunityToolkit.Mvvm.ComponentModel;
using Kreta.Desktop.ViewModels.Base;
using Kreta.HttpService.Services;
using Kreta.Shared.Models.Entites;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Kreta.Desktop.ViewModels.SchoolSubjects
{
    public partial class SubjectsManagmentViewModel : BaseViewModel
    {
        private readonly ISubjectHttpService _httpService;


        //2. A lekért adatok ebben az adatstruktúrában jelennek meg majd a view-n
        [ObservableProperty]
        private ObservableCollection<Subject> _subjects = new ObservableCollection<Subject>();

        //2.b adatstruktúra a kiválasztott tantárgynak
        [ObservableProperty]
        private Subject _selectedSubject = new Subject();

        //alapértelmezett konstruktornak mindig léteznie kell, ebben az állapotban tesztelhető már a kód
        public SubjectsManagmentViewModel()
        {

        }
        //1.b Konstruktorban injektáljuk az ISubjectHttpservicet
        public SubjectsManagmentViewModel(ISubjectHttpService? httpService)
        {
            _httpService = httpService ?? throw new ArgumentNullException(nameof(httpService));
        }

        //1. tantárgyak adatainak lekérése a backendről (VIZSGAREMEK!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!)
        //1.a Adatok menüpont kiválasztására jelenjenek meg: InicializeAsync();

        //Felülírjuk az InitializeAsync metódust
        public override async Task InitializeAsync()
        {
            await UpdateViewAsync();
            await base.InitializeAsync();
        }

        private async Task UpdateViewAsync()
        {
            //1.d HttpService-en keresztül backend hívás
            List<Subject> subjects = await _httpService.GetAllAsync();
            //2.a A megérkezett adatokkal újra létrehozzuk a Subjects ObservableCollection
            Subjects = new ObservableCollection<Subject>(subjects);
        }
    }
}
