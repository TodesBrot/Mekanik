﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Meka;

namespace Mekanik
{
	public class EntityInstance
	{
		public string Type;
		public double X;
		public double Y;
		public int Z;
		public Dictionary<string, string> Properties = new Dictionary<string, string>();

		public EntityInstance(MekaItem _item)
		{
			this.Type = _item.Name;

			this.X = _item["X"].To<double>();
			this.Y = _item["Y"].To<double>();
			this.Z = _item["Z"].To<int>();

			foreach (MekaItem s in _item["Properties"].Children)
				this.Properties[s.Name] = s.Content;
		}

		internal MekaItem _Export()
		{
			MekaItem @out = new MekaItem(this.Type, new List<MekaItem>());
			@out.Children.Add(new MekaItem("X", this.X.ToString()));
			@out.Children.Add(new MekaItem("Y", this.Y.ToString()));
			@out.Children.Add(new MekaItem("Z", this.Z.ToString()));
			@out.Children.Add(new MekaItem("Properties", this.Properties.Select(item => new MekaItem(item.Key, item.Value)).ToList()));
			return @out;
		}
	}
}