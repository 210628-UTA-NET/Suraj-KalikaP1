using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using StoreModel;
namespace StoreTest
{
    public class StoreModelTest
    {
        [Fact]
        public void NameShouldSetValidData()
        {
            //Arrange
            Customer test = new Customer();
            string name = "Suraj";

            //Act
            test.Name = name;
            //Assert
            Assert.Equal(name, test.Name);
        }

        [Fact]
        public void PhoneNumberShouldSetValidData()
        {   
            //Arrange
            Customer test = new Customer();
            string phoneNum = "1234567890";

            //Act
            test.PhoneNumber = phoneNum;
            //Assert
            Assert.Equal(test.PhoneNumber, phoneNum);
        }

        [Fact]
        public void AddressShouldSetValidData()
        {
            //Arrange
            Customer test = new Customer();
            string Address = "New Address";

            //Act
            test.Address = Address;
            //Assert
            Assert.Equal(test.Address, Address);
        }

        [Fact]
        public void EmailShouldSetValidData()
        {
            //Arrange
            Customer test = new Customer();
            string Email = "email@gmail.com";

            //Act
            test.Email = Email;
            //Assert
            Assert.Equal(test.Email, Email);
        }
    }
}
