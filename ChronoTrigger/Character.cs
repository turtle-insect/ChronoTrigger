using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChronoTrigger
{
	internal class Character
	{
		private readonly uint mStatusAddress;
		private readonly uint mNameAddress;

		public Character(uint statusAddress, uint nameAddress)
		{
			mStatusAddress = statusAddress;
			mNameAddress = nameAddress;
		}

		public String Name
		{
			get => SaveData.Instance().ReadText(mNameAddress, 10);
			set => SaveData.Instance().WriteText(mNameAddress, 10, value);
		}
	}
}
