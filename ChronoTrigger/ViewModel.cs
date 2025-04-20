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
		public ICommand ForceOpenFileCommand { get; init; }
		public ICommand SaveFileCommand { get; init; }
		public ICommand ChoiceItemCommand { get; init; }

		public General General { get; init; } = new();
		public ObservableCollection<Item> Weapons { get; init; } = new();
		public ObservableCollection<Item> Armors { get; init; } = new();
		public ObservableCollection<Item> Helmets { get; init; } = new();
		public ObservableCollection<Item> Accessories { get; init; } = new();
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
			ForceOpenFileCommand = new ActionCommand(ForceOpenFile);
			SaveFileCommand = new ActionCommand(SaveFile);
			ChoiceItemCommand = new ActionCommand(ChoiceItem);
		}

		private void Initialize()
		{
			Weapons.Clear();
			for (uint i = 0; i < 111; i++)
			{
				Weapons.Add(new Item(0x06FC + i * 4));
			}

			Armors.Clear();
			for (uint i = 0; i < 50; i++)
			{
				Armors.Add(new Item(0x08B8 + i * 4));
			}

			Helmets.Clear();
			for (uint i = 0; i < 39; i++)
			{
				Helmets.Add(new Item(0x0980 + i * 4));
			}

			Accessories.Clear();
			for (uint i = 0; i < 59; i++)
			{
				Accessories.Add(new Item(0x0A1C + i * 4));
			}

			Items.Clear();
			for (uint i = 0; i < 43; i++)
			{
				Items.Add(new Item(0x0B08 + i * 4));
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
			OpenFile(false);
		}

		private void ForceOpenFile(Object? param)
		{
			OpenFile(true);
		}

		private void OpenFile(bool force)
		{
			var dlg = new OpenFileDialog();
			if (dlg.ShowDialog() == false) return;

			if (SaveData.Instance().Open(dlg.FileName, force) == false)
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
			if (param is not Tuple<Item, ChoiceWindow.ChoiceType> tuple) return;

			ChoiceItem(tuple.Item1, tuple.Item2);
		}

		private void ChoiceItem(Item item, ChoiceWindow.ChoiceType type)
		{
			var dlg = new ChoiceWindow();
			dlg.ID = item.ID;
			dlg.Type = type;
			dlg.ShowDialog();
			item.ID = dlg.ID;
			item.Count = item.ID == 0 ? 0U : 1;
		}
	}
}
