using System.ComponentModel;

namespace ChronoTrigger
{
	internal class Item : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler? PropertyChanged;

		public Item(uint address) => mAddress = address;

		public uint ID
		{
			get => SaveData.Instance().ReadNumber(mAddress, 2);
			set
			{
				SaveData.Instance().WriteNumber(mAddress, 2, value);
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ID)));
			}
		}

		public uint Count
		{
			get => SaveData.Instance().ReadNumber(mAddress + 2, 2);
			set
			{
				Util.WriteNumber(mAddress + 2, 2, value, 0, 99);
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Count)));
			}
		}

		private readonly uint mAddress;
	}
}
