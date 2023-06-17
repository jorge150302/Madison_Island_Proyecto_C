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

        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Url = "http://demo-store.seleniumacademy.com/customer/account/login/";
        }

        public void TestLoginCorrect()
        {// Ingresa las credenciales correctas
            IWebElement emailInput = driver.FindElement(By.CssSelector("#email"));
            emailInput.SendKeys("example@example.com");

            IWebElement passwordInput = driver.FindElement(By.CssSelector("#pass"));
            passwordInput.SendKeys("password123");

            // Haz clic en el botón de inicio de sesión
            IWebElement loginButton = driver.FindElement(By.CssSelector("#send2"));
            loginButton.Click();

            By selector = By.CssSelector("body > div.wrapper > div.page > div.main-container.col2-left-layout > div > div.col-main > div.my-account > div > div.welcome-msg > p.hello");

            try
            {
                // Intenta encontrar el elemento
                IWebElement element = driver.FindElement(selector);
                Console.WriteLine("El elemento existe en la página.");
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("El elemento no existe en la página.");
            }

        }

   

        public void TestLoginInvalidPassword()
        {// Ingresa las credenciales correctas
            IWebElement emailInput = driver.FindElement(By.CssSelector("#email"));
            emailInput.SendKeys("example@example.com");

            IWebElement passwordInput = driver.FindElement(By.CssSelector("#pass"));
            passwordInput.SendKeys("password123");

            // Haz clic en el botón de inicio de sesión
            IWebElement loginButton = driver.FindElement(By.CssSelector("#send2"));
            loginButton.Click();


        }

        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }

        public static void Main(string[] args)
        {
            FirstTestCase testCase = new FirstTestCase();
            testCase.Setup();

            // Ejecutar los casos de prueba
            testCase.TestLoginCorrect();
            testCase.TestLoginInvalidPassword();

            testCase.TearDown();
        }
    }
}
 