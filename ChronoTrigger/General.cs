using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
	}
}
