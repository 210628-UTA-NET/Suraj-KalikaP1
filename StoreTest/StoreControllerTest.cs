using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;
using StoreModel;
using StoreBL;
using Microsoft.AspNetCore.Mvc;
using StoreWebUI.Controllers;
using StoreWebUI.Models;
namespace StoreTest
{
    public class StoreControllerTest
    {
        [Fact]
        public void IndexActionShouldReturnRestaurantList()
        {
            //Arrange
            var mockBL = new Mock<IStoreFrontBL>();
            mockBL.Setup(storeBL => storeBL.GetAllStoreFronts()).Returns
            (
                new List<StoreFront>
                {
                    new StoreFront(){ Name = "Yugioh Cards Store"},
                    new StoreFront(){ Name = "Dungeon Dice Monsters Store"}
                }
            );

            var storeController = new StoreController(mockBL.Object);

            //Act
            var result = storeController.Index();

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<StoreFrontViewModel>>(viewResult.ViewData.Model);

            Assert.Equal(2, model.Count());
        }
    }
}
