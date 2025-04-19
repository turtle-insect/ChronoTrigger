using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Microsoft.Win32;

namespace ChronoTrigger
{
	internal class ViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler? PropertyChanged;

		public Info Info { get; init; } = Info.Instance();
		public ICommand OpenFileCommand { get; init; }
		public ICommand SaveFileCommand { get; init; }
		public ICommand ChoiceItemCommand { get; init; }

		public General General { get; init; } = new();
		public ObservableCollection<Item> Items { get; init; } = new();
		public ObservableCollection<Item> Importants { get; init; } = new();
		public ObservableCollection<Character> Characters { get; init; } = new();

		private uint mSlotIndex = 0;

		public uint SlotIndex
		{
			get { return mSlotIndex; }
			set
			{
				SaveData.Instance().WriteCheckSum();
				mSlotIndex = value;
				SaveData.Instance().Adventure = value;
				Initialize();
			}
		}

		public ViewModel()
		{
			OpenFileCommand = new ActionCommand(OpenFile);
			SaveFileCommand = new ActionCommand(SaveFile);
			ChoiceItemCommand = new ActionCommand(ChoiceItem);
		}

		private void Initialize()
		{
			Items.Clear();
			for (uint i = 0; i < 111; i++)
			{
				Items.Add(new Item(0x06FC + i * 4));
			}

			Importants.Clear();
			for (uint i = 0; i < 45; i++)
			{
				Importants.Add(new Item(0x0BB4 + i * 4));
			}

			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(General)));
		}

		private void OpenFile(Object? param)
		{
			var dlg = new OpenFileDialog();
			if (dlg.ShowDialog() == false) return;

			if (SaveData.Instance().Open(dlg.FileName, false) == false)
			{
				MessageBox.Show("Failed");
				return;
			}
			Initialize();
		}

		private void SaveFile(Object? param)
		{
			SaveData.Instance().Save();
		}

		private void ChoiceItem(Object? param)
		{
			if (param is not Item item) return;

			ChoiceItem(item, true);
		}

		private void ChoiceItem(Item item, bool isItem)
		{
			var dlg = new ChoiceWindow();
			dlg.ID = item.ID;
			dlg.ShowDialog();
			item.ID = dlg.ID;
			item.Count = item.ID == 0 ? 0U : 1;
		}
	}
}
