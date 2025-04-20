﻿using System.Windows;
using System.Windows.Controls;

namespace ChronoTrigger
{
	/// <summary>
	/// ChoiceWindow.xaml の相互作用ロジック
	/// </summary>
	public partial class ChoiceWindow : Window
	{
		public enum ChoiceType
		{
			Weapon,
			Armor,
			Helmet,
			Accessories,
			Item,
			Important,
		}

		public ChoiceType Type { get; set; } = ChoiceType.Item;
		public uint ID { get; set; }

		public ChoiceWindow()
		{
			InitializeComponent();
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			CreateItemList("");
			foreach (var item in ListBoxItem.Items)
			{
				if (item is not NameValueInfo info) continue;
				if (info.Value == ID)
				{
					ListBoxItem.SelectedItem = item;
					ListBoxItem.ScrollIntoView(item);
					break;
				}
			}
		}

		private void TextBoxFilter_TextChanged(object sender, TextChangedEventArgs e)
		{
			CreateItemList(TextBoxFilter.Text);
		}

		private void ListBoxItem_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			ButtonDecision.IsEnabled = ListBoxItem.SelectedIndex >= 0;
		}

		private void ButtonDecision_Click(object sender, RoutedEventArgs e)
		{
			if (ListBoxItem.SelectedItem is not NameValueInfo info) return;
			ID = info.Value;
			Close();
		}

		private void CreateItemList(String filter)
		{
			ListBoxItem.Items.Clear();
			List<NameValueInfo> items = Info.Instance().Weapon;
			switch(Type)
			{
				case ChoiceType.Armor:
					items = Info.Instance().Armor;
					break;

				case ChoiceType.Helmet:
					items = Info.Instance().Helmet;
					break;

				case ChoiceType.Accessories:
					items = Info.Instance().Accessories;
					break;

				case ChoiceType.Item:
					items = Info.Instance().Item;
					break;

				case ChoiceType.Important:
					items = Info.Instance().Imp;
					break;
			}

			foreach (var item in items)
			{
				if (String.IsNullOrEmpty(filter) || item.Name.IndexOf(filter) >= 0)
				{
					ListBoxItem.Items.Add(item);
				}
			}
		}
	}
}
