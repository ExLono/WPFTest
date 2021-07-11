using System;
using System.IO;
using System.Windows;
using System.Xml.Linq;

namespace Test2
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		public string XmlFile { get; private set; } = "Users.xml";
		//Потому записываем только в один XML и поэтому private set
		public XDocument XDocument { get; private set; }
		#region Overrides of Application

		//Перегруженный нами метод загрузки приложения
		/// <inheritdoc />
		protected override void OnStartup(StartupEventArgs e)
		{
			base.OnStartup(e);
			var pathXmlFile = Path.Combine(Environment.CurrentDirectory, XmlFile);
			if (!File.Exists(pathXmlFile))
			{
				using FileStream fs = File.Create(pathXmlFile);
				fs.Dispose();
				XDocument = new XDocument(new XElement("Users", null));
				XDocument.Save(XmlFile);
				return;
			}
			XDocument = XDocument.Load(pathXmlFile);
			XmlFile = pathXmlFile;
		}

		/// <inheritdoc />
		protected override void OnExit(ExitEventArgs e)
		{
			//Я не особо работал с этим классом, поэтому навсякий случай удалим из памяти все данные про XML документ, на всякий случай
			XDocument = null;
			base.OnExit(e);
		}

		#endregion
	}
}
