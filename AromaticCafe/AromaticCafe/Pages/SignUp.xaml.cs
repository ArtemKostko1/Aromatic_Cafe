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
	/// Логика взаимодействия для SignUp.xaml
	/// </summary>
	public partial class SignUp : Page
	{
		public SignUp()
		{
			InitializeComponent();
		}

		private void ButtonHeperlinkSignIn_Click(object sender, RoutedEventArgs e)  //переход на окно входа
		{
			Frames.frame.Content = new SignIn();
		}

		private void ButtonSignUp_Click(object sender, RoutedEventArgs e) //обработчик нажатия кнопки "Submit"
		{
			if (TextBoxSignUpName.Text != "" & TextBoxSignUpEmail.Text != "" & TextBoxSignUpTelephone.Text != "") //проверка на пустые поля ввода
			{
				bool checkEmail = false;
				bool checkTelephone = false;

				if (!Regex.IsMatch(TextBoxSignUpEmail.Text, @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +     //валидация E-mail
															@"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$", 
															RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250))) 
				{
					checkEmail = false;
				}
				else
					checkEmail = true;

				if (!Regex.IsMatch(TextBoxSignUpTelephone.Text, @"^(\s*)?(\+)?([- _():=+]?\d[- _():=+]?){11,13}(\s*)$"))  //валидация телефона
				{
					checkTelephone = false;
				}
				else
					checkTelephone = true;

				if (checkEmail)
				{
					if(checkTelephone)
					{
						using (AromaticCafeDBContext context = new AromaticCafeDBContext())
						{
							var users = context.Users.ToList();
							bool checkUser = true;

							foreach (User u in users)
							{
								if (u.UserEmail == TextBoxSignUpEmail.Text | u.UserTelephone == TextBoxSignUpTelephone.Text)  //проверка на наличие такого пользователя в базе
								{
									checkUser = false;
									break;
								}
								else
									checkUser = true;
							}

							if (checkUser)  //добавление нового пользователя в базу
							{
								User user = new User();
								user.UserName = TextBoxSignUpName.Text;
								user.UserEmail = TextBoxSignUpEmail.Text;
								user.UserTelephone = TextBoxSignUpTelephone.Text;

								context.Users.Add(user);
								context.SaveChanges();

								Frames.frame.Content = new MainPage(user);  //переход на главное окно
							}
							else
								TextBlockError.Text = "This user does exist yet";
						}
					}
					else
						TextBlockError.Text = "Invalid telephone format";
				}
				else
					TextBlockError.Text = "Invalid Email format";
			}
			else
				TextBlockError.Text = "All margins must be completed";
			
		}

		private void ButtonSignUpOpenEmailInfo_Click(object sender, RoutedEventArgs e)
		{
			GridSignUpEmailInfo.Visibility = Visibility.Visible;
		}

		private void ButtonSignUpOpenTelephoneInfo_Click(object sender, RoutedEventArgs e)
		{
			GridSignUpTelephoneInfo.Visibility = Visibility.Visible;
		}

		private void ButtonSignUpCloseEmailInfo_Click(object sender, RoutedEventArgs e)
		{
			GridSignUpEmailInfo.Visibility = Visibility.Collapsed;
		}

		private void ButtonSignUpCloseTelephoneInfo_Click(object sender, RoutedEventArgs e)
		{
			GridSignUpTelephoneInfo.Visibility = Visibility.Collapsed;
		}
	}
}
