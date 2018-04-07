using System;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace Lottoland.Model
{
    public class RegisterPage
    {
        [FindsBy(How = How.Id, Using = "name_3_firstname")]
        private IWebElement FirstName { get; set; }

        [FindsBy(How = How.Id, Using = "name_3_lastname")]
        private IWebElement LastName { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='radio_wrap']/input[@type='checkbox']")]
        private IList<IWebElement> Hobby { get; set; }

        [FindsBy(How = How.Id, Using = "phone_9")]
        private IWebElement PhoneNo { get; set; }

        [FindsBy(How = How.Id, Using = "username")]
        private IWebElement UserName { get; set; }

        [FindsBy(How = How.Id, Using = "email_1")]
        private IWebElement EmailAddress { get; set; }

        [FindsBy(How = How.Id, Using = "password_2")]
        private IWebElement Password { get; set; }

        [FindsBy(How = How.Id, Using = "confirm_password_password_2")]
        private IWebElement PasswordConfirm { get; set; }

        [FindsBy(How = How.Name, Using = "pie_submit")]
        private IWebElement SubmitButton { get; set; }

        [FindsBy(How = How.Id, Using = "piereg_passwordStrength")]
        private IWebElement PasswordStrength { get; set; }

        public void InitElements()
        {
            PageFactory.InitElements(this, new RetryingElementLocator(Helpers.DriverHelper.GetDriver(), TimeSpan.FromSeconds(20)));
        }

        public bool PageUrlIsValid()
        {
            return Helpers.DriverHelper.GetPageUrl().Equals(Helpers.ConfigHelper.GetTestPageUrl());
        }

        public bool RegisterUser(string firtsName, string lastName)
        {
            try
            {
                SetFirstName(firtsName);
                SetLastName(lastName);
                SetRandomHobby();
                SetRandomPhoneNo();
                SetRandomUserName();
                SetRandomEmailAddress();
                SetRandomPassword();
                PasswordStrength.Click();

                if (Helpers.DriverHelper.ElementExist(@"//*[@class='legend error']"))
                    return false;

                SubmitButton.Click();

                return Helpers.DriverHelper.ElementExist(@"//*[@class='piereg_message']");
            }
            catch (Exception)
            {
                return false;
            }

        }

        private void SetFirstName(string fName)
        {
            FirstName.Clear();
            FirstName.SendKeys(fName);
        }

        private void SetLastName(string lName)
        {
            LastName.Clear();
            LastName.SendKeys(lName);
        }

        private void SetRandomHobby()
        {
            foreach(var checkbox in Hobby)
            {
                if (checkbox.Selected)
                {
                    checkbox.Click();
                }
            }

            Hobby[Data.RandomValuesGenerator.RandomNumberFromRange(0, Hobby.Count - 1)].Click();
        }

        private void SetRandomPhoneNo()
        {
            PhoneNo.Clear();
            PhoneNo.SendKeys(Data.RandomValuesGenerator.RandomNumber(10));
        }

        private void SetRandomUserName()
        {
            UserName.Clear();
            UserName.SendKeys(Data.RandomValuesGenerator.RandomString(8));
        }

        private void SetRandomEmailAddress()
        {
            EmailAddress.Clear();
            EmailAddress.SendKeys(Data.RandomValuesGenerator.GenerateRandomEmailAddress());
        }

        private void SetRandomPassword()
        {
            var randomPass = Data.RandomValuesGenerator.RandomString(8);
            Password.Clear();
            PasswordConfirm.Clear();
            Password.SendKeys(randomPass);
            PasswordConfirm.SendKeys(randomPass);
        }
    }
}
