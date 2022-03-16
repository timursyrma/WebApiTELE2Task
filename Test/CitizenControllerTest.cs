using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Controllers;
using BusinessLogicLayer.DTO;
using BusinessLogicLayer.JsonTool;
using BusinessLogicLayer.Services;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace Tests;

public class CitizenControllerTest
{
    [Test]
    public void GetAllCitizensReturnsAResultWithAListOfCitizens()
    {
        // Arrange
        var mock = new Mock<IRepository>();
        mock.Setup(repo => repo.FindAll("male", 10, 30).Result).Returns(GetTestCitizens());
        var service = new CitizenService(mock.Object);
        var controller = new CitizenController(service);

        // Act
        var result = controller.GetAllCitizens("male", 10, 30);

        // Assert
        Assert.IsInstanceOf<IEnumerable<CitizenModel>>(result);
        Assert.AreEqual(GetTestCitizens().Count, result.ToList().Count);
    }
    
    [Test]
    public void UploadCitizenReturnsCitizensList()
    {
        var citizen1 = GetTestCitizens()[0];
        var citizen2 = GetTestCitizens()[1];
        var citizen3 = GetTestCitizens()[2];
        var citizen4 = GetTestCitizens()[3];
        
        var mock = new Mock<IRepository>();
        mock.Setup(repo => repo.Create(new CitizenModel("qyfgqiyhwfoq1", "Stan Smith", "male", 10)))
            .Returns(citizen1);
        mock.Setup(repo => repo.Create(new CitizenModel("qmvqqwrqsds2", "Jack Anderson", "male", 15)))
            .Returns(citizen2);
        mock.Setup(repo => repo.Create(new CitizenModel("vdhgqvgj3", "Olga Popova", "female", 20)))
            .Returns(citizen3);
        mock.Setup(repo => repo.Create(new CitizenModel("lkqjweiojqiow4", "Erzhena Koroleva", "male", 30)))
            .Returns(citizen4);

        var service = new CitizenService(mock.Object);
        var controller = new CitizenController(service);

        var result = controller.Initialize("http://testlodtask20172.azurewebsites.net/task");
        Assert.AreEqual(GetTestCitizens().Count, result.ToList().Count);
    }
    
    [Test]
    public void GetCitizenReturnsBadRequestResultWhenIdIsNull()
    {
        // Arrange
        var mock = new Mock<IRepository>();
        var service = new CitizenService(mock.Object);
        var controller = new CitizenController(service);
 
        // Act
        var result = controller.Find(null);
 
        // Arrange
        Assert.AreEqual(null, result);
    }
    
    [Test]
    public void GetCitizenReturnsNotFoundResultWhenUserNotFound()
    {
        // Arrange
        string testCitizenId = "asdasdasd";
        var mock = new Mock<IRepository>();
        mock.Setup(repo => repo.FindById(testCitizenId).Result)
            .Returns(null as CitizenModel);
        var service = new CitizenService(mock.Object);
        var controller = new CitizenController(service);
 
        // Act
        var result = controller.Find(testCitizenId);
 
        // Assert
        Assert.AreEqual(null, result);
    }
    
    [Test]
    public void GetCitizenReturnsViewResultWithUser()
    {
        // Arrange
        string testCitizenId = "qyfgqiyhwfoq1";
        var mock = new Mock<IRepository>();
        mock.Setup(repo => repo.FindById(testCitizenId).Result)
            .Returns(GetTestCitizens().FirstOrDefault(c => c.Id == testCitizenId));
        var service = new CitizenService(mock.Object);
        var controller = new CitizenController(service);
 
        // Act
        var result = controller.Find(testCitizenId);
 
        // Assert
        Assert.IsInstanceOf<CitizenModel>(result);
        Assert.AreEqual("qyfgqiyhwfoq1", result.Id);
        Assert.AreEqual("Stan Smith", result.Name);
        Assert.AreEqual("male", result.Sex);
        Assert.AreEqual(30, result.Age);
    }
    private List<CitizenModel> GetTestCitizens()
    {
        var citizens = new List<CitizenModel>
        {
            new CitizenModel("qyfgqiyhwfoq1", "Stan Smith", "male", 30),
            new CitizenModel("qmvqqwrqsds2", "Jack Anderson", "male", 14),
            new CitizenModel("vdhgqvgj3", "Olga Popova", "female", 24),
            new CitizenModel("guyqwhoij6", "Jessica Braemer", "male", 31),
            new CitizenModel("hqwuiehquikxhc5", "Dmitry Vegas", "male", 78),
            new CitizenModel("kjlqwoijeo7", "German Titov", "male", 42),
            new CitizenModel("lkkpokqw8", "Solomon Shlemovich", "male", 41),
            new CitizenModel("lkqjweiojqiow4", "Alex Whitedrinker", "male", 45),
            new CitizenModel("qjIdwojqiowj10", "Erzhena Koroleva", "male", 31),
            new CitizenModel("qmvqqwrqsds2", "Elmo Kennedy", "male", 63),
            new CitizenModel("qyfgqiyhwfoq1", "Jack Anderson", "male", 14),
            new CitizenModel("acmwojeiwqe9", "Anna Titova", "male", 19),
            new CitizenModel("cnoqjpIdjkqpo11", "Sascha Braemer", "male", 11),
        };
        return citizens;
    }
    private List<CitizenMainDto> GetCitizensDto()
    {
        var citizens = new List<CitizenMainDto>
        {
            new CitizenMainDto("qyfgqiyhwfoq1", "Stan Smith", "male"),
            new CitizenMainDto("qmvqqwrqsds2", "Jack Anderson", "male"),
            new CitizenMainDto("vdhgqvgj3", "Olga Popova", "female"),
            new CitizenMainDto("guyqwhoij6", "Jessica Braemer", "male"),
            new CitizenMainDto("hqwuiehquikxhc5", "Dmitry Vegas", "male"),
            new CitizenMainDto("kjlqwoijeo7", "German Titov", "male"),
            new CitizenMainDto("lkkpokqw8", "Solomon Shlemovich", "male"),
            new CitizenMainDto("lkqjweiojqiow4", "Alex Whitedrinker", "male"),
            new CitizenMainDto("qjIdwojqiowj10", "Erzhena Koroleva", "male"),
            new CitizenMainDto("qmvqqwrqsds2", "Elmo Kennedy", "male"),
            new CitizenMainDto("qyfgqiyhwfoq1", "Jack Anderson", "male"),
            new CitizenMainDto("acmwojeiwqe9", "Anna Titova", "male"),
            new CitizenMainDto("cnoqjpIdjkqpo11", "Sascha Braemer", "male"),
        };
        return citizens;
    }
    
}
