using AutoMapper;
using BusinessLogicLayer;
using BusinessLogicLayer.Mappings;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseSchemaTests
{
  [TestClass]
  public class BusinessLayerTests
  {

    private IServiceProvider serviceProvider;

    [TestInitialize]
    public void Init()
    {
      var serviceCollection = new ServiceCollection();

      var dashboardRepositoryMock = new Mock<IDashboardRepository>();

      var fakeData = new List<DomainModels.Dashboard>()
      {
        new () { Id = 1, Name = "Test Dashboard", Active = true },
        new () { Id = 2, Name = "Test Dashboard 2" , Active = true },
      };

      dashboardRepositoryMock.Setup(x => x.GetAll()).ReturnsAsync(fakeData);
      dashboardRepositoryMock.Setup(x => x.GetDashboardsByNameWithWidgets(It.IsAny<string>())).ReturnsAsync(new List<DomainModels.Dashboard>());

      var mapper = new MapperConfiguration(cfg =>
      {
        cfg.AddProfile(new MappingProfile());
      }).CreateMapper();

      serviceCollection.AddTransient<IDashboardRepository>((sp) => dashboardRepositoryMock.Object);
      serviceCollection.AddTransient<IMapper>((sp) => mapper);
      serviceProvider = serviceCollection.BuildServiceProvider();
    }

    [TestMethod]
    public async Task GetDashboards_Success()
    {
      // prepare
      var sut = new DashboardWidgetManager(serviceProvider);

      // act
      var result = await sut.GetDashboards();

      // assert
      Assert.IsNotNull(result);
      Assert.AreEqual(2, result.Count());  
    }
  }
}
