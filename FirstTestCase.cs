using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;


namespace Madison_Island_Proyecto
{
    internal class FirstTestCase
    {
        private IWebDriver driver;

        public void Login()
        {
            driver = new ChromeDriver();
            driver.Url = "http://demo-store.seleniumacademy.com/customer/account/login/";

            IWebElement emailInput = driver.FindElement(By.CssSelector("#email"));
            emailInput.SendKeys("jorgeluisalmanzar7@gmail.com");

            IWebElement passwordInput = driver.FindElement(By.CssSelector("#pass"));
            passwordInput.SendKeys("12345678");

            // Haz clic en el botón de inicio de sesión
            IWebElement loginButton = driver.FindElement(By.CssSelector("#send2"));
            loginButton.Click();

            By selector = By.CssSelector("body > div.wrapper > div.page > div.main-container.col2-left-layout > div > div.col-main > div.my-account > div > div.welcome-msg > p.hello");

            try
            {
                // Intenta encontrar el elemento
                IWebElement element = driver.FindElement(selector);
                Console.WriteLine("Se hizo el login correctamente");
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("No se hizo el login correctamente ");
            }

        }

        //Como no se puede repetir los correos creé este generador de correo random, así cada vez que se corra la prueba no falle porque ya el correo fue utilizado en otra prueba
        public static string GenerarCorreoElectronico()
        {
            string dominio = "@example.com";
            string caracteres = "abcdefghijklmnopqrstuvwxyz0123456789";
            Random random = new Random();
            string correo = "";

            for (int i = 0; i < 10; i++)
            {
                correo += caracteres[random.Next(caracteres.Length)];
            }

            correo += dominio;

            return correo;
        }
        public void Register()
        {


            driver = new ChromeDriver();
            driver.Url = "http://demo-store.seleniumacademy.com/customer/account/create/";

            IWebElement FirstNameInput = driver.FindElement(By.CssSelector("#firstname"));
            FirstNameInput.SendKeys("example1@example.com");

            IWebElement MiddleNameInput = driver.FindElement(By.CssSelector("#middlename"));
            MiddleNameInput.SendKeys("Pedro");

            IWebElement LastNameInput = driver.FindElement(By.CssSelector("#lastname"));
            LastNameInput.SendKeys("Almonte");

            //Aquí uso el correo random
            string correoElectronico = GenerarCorreoElectronico();

            IWebElement EmailInput = driver.FindElement(By.CssSelector("#email_address"));
            EmailInput.SendKeys(correoElectronico);

            IWebElement PasswordInput = driver.FindElement(By.CssSelector("#password"));
            PasswordInput.SendKeys("password123");

            IWebElement ConfPasswordInput = driver.FindElement(By.CssSelector("#confirmation"));
            ConfPasswordInput.SendKeys("password123");

            // Haz clic en el botón de registro
            IWebElement RegisterButton = driver.FindElement(By.CssSelector("#form-validate > div.buttons-set > button"));
            RegisterButton.Click();

            // Recargar la página, porque el proveedor está dando un error.
            driver.Navigate().Refresh();

            By selector = By.CssSelector("body > div.wrapper > div.page > div.main-container.col2-left-layout > div > div.col-main > div.my-account > div > ul > li > ul > li > span");

            try
            {
                // Intenta encontrar el elemento
                IWebElement element = driver.FindElement(selector);
                Console.WriteLine("Se hizo el registro correctamente");
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("No se hizo el registro correctamente");
            }

        }

        public static void Main(string[] args)
        {
            FirstTestCase testCase = new FirstTestCase();
            testCase.Login();
            testCase.Register();
        }
    }
}
