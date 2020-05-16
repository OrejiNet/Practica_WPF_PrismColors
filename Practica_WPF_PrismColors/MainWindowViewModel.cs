using MahApps.Metro;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Practica_WPF_PrismColors
{
   public  class MainWindowViewModel : BindableBase
    {
        public MainWindowViewModel()
        {
            ApplyThemeCommand = new DelegateCommand(ApplyTheme);
            ApplyColorCommand = new DelegateCommand(ApplyColor);

            _lstTheme = new ObservableCollection<NameValue>()
            {
                new NameValue() {Name = "Light", Value = "White"},
                new NameValue() {Name = "Dark", Value = "Black"}
            };

            SelectedTheme = LstTheme[0];

            _lstColor = new ObservableCollection<NameValue>()
            {
                new NameValue() {Name = "blue", Value = "#2196F3"},
                new NameValue() {Name = "red", Value = "#e52400"},
                new NameValue() {Name = "green", Value = "#60a917"},

                new NameValue() {Name = "purple", Value = "#800080"},
                new NameValue() {Name = "orange", Value = "#fa6800"}

            };

            SelectedColor = _lstColor[0];
        }

        private void ApplyColor()
        {
            ApplyThemeColor();
        }

        private void ApplyTheme()
        {
            ApplyThemeColor();
        }
        private void ApplyThemeColor()
        {
            try
            {
                var accent = SelectedColor.Name ?? LstColor[0].Name;
                var theme = SelectedTheme.Name ?? LstTheme[0].Name;
                Accent newAccent = ThemeManager.GetAccent(accent);
                AppTheme newTheme = ThemeManager.GetAppTheme("Base" + theme);
                ThemeManager.ChangeAppStyle(Application.Current, newAccent, newTheme);
            }
            catch (System.Exception ex)
            {


            }
        }


        private ObservableCollection<NameValue> _lstTheme;

        public ObservableCollection<NameValue> LstTheme
        {
            get { return _lstTheme; }
            set { SetProperty(ref _lstTheme, value); }
        }


        private ObservableCollection<NameValue> _lstColor;

        public ObservableCollection<NameValue> LstColor
        {
            get { return _lstColor; }
            set { SetProperty(ref _lstColor, value); }
        }
        private NameValue _selectedColor;

        public NameValue SelectedColor
        {
            get { return _selectedColor; }
            set { SetProperty(ref _selectedColor, value); }
        }

        private NameValue _selectedTheme;

        public NameValue SelectedTheme
        {
            get { return _selectedTheme; }
            set { SetProperty(ref _selectedTheme, value); }
        }

        public ICommand ApplyThemeCommand { get; set; }
        public ICommand ApplyColorCommand { get; set; }

    }

}

