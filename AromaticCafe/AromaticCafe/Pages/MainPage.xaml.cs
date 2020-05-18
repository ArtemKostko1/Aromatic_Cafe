using System;
using AromaticCafe.Classes;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.Net.Mail;
using System.Net;
using System.IO;

namespace AromaticCafe.Pages
{
	/// <summary>
	/// Логика взаимодействия для MainPage.xaml
	/// </summary>
	public partial class MainPage : Page
	{
		public User userProfile;
		public ObservableCollection<Order> Bills { get; set; } = new ObservableCollection<Order>();

		public MainPage(User userProfile)
		{
			InitializeComponent();

			GridProductsMenu.Visibility = Visibility.Visible;

			this.userProfile = userProfile;

			TextBlockProfileName.Text = this.userProfile.UserName;
			TextBlockProfileEmail.Text = this.userProfile.UserEmail;
			TextBlockProfileTelephone.Text = this.userProfile.UserTelephone;
		}

		private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
		{
			ButtonOpenMenu.Visibility = Visibility.Collapsed;
			ButtonCloseMenu.Visibility = Visibility.Visible;
		}

		private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
		{
			ButtonOpenMenu.Visibility = Visibility.Visible;
			ButtonCloseMenu.Visibility = Visibility.Collapsed;
		}

		private void ButtonProfileSignOut_Click(object sender, RoutedEventArgs e)
		{
			Frames.frame.Content = new SignIn();
		}

		private void ButtonOpenProductsMenu_Click(object sender, RoutedEventArgs e)
		{
			if (GridShoppingCart.IsVisible == true)
			{
				GridShoppingCart.Visibility = Visibility.Collapsed;
				GridProductsMenu.Visibility = Visibility.Visible;
			}
			else
			{
				if (GridOrders.IsVisible == true)
				{
					GridOrders.Visibility = Visibility.Collapsed;
					GridProductsMenu.Visibility = Visibility.Visible;
				}
			}
		}

		private void ButtonOpenShoppingCart_Click(object sender, RoutedEventArgs e)
		{		

			if(GridProductsMenu.IsVisible == true)
			{			
				GridProductsMenu.Visibility = Visibility.Collapsed;
				GridShoppingCart.Visibility = Visibility.Visible;
			}
			else
			{
				if (GridOrders.IsVisible == true)
				{
					GridOrders.Visibility = Visibility.Collapsed;
					GridShoppingCart.Visibility = Visibility.Visible;
				}
			}

			if (GridShoppingCartItem1.IsVisible == true | GridShoppingCartItem2.IsVisible == true | GridShoppingCartItem3.IsVisible == true |
				GridShoppingCartItem4.IsVisible == true | GridShoppingCartItem5.IsVisible == true | GridShoppingCartItem6.IsVisible == true | 
				GridShoppingCartItem7.IsVisible == true | GridShoppingCartItem8.IsVisible == true)
			{
				GridShoppingCartBuy.Visibility = Visibility.Visible;
			}
			else
			{
				GridShoppingCartBuy.Visibility = Visibility.Collapsed;
			}
		}

		private void ButtonOpenOrders_Click(object sender, RoutedEventArgs e)
		{
			if (GridProductsMenu.IsVisible == true)
			{
				GridProductsMenu.Visibility = Visibility.Collapsed;
				GridOrders.Visibility = Visibility.Visible;
			}
			else
			{
				if (GridShoppingCart.IsVisible == true)
				{
					GridShoppingCart.Visibility = Visibility.Collapsed;
					GridOrders.Visibility = Visibility.Visible;
				}
			}

			using (AromaticCafeDBContext context = new AromaticCafeDBContext())
			{
				var orders = context.Orders.ToList();

				Bills.Clear();

				foreach (Order o in orders)  //добавление в коллекцию новых заказов
				{
					if (o.UserId == userProfile.UserId)
					{
						Bills.Add(o);
					}
				}

				IEnumerable<Order> enumerable = Bills.Reverse(); 
				billsList.ItemsSource = enumerable;
			}
		}


		private void ButtonOpenAboutCafe_Click(object sender, RoutedEventArgs e)
		{
			if (GridProfile.IsVisible == true)
			{
				GridProfile.Visibility = Visibility.Collapsed;
				GridAboutCafe.Visibility = Visibility.Visible;
			}
			else
				GridAboutCafe.Visibility = Visibility.Visible;
		}

