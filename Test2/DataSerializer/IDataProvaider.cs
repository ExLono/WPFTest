using System;
using System.IO;
using System.Xml.Serialization;
using System.Collections.Generic;
using Test2.Models;

namespace Test2.DataSerializer
{

	public interface IDataProvaider
	{
		public void SaveXMLData(IList<User> users);
		public IList<User> LoadXMLData();

	}

}