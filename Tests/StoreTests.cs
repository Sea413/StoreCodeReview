using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Shoes
{
  public class StoreTest : IDisposable
  {
    public StoreTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=Athens_Shoes_Test;Integrated Security=SSPI;";
    }

    [Fact]
    public void Test_EmptyAtFirst()
    {
      //Arrange, Act
      int result = Store.GetAll().Count;

      //Assert
      Assert.Equal(0, result);
    }

    [Fact]
    public void Test_EqualOverrideTrueForSameName()
    {
      //Arrange, Act
      Store firstStore = new Store("Achilles Shoes");
      Store secondStore = new Store("Achilles Shoes");

      //Assert
      Assert.Equal(firstStore, secondStore);
    }

    [Fact]
    public void Test_Save()
    {
      //Arrange
      Store testStore = new Store("Hermes Shoeware");
      testStore.Save();

      //Act
      List<Store> result = Store.GetAll();
      List<Store> testList = new List<Store>{testStore};

      //Assert
      Assert.Equal(testList, result);
    }



    [Fact]
    public void Test_SaveAssignsIdToObject()
    {
      //Arrange
      Store testStore = new Store("Gregor Samsa Footwear");
      testStore.Save();

      //Act
      Store savedStore = Store.GetAll()[0];

      int result = savedStore.GetId();
      int testId = testStore.GetId();

      //Assert
      Assert.Equal(testId, result);
    }

    [Fact]
    public void Test_FindFindsStudentInDatabase()
    {
      //Arrange
      Store testStore = new Store("Wang Lung's stylish apparel");
      testStore.Save();

      //Act
      Store result = Store.Find(testStore.GetId());

      //Assert
      Assert.Equal(testStore, result);
    }

    [Fact]
public void Test_AddBrand_AddsBrandtoStore()
{
  //Arrange
  Store testStore = new Store("Soter's Clogs");
  testStore.Save();

  Brand testBrand = new Brand("Polemos");
  testBrand.Save();

  //Act
  testStore.AddBrand(testBrand);

  // foreach (var store in Brand.GetAll()) {
  //       Console.WriteLine(course.GetName());
  // }

  List<Brand> result = testStore.GetBrands();
  List<Brand> testList = new List<Brand>{testBrand};

  //Assert
  Assert.Equal(testList, result);
}

  [Fact]
  public void Test_Getbrands_ReturnsAllStorebrands()
  {
    //Arrange
    Store testStore = new Store("Charon Boating Shoes");
    testStore.Save();

    Brand testBrand1 = new Brand("Aiakos");
    testBrand1.Save();

    Brand testBrand2 = new Brand("Minos");
    testBrand2.Save();

    //Act
    testStore.AddBrand(testBrand1);
    List<Brand> result = testStore.GetBrands();
    List<Brand> testList = new List<Brand> {testBrand1};

    //Assert
    Assert.Equal(testList, result);
  }

  public void Test_Delete_DeletesStoreAssociationsFromDatabase()
  {
    //Arrange
    Brand testBrand = new Brand("Ceto");
    testBrand.Save();

    string testName = "Aurai Breeze Shoes";
    Store testStore = new Store(testName);
    testStore.Save();

    //Act
    testStore.AddBrand(testBrand);
    testStore.Delete();

    List<Store> resultBrandStore = testBrand.GetStores();
    List<Store> testbrandStore = new List<Store> {};

    //Assert
    Assert.Equal(resultBrandStore, testbrandStore);
  }


    public void Dispose()
    {
      Store.DeleteAll();
      Brand.DeleteAll();
    }
  }
}