		private void ButtonOpenProfile_Click(object sender, RoutedEventArgs e)
		{
			if (GridAboutCafe.IsVisible == true)
			{
				GridAboutCafe.Visibility = Visibility.Collapsed;
				GridProfile.Visibility = Visibility.Visible;
			}
			else
				GridProfile.Visibility = Visibility.Visible;
		}


		private void ButtonProductMenuAddItem_Click(object sender, RoutedEventArgs e)
		{
			var button = sender as Button;
			if (button.Name == "ButtonProductMenuAddItem1")
			{
				GridShoppingCartItem1.Visibility = Visibility.Visible;
			}
			if (button.Name == "ButtonProductMenuAddItem2")
			{
				GridShoppingCartItem2.Visibility = Visibility.Visible;
			}
			if (button.Name == "ButtonProductMenuAddItem3")
			{
				GridShoppingCartItem3.Visibility = Visibility.Visible;
			}
			if (button.Name == "ButtonProductMenuAddItem4")
			{
				GridShoppingCartItem4.Visibility = Visibility.Visible;
			}
			if (button.Name == "ButtonProductMenuAddItem5")
			{
				GridShoppingCartItem5.Visibility = Visibility.Visible;
			}
			if (button.Name == "ButtonProductMenuAddItem6")
			{
				GridShoppingCartItem6.Visibility = Visibility.Visible;
			}
			if (button.Name == "ButtonProductMenuAddItem7")
			{
				GridShoppingCartItem7.Visibility = Visibility.Visible;
			}
			if (button.Name == "ButtonProductMenuAddItem8")
			{
				GridShoppingCartItem8.Visibility = Visibility.Visible;
			}
		}


		int a = 1;
		int b = 1;
		int c = 1;
		int d = 1;
		int f = 1;
		int g = 1;
		int h = 1;
		int k = 1;
		private void ButtonShoppingCartDeleteItem_Click(object sender, RoutedEventArgs e)
		{
			var button = sender as Button;
			if (button.Name == "ButtonShoppingCartDeleteItem1")
			{
				GridShoppingCartItem1.Visibility = Visibility.Collapsed;
				a = 1;
				TextBlockShoppingCartItemCount1.Text = Convert.ToString(a);
			}
			if (button.Name == "ButtonShoppingCartDeleteItem2")
			{
				GridShoppingCartItem2.Visibility = Visibility.Collapsed;
				b = 1;
				TextBlockShoppingCartItemCount2.Text = Convert.ToString(b);
			}
			if (button.Name == "ButtonShoppingCartDeleteItem3")
			{
				GridShoppingCartItem3.Visibility = Visibility.Collapsed;
				c = 1;
				TextBlockShoppingCartItemCount3.Text = Convert.ToString(c);
			}
			if (button.Name == "ButtonShoppingCartDeleteItem4")
			{
				GridShoppingCartItem4.Visibility = Visibility.Collapsed;
				d = 1;
				TextBlockShoppingCartItemCount4.Text = Convert.ToString(d);
			}
			if (button.Name == "ButtonShoppingCartDeleteItem5")
			{
				GridShoppingCartItem5.Visibility = Visibility.Collapsed;
				f = 1;
				TextBlockShoppingCartItemCount5.Text = Convert.ToString(f);
			}
			if (button.Name == "ButtonShoppingCartDeleteItem6")
			{
				GridShoppingCartItem6.Visibility = Visibility.Collapsed;
				g = 1;
				TextBlockShoppingCartItemCount6.Text = Convert.ToString(g);
			}
			if (button.Name == "ButtonShoppingCartDeleteItem7")
			{
				GridShoppingCartItem7.Visibility = Visibility.Collapsed;
				h = 1;
				TextBlockShoppingCartItemCount7.Text = Convert.ToString(h);
			}
			if (button.Name == "ButtonShoppingCartDeleteItem8")
			{
				GridShoppingCartItem8.Visibility = Visibility.Collapsed;
				k = 1;
				TextBlockShoppingCartItemCount6.Text = Convert.ToString(k);
			}

			if (GridShoppingCartItem1.IsVisible == true | GridShoppingCartItem2.IsVisible == true | GridShoppingCartItem3.IsVisible == true |
				GridShoppingCartItem4.IsVisible == true | GridShoppingCartItem5.IsVisible == true | GridShoppingCartItem6.IsVisible == true |
				GridShoppingCartItem7.IsVisible == true | GridShoppingCartItem8.IsVisible == true)
			{
				GridShoppingCartBuy.Visibility = Visibility.Visible;
			}
			else
			{
				GridShoppingCartBuy.Visibility = Visibility.Collapsed;
			}
		}


