namespace ChronoTrigger
{
	internal class General
	{
		public uint SaveCount
		{
			get => SaveData.Instance().ReadNumber(0x0D48, 4);
			set => Util.WriteNumber(0x0D48, 4, value, 0, 9999999);
		}

		public uint Money
		{
			get => SaveData.Instance().ReadNumber(0x0D44, 4);
			set => Util.WriteNumber(0x0D44, 4, value, 0, 9999999);
		}

		public uint SliverPoint
		{
			get => SaveData.Instance().ReadNumber(0x027A, 1);
			set => Util.WriteNumber(0x027A, 1, value, 0, 255);
		}

		public uint CatFood
		{
			get => SaveData.Instance().ReadNumber(0x0287, 1);
			set => Util.WriteNumber(0x0287, 1, value, 0, 255);
		}

		public String AirShip
		{
			get => SaveData.Instance().ReadText(0x0D08, 10);
			set => SaveData.Instance().WriteText(0x0D08, 10, value);
		}

		public uint PartyNo1
		{
			get => SaveData.Instance().ReadNumber(0x0D38, 1);
			set => SaveData.Instance().WriteNumber(0x0D38, 1, value);
		}

		public uint PartyNo2
		{
			get => SaveData.Instance().ReadNumber(0x0D39, 1);
			set => SaveData.Instance().WriteNumber(0x0D39, 1, value);
		}

		public uint PartyNo3
		{
			get => SaveData.Instance().ReadNumber(0x0D3A, 1);
			set => SaveData.Instance().WriteNumber(0x0D3A, 1, value);
		}
	}
}
