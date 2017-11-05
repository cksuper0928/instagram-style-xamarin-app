using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace DemoInsta.Components
{
    public partial class SettingsSingleSelectComponent : StackLayout
    {
        Dictionary<string, object> PickerList;

        public string Title
        {
            get { return GetValue(TitleProperty).ToString(); }
            set { SetValue(TitleProperty, value); }
        }
        public static readonly BindableProperty TitleProperty = BindableProperty.Create
            (
            propertyName: "Title",
            returnType: typeof(string),
            declaringType: typeof(SettingsSingleSelectComponent),
            defaultValue: "",
            defaultBindingMode: BindingMode.TwoWay,
            propertyChanged: TitleChanged
            );

        public static void TitleChanged(BindableObject Bindable, object OldValue, object NewValue)
        {
            SettingsSingleSelectComponent Control = (SettingsSingleSelectComponent)Bindable;
            Control.TitleLbl.Text = (string)NewValue;
        }

        public SettingsSingleSelectComponent()
        {
            InitializeComponent();
        }

        public void InitialisePicker(Dictionary<string, object> ADictionary)
        {
            PickerList = ADictionary;

            foreach (string Item in PickerList.Keys)
            {
                ThePicker.Items.Add(Item);
            }

            SelectedLbl.Text = PickerList.Keys.First();
            ThePicker.SelectedIndex = 0;
        }

        string GetSelectedPickerText()
        {
            int index = ThePicker.SelectedIndex;
            return ThePicker.Items[index];
        }

        private void OpenPicker(object sender, System.EventArgs e)
        {
            ThePicker.Focus();
        }

        private void ItemChanged(object sender, System.EventArgs e)
        {
            SelectedLbl.Text = GetSelectedPickerText();
        }

        public Object GetSelectedItem()
        {
            return PickerList[GetSelectedPickerText()];
        }
    }
}