		private void ButtonShoppingCartItemCountMinus_Click(object sender, RoutedEventArgs e)
		{
			var button = sender as Button;
			if (button.Name == "ButtonShoppingCartItemCountMinus1")
			{
				if(a != 1)
				{
					a--;
					TextBlockShoppingCartItemCount1.Text = Convert.ToString(a);
				}
				else
					TextBlockShoppingCartItemCount1.Text = Convert.ToString(a);
			}
			if (button.Name == "ButtonShoppingCartItemCountMinus2")
			{
				if (b != 1)
				{
					b--;
					TextBlockShoppingCartItemCount2.Text = Convert.ToString(b);
				}
				else
					TextBlockShoppingCartItemCount2.Text = Convert.ToString(b);
			}
			if (button.Name == "ButtonShoppingCartItemCountMinus3")
			{
				if (c != 1)
				{
					c--;
					TextBlockShoppingCartItemCount3.Text = Convert.ToString(c);
				}
				else
					TextBlockShoppingCartItemCount3.Text = Convert.ToString(c);
			}
			if (button.Name == "ButtonShoppingCartItemCountMinus4")
			{
				if (d != 1)
				{
					d--;
					TextBlockShoppingCartItemCount4.Text = Convert.ToString(d);
				}
				else
					TextBlockShoppingCartItemCount4.Text = Convert.ToString(d);
			}
			if (button.Name == "ButtonShoppingCartItemCountMinus5")
			{
				if (f != 1)
				{
					f--;
					TextBlockShoppingCartItemCount5.Text = Convert.ToString(f);
				}
				else
					TextBlockShoppingCartItemCount5.Text = Convert.ToString(f);
			}
			if (button.Name == "ButtonShoppingCartItemCountMinus6")
			{
				if (g != 1)
				{
					g--;
					TextBlockShoppingCartItemCount6.Text = Convert.ToString(g);
				}
				else
					TextBlockShoppingCartItemCount6.Text = Convert.ToString(g);
			}
			if (button.Name == "ButtonShoppingCartItemCountMinus7")
			{
				if (h != 1)
				{
					h--;
					TextBlockShoppingCartItemCount7.Text = Convert.ToString(h);
				}
				else
					TextBlockShoppingCartItemCount7.Text = Convert.ToString(h);
			}
			if (button.Name == "ButtonShoppingCartItemCountMinus8")
			{
				if (k != 1)
				{
					k--;
					TextBlockShoppingCartItemCount8.Text = Convert.ToString(k);
				}
				else
					TextBlockShoppingCartItemCount8.Text = Convert.ToString(k);
			}
		}

		private void ButtonShoppingCartItemCountPlus_Click(object sender, RoutedEventArgs e)
		{
			var button = sender as Button;
			if (button.Name == "ButtonShoppingCartItemCountPlus1")
			{
				a++;
				TextBlockShoppingCartItemCount1.Text = Convert.ToString(a);
			}
			if (button.Name == "ButtonShoppingCartItemCountPlus2")
			{
				b++;
				TextBlockShoppingCartItemCount2.Text = Convert.ToString(b);
			}
			if (button.Name == "ButtonShoppingCartItemCountPlus3")
			{
				c++;
				TextBlockShoppingCartItemCount3.Text = Convert.ToString(c);
			}
			if (button.Name == "ButtonShoppingCartItemCountPlus4")
			{
				d++;
				TextBlockShoppingCartItemCount4.Text = Convert.ToString(d);
			}
			if (button.Name == "ButtonShoppingCartItemCountPlus5")
			{
				f++;
				TextBlockShoppingCartItemCount5.Text = Convert.ToString(f);
			}
			if (button.Name == "ButtonShoppingCartItemCountPlus6")
			{
				g++;
				TextBlockShoppingCartItemCount6.Text = Convert.ToString(g);
			}
			if (button.Name == "ButtonShoppingCartItemCountPlus7")
			{
				h++;
				TextBlockShoppingCartItemCount7.Text = Convert.ToString(h);
			}
			if (button.Name == "ButtonShoppingCartItemCountPlus8")
			{
				k++;
				TextBlockShoppingCartItemCount8.Text = Convert.ToString(k);
			}
		}



