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
using System.Text.RegularExpressions;

namespace AromaticCafe.Pages
{
	/// <summary>
	/// Логика взаимодействия для SignIn.xaml
	/// </summary>
	public partial class SignIn : Page
	{
		public SignIn()
		{
			InitializeComponent();
		}

		private void ButtonSignIn_Click(object sender, RoutedEventArgs e)  //обработчик нажатия кнопки "Submit"
		{
			if (TextBoxSignInEmail.Text != "" & TextBoxSignInTelephone.Text != "")  //проверка на пустые поля ввода
			{
				bool checkEmail = false;
				bool checkTelephone = false;

				if (!Regex.IsMatch(TextBoxSignInEmail.Text, @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +        //валидация E-mail
															@"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
															RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)))
				{
					checkEmail = false;
				}
				else
					checkEmail = true;

				if (!Regex.IsMatch(TextBoxSignInTelephone.Text, @"^(\s*)?(\+)?([- _():=+]?\d[- _():=+]?){11,13}(\s*)$"))  //валидация телефона
				{
					checkTelephone = false;
				}
				else
					checkTelephone = true;

				if(checkEmail)
				{
					if(checkTelephone)
					{
						using (AromaticCafeDBContext context = new AromaticCafeDBContext())
						{
							var users = context.Users.ToList();
							bool checkUser = false;
							User user = new User();

							foreach (User u in users)
							{
								if (u.UserEmail == TextBoxSignInEmail.Text & u.UserTelephone == TextBoxSignInTelephone.Text)  //проверка на наличии такого пользователя в базе
								{
									checkUser = true;
									user = u;
									break;
								}
								else
									checkUser = false;
							}

							if (checkUser)
							{
								Frames.frame.Content = new MainPage(user);  //переход на главное окно
							}
							else
								TextBlockError.Text = "Your account E-mail or telephone is incorrect";
						}
					}
					else
						TextBlockError.Text = "Invalid telephone format";
				}
				else
					TextBlockError.Text = "Invalid E-mail format";
			}
			else
				TextBlockError.Text = "All margins must be completed";
		}

		private void ButtonHeperlinkSignUp_Click(object sender, RoutedEventArgs e)
		{
			Frames.frame.Content = new SignUp();
		}


		private void ButtonSignInOpenEmailInfo_Click(object sender, RoutedEventArgs e)
		{
			GridSignInEmailInfo.Visibility = Visibility.Visible;
		}

		private void ButtonSignInOpenTelephoneInfo_Click(object sender, RoutedEventArgs e)
		{
			GridSignInTelephoneInfo.Visibility = Visibility.Visible;
		}

		private void ButtonSignInCloseEmailInfo_Click(object sender, RoutedEventArgs e)
		{
			GridSignInEmailInfo.Visibility = Visibility.Collapsed;
		}

		private void ButtonSignInCloseTelephoneInfo_Click(object sender, RoutedEventArgs e)
		{
			GridSignInTelephoneInfo.Visibility = Visibility.Collapsed;
		}
	}
}
