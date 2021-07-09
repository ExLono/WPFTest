using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Xml;
using System.Xml.Linq;

namespace Test2
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private readonly XDocument _xDocument;
		private readonly string _pathXML;
		int i = 0;
		public MainWindow()
		{
			InitializeComponent();
			//Во-первых конструктор должен включать в себя только методы и ничего больше. В нём вообще должно быть как можно меньше логики
			//Во-вторых нет проверки на случай если нет файла
			//В-третьих у тебя просто инициализируется переменная с объектом XML и больше нигде не используется, то есть бестолковая лишняя работа
			//В-четвертых у тебя приложение без XML не работает, имеет смысл инициализацию XML перенести в класс App (в нём происходит кртическая 
			//логика запуска приложения)
			//XDocument xNewDoc = XDocument.Load(xmlFile);
			var app = (Application.Current as App); 
			_xDocument = app.XDocument; //Что-то такое больше приветсвется в сообществе
			_pathXML = app.XmlFile;
            i = _xDocument.Root.Nodes().Count();
			//Обновление
			obnovleniewpf();
		}

		//Добавление кнопка по Text
		private void Button_Click1(object sender, RoutedEventArgs e)
		{
			i++;
			txtDelet.Text = i.ToString();
			XDocument xNewDoc = _xDocument;
			//Запись
			//По-хорошему все атрибуты выводят в некоторый класс модель
			StringBuilder sb = new StringBuilder();
			using (XmlWriter xmlWriter = XmlWriter.Create(sb))
			{
				xNewDoc.Root.Add
				(
					new XElement
					(
						"User", new XElement("ID", txtDelet.Text),
						new XElement("Name", txtName.Text),
						new XElement("Surname", txtSurname.Text),
						new XElement("Otches", txtOtches.Text), new XElement("Phone", txtName.Text)
					)
				);

			}
			xNewDoc.Save(_pathXML);
			obnovleniewpf();

		}

		//Кнопка удаления строки из xml
		private void Button_Click2(object sender, RoutedEventArgs e)
		{
			XDocument xNewDoc = _xDocument;

			IEnumerable<XElement> item =
				from itemXml in xNewDoc.Element("Users").Elements("User")
				where itemXml.Element("ID").Value == i.ToString()
				select itemXml;


			if (item.Count() != 0)
            {
                foreach (XElement xe in xNewDoc.Root.Elements("User"))
                    if (xe.Element("ID").Value == i.ToString())
                        xe.Remove();
            }
			else
			{
				MessageBox.Show("Введите другой лейбл");
				return;
			}

			xNewDoc.Save(_pathXML);

			//Обновление
			obnovleniewpf();

		}

		//Запись юзера по номеру в лейбл и пересохранение его
		private void Button_Click4(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

		//Пересоздание документа, полностью чистый
		private void Button_Click3(object sender, RoutedEventArgs e)
		{
			//Очистка
            XDocument sourceDoc = _xDocument;
			sourceDoc.Root.RemoveAll();
			sourceDoc.Save(_pathXML);
            i = default;

			obnovleniewpf();

		}

		//Обновление
		public void obnovleniewpf()
		{
			XDocument xNewDoc = _xDocument;
			var result = xNewDoc.Descendants("User").Select(x => new
			{
				id = x.Element("ID").Value,
				Name = x.Element("Name").Value,
				Surname = x.Element("Surname").Value,
				Otches = x.Element("Otches").Value,
				Phone = x.Element("Phone").Value,
			});
			UsersGrid.ItemsSource = result;
		}


	}
}
