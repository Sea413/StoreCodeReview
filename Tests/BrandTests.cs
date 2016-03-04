using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Shoes
{
  public class BrandTest : IDisposable
  {
    public BrandTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=Athens_Shoes_Test;Integrated Security=SSPI;";
    }

    [Fact]
    public void Test_BrandEmptyAtFirst()
    {
      int result = Brand.GetAll().Count;
      Assert.Equal(0, result);
    }

    [Fact]
    public void Test_BrandReturnTrueForSameName()
    {
      Brand firstBrand = new Class("Aisa");
      Brand secondBrand = new Class("Aisa");
      Assert.Equal(firstBrand, secondBrand);
    }


        [Fact]
    public void Test_Save_SavesBrandToDatabase()
    {
      //Arrange
      Brand testBrand = new Class("Aletheia");
      testBrand.Save();

      //Act
      List<Brand> result = Brand.GetAll();
      List<Brand> testList = new List<Brand>{testBrand};

      //Assert
      Assert.Equal(testList, result);
    }


    [Fact]
    public void Test_Save_AssignsIdToBrandObject()
    {
      //Arrange
      Brand testBrand = new Brand("Caerus");
      testBrand.Save();

      //Act
      Brand savedBrand = Brand.GetAll()[0];
      int result = savedBrand.GetId();
      int testId = savedBrand.GetId();

      //Assert
      Assert.Equal(testId, result);
    }

    [Fact]
    public void Test_Find_FindsBrandInDatabase()
    {
      //Arrange
      Brand testBrand = new Brand("Alala");
      testBrand.Save();

      //Act
      Brand foundBrand = Brand.Find(testBrand.GetId());

      //Assert
      Assert.Equal(testBrand, foundBrand);
    }

        [Fact]
        public void Test_AddStore_AddsaStoretoBrand()
        {
          //Arrange
          Brand testBrand = new Brand("Orion");
          testBrand.Save();

          Store testStore = new Student("Talos Boots");
          testBrand.Save();

          Store testStore2 = new Store("Geryon Sandals");
          testStore2.Save();

          //Act
          testBrand.AddStore(testStore);
          testBrand.AddStore(testStore2);;

          List<Store> result = testBrand.GetStudents();
          List<Store> testList = new List<Store>{testStore, testStore2};

          //Assert
          Assert.Equal(testList, result);
        }

        [Fact]
        public void Test_GetStores_ReturnsAllBrandStores()
        {
          //Arrange
          Brand testBrand = new Brand("Agon");
          testClass.Save();

          Store testStore1 = new Store("Alke Sleek Slippers");
          testStore1.Save();

          // Student testStudent2 = new Student("Sean Peerenboom", new DateTime (2009,10,01));
          // testStudent2.Save();

          //Act
          testBrand.AddStore(testStore1);
          List<Store> savedStore = testBrand.GetStores();
          List<Store> testList = new List<Store> {testStore1};

          //Assert
          Assert.Equal(testList, savedStudents);
        }
      public void Test_Getbrands_ReturnsAllStorebrands()
      {
      //Arrange
      Store testStore = new Store("Ate's Vanity");
      testStore.Save();

      Brand testBrand1 = new Brand("Bia");
      testBrand1.Save();

      Brand testBrand2 = new Brand("Deimos");
      testBrand2.Save();

      //Act
      testStore.AddBrand(testBrand1);
      List<Brand> result = testStore.GetBrands();
      List<Brand> testList = new List<Brand> {testBrand1};

      //Assert
      Assert.Equal(testList, result);
    }
    [Fact]
        public void Test_Delete_DeletesbrandAssociationsFromDatabase()
        {
          //Arrange
          Store testStore = new Store("Eirene Birkenstocks");
          testStore.Save();

          string testName = "Eirene Birkenstocks";
          Brand testBrand = new Brand(testName);
          testBrand.Save();

          //Act
          testBrand.AddStore(testStore);
          testBrand.Delete();

          List<Brand> resultstorebrand = testStore.GetBrands();
          List<Brand> teststoreBrand = new List<Brand> {};

          //Assert
          Assert.Equal(teststoreBrand, resultstorebrand);
        }
    [Fact]
    public void Test_Delete_DeletesbrandFromDatabase()
    {
      //Arrange
      string name1 = "Penia";
      Brand testBrand1 = new Brand(name1);
      testBrand1.Save();

      string name2 = "Thrasos";
      Brand testBrand2 = new Brand(name2);
      testBrand2.Save();

      //Act
      testBrand1.Delete();
      List<Brand> resultBrand = Brand.GetAll();
      List<Brand> testBrandList = new List<Brand> {testBrand2};

      //Assert
      Assert.Equal(resultBrand, testBrandList);
    }

      [Fact]
        public void Dispose()
        {
          Store.DeleteAll();
          Brand.DeleteAll();
        }
      }
    }
