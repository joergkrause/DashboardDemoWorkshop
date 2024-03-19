using DataAccessLayer;
using DomainModels;
using Microsoft.EntityFrameworkCore;

namespace DatabaseSchemaTests
{
  [TestClass]
  public class IntegrationTestsDb
  {

    DashboardContext context;

    [TestInitialize]
    public void Init()
    {
      var options = new DbContextOptionsBuilder<DashboardContext>()
        .UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=AkgDashboardDbTest;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False")
        .Options;
      context = new DashboardContext(options);

      context.Database.EnsureDeleted();
      context.Database.EnsureCreated();
    }

    [TestCleanup]
    public void Cleanup()
    {
      // context.Database.EnsureDeleted();
    }

    [TestMethod]
    public async Task DashboardAdd_Success()
    {
      var dashboard = new DomainModels.Dashboard
      {
        Name = "Test Dashboard",
        Active = true
      };

      context.Set<Dashboard>().Add(dashboard);
      await context.SaveChangesAsync();

      var result = await context.Set<Dashboard>().FindAsync(dashboard.Id);
      Assert.IsNotNull(result);
      Assert.AreEqual(dashboard.Name, result.Name);
    }

    [TestMethod]
    public async Task DashboardAdd_Fail_NameToLong()
    {
      var dashboard = new DomainModels.Dashboard
      {
        Name = "Test Dashboard _ MORE than 64 Chars _ MORE than 64 Chars _ MORE than 64 Chars",
        Active = true
      };

      context.Set<Dashboard>().Add(dashboard);
      await Assert.ThrowsExceptionAsync<DbUpdateException>(() => context.SaveChangesAsync());
    }
  }
}