		private void ButtonShoppingCartBuy_Click(object sender, RoutedEventArgs e) //формирование чека
		{
			double total = 0;

			string bill = Convert.ToString(DateTime.Now) +"\n";
			bill += "----------------------------------------------------\n";

			if (GridShoppingCartItem1.IsVisible == true)
			{
				bill += $"{TextBlockShoppingCartItemName1.Text, -25}{TextBlockShoppingCartItemCount1.Text, -2} x ${TextBlockShoppingCartItemPrice1.Text, -10}${Convert.ToInt32(TextBlockShoppingCartItemCount1.Text) * Convert.ToDouble(TextBlockShoppingCartItemPrice1.Text)}\n";
				total += Convert.ToInt32(TextBlockShoppingCartItemCount1.Text) * Convert.ToDouble(TextBlockShoppingCartItemPrice1.Text);
				GridShoppingCartItem1.Visibility = Visibility.Collapsed;
			}
			if (GridShoppingCartItem2.IsVisible == true)
			{
				bill += $"{TextBlockShoppingCartItemName2.Text, -26}{TextBlockShoppingCartItemCount2.Text, -2} x ${TextBlockShoppingCartItemPrice2.Text, -11}${Convert.ToInt32(TextBlockShoppingCartItemCount2.Text) * Convert.ToDouble(TextBlockShoppingCartItemPrice2.Text)}\n";
				total += Convert.ToInt32(TextBlockShoppingCartItemCount2.Text) * Convert.ToDouble(TextBlockShoppingCartItemPrice2.Text);
				GridShoppingCartItem2.Visibility = Visibility.Collapsed;
			}
			if (GridShoppingCartItem3.IsVisible == true)
			{
				bill += $"{TextBlockShoppingCartItemName3.Text, -31}{TextBlockShoppingCartItemCount3.Text, -2} x ${TextBlockShoppingCartItemPrice3.Text, -10}${Convert.ToInt32(TextBlockShoppingCartItemCount3.Text) * Convert.ToDouble(TextBlockShoppingCartItemPrice3.Text)}\n";
				total += Convert.ToInt32(TextBlockShoppingCartItemCount3.Text) * Convert.ToDouble(TextBlockShoppingCartItemPrice3.Text);
				GridShoppingCartItem3.Visibility = Visibility.Collapsed;
			}
			if (GridShoppingCartItem4.IsVisible == true)
			{
				bill += $"{TextBlockShoppingCartItemName4.Text, -27}{TextBlockShoppingCartItemCount4.Text, -2} x ${TextBlockShoppingCartItemPrice4.Text, -11}${Convert.ToInt32(TextBlockShoppingCartItemCount4.Text) * Convert.ToDouble(TextBlockShoppingCartItemPrice4.Text)}\n";
				total += Convert.ToInt32(TextBlockShoppingCartItemCount4.Text) * Convert.ToDouble(TextBlockShoppingCartItemPrice4.Text);
				GridShoppingCartItem4.Visibility = Visibility.Collapsed;
			}
			if (GridShoppingCartItem5.IsVisible == true)
			{
				bill += $"{TextBlockShoppingCartItemName5.Text, -27}{TextBlockShoppingCartItemCount5.Text, -2} x ${TextBlockShoppingCartItemPrice5.Text, -10}${Convert.ToInt32(TextBlockShoppingCartItemCount5.Text) * Convert.ToDouble(TextBlockShoppingCartItemPrice5.Text)}\n";
				total += Convert.ToInt32(TextBlockShoppingCartItemCount5.Text) * Convert.ToDouble(TextBlockShoppingCartItemPrice5.Text);
				GridShoppingCartItem5.Visibility = Visibility.Collapsed;
			}
			if (GridShoppingCartItem6.IsVisible == true)
			{
				bill += $"{TextBlockShoppingCartItemName6.Text, -26}{TextBlockShoppingCartItemCount6.Text, -2} x ${TextBlockShoppingCartItemPrice6.Text, -10}${Convert.ToInt32(TextBlockShoppingCartItemCount6.Text) * Convert.ToDouble(TextBlockShoppingCartItemPrice6.Text)}\n";
				total += Convert.ToInt32(TextBlockShoppingCartItemCount6.Text) * Convert.ToDouble(TextBlockShoppingCartItemPrice6.Text);
				GridShoppingCartItem6.Visibility = Visibility.Collapsed;
			}
			if (GridShoppingCartItem7.IsVisible == true)
			{
				bill += $"{TextBlockShoppingCartItemName7.Text,-26}{TextBlockShoppingCartItemCount7.Text,-2} x ${TextBlockShoppingCartItemPrice7.Text,-9}${Convert.ToInt32(TextBlockShoppingCartItemCount7.Text) * Convert.ToDouble(TextBlockShoppingCartItemPrice7.Text)}\n";
				total += Convert.ToInt32(TextBlockShoppingCartItemCount7.Text) * Convert.ToDouble(TextBlockShoppingCartItemPrice7.Text);
				GridShoppingCartItem7.Visibility = Visibility.Collapsed;
			}
			if (GridShoppingCartItem8.IsVisible == true)
			{
				bill += $"{TextBlockShoppingCartItemName8.Text,-30}{TextBlockShoppingCartItemCount8.Text,-2} x ${TextBlockShoppingCartItemPrice8.Text,-10}${Convert.ToInt32(TextBlockShoppingCartItemCount8.Text) * Convert.ToDouble(TextBlockShoppingCartItemPrice8.Text)}\n";
				total += Convert.ToInt32(TextBlockShoppingCartItemCount8.Text) * Convert.ToDouble(TextBlockShoppingCartItemPrice8.Text);
				GridShoppingCartItem8.Visibility = Visibility.Collapsed;
			}

			bill += "----------------------------------------------------\n";
			bill += $"Total                                               ${total}";

			using (AromaticCafeDBContext context = new AromaticCafeDBContext())  //добавление нового заказа в базу
			{
				Order order = new Order();
				order.UserId = userProfile.UserId;
				order.OrderContent = bill;

				context.Orders.Add(order);
				context.SaveChanges();
			}

			try  //отправка чека на E-mail
			{
				MailAddress from = new MailAddress("someemail@mail.ru", "Name");
				MailAddress to = new MailAddress(userProfile.UserEmail);

				MailMessage message = new MailMessage(from, to);
				message.Subject = "Your Bill";
				message.Body = bill;
				message.IsBodyHtml = false;

				SmtpClient smtp = new SmtpClient("smtp.mail.ru", 587);
				smtp.Credentials = new NetworkCredential("someemail@mail.ru", "password");
				smtp.EnableSsl = true;
				smtp.Send(message);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}


			//распечатка чека в файл
			string path = @"Files\FileBill";
			using (StreamWriter stream = new StreamWriter(path))
				stream.WriteLine(bill);


			//вывод чека на печать
			PrintDialog printDlg = new PrintDialog();
			FlowDocument doc = new FlowDocument(new Paragraph(new Run(bill)));
			doc.Name = "FlowDoc";
			IDocumentPaginatorSource idpSource = doc;
			printDlg.PrintDocument(idpSource.DocumentPaginator,  "Your bill" );
			


			if (GridShoppingCartItem1.IsVisible == true | GridShoppingCartItem2.IsVisible == true | GridShoppingCartItem3.IsVisible == true |
				GridShoppingCartItem4.IsVisible == true | GridShoppingCartItem5.IsVisible == true | GridShoppingCartItem6.IsVisible == true |
				GridShoppingCartItem7.IsVisible == true | GridShoppingCartItem8.IsVisible == true)
			{
				GridShoppingCartBuy.Visibility = Visibility.Visible;
			}
			else
			{
				GridShoppingCartBuy.Visibility = Visibility.Collapsed;
			}
		}
	}
}
