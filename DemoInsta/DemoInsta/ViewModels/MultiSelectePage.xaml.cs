using DemoInsta.Components;
using DemoInsta.Models;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace DemoInsta.ViewModels
{
    public partial class MultiSelectePage : ContentPage
    {
        Dictionary<IMultiSelectModel, bool> Items;
        public bool IsOpen;
        SettingsMultiSelectComponent MultiSelectElement;

        public MultiSelectePage(SettingsMultiSelectComponent RootMultiSelectElement)
        {
            InitializeComponent();
            MultiSelectElement = RootMultiSelectElement;
        }

        public void SetTitle(string ATitle)
        {
            TitleLbl.Text = ATitle;
        }

        public void InitialiseMutliSelect(Dictionary<IMultiSelectModel, bool> _Items)
        {
            Items = _Items;
            MutliSelectListView.ItemsSource = Items;
        }

        void OnLabelClicked(object sender, EventArgs e)
        {
            Label Lbl = ((Label)sender);
            UpdateCell(Lbl);
        }

        void UpdateCell(Label Lbl)
        {
            if (Lbl.BackgroundColor == Color.White)
            {
                Lbl.BackgroundColor = Color.FromHex("#132d48");
                Lbl.TextColor = Color.White;
            }
            else
            {
                Lbl.BackgroundColor = Color.White;
                Lbl.TextColor = Color.Black;
            }

            KeyValuePair<IMultiSelectModel, bool> KeyPair = (KeyValuePair<IMultiSelectModel, bool>) ((ContentView)Lbl.Parent).BindingContext;
            IMultiSelectModel Parent = KeyPair.Key;

            Items[Parent] = !Items[Parent];
        }

        void SetNewLbl()
        {
            int Count = 0;

            foreach(bool Value in Items.Values)
            {
                if(Value)
                    Count++;
            }

            if (Count == Items.Count)
            {
                MultiSelectElement.SetSelectedLbl("All " + Title + " Selected");
            }
            else if (Count > 1)
            {
                MultiSelectElement.SetSelectedLbl(Count + " " + Title + " Selected");
            }
            else if(Count == 1)
            {
                MultiSelectElement.SetSelectedLbl(GetOnlySelectedItem() + " Selected");
            }
            else
            {
                MultiSelectElement.SetSelectedLbl("No " + Title + " Selected");
            }
        }

        string GetOnlySelectedItem()
        {
            string Name = "";
            foreach (IMultiSelectModel Key in Items.Keys)
            {
                if (Items[Key])
                {
                    Name = Key.Name;
                    break;
                }
            }
            return Name;
        }

        void SaveAndExit(object sender, EventArgs e)
        {
            if (Navigation.ModalStack.Count == 1)
            {
                SetNewLbl();
                Navigation.PopModalAsync();
            }
        }
    }
}