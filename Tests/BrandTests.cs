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
      Student testStudent = new Student("Veronica Alley", new DateTime (2009,10,01));
      testStudent.Save();

      Class testClass1 = new Class("Fiction", "CRWT001");
      testClass1.Save();

      Class testClass2 = new Class("Philosophy", "PHIL002");
      testClass2.Save();

      //Act
      testStudent.AddClass(testClass1);
      List<Class> result = testStudent.GetClasses();
      List<Class> testList = new List<Class> {testClass1};

      //Assert
      Assert.Equal(testList, result);
    }
    [Fact]
        public void Test_Delete_DeletesClassAssociationsFromDatabase()
        {
          //Arrange
          Student testStudent = new Student("Ted Mosley", new DateTime (2009,10,01));
          testStudent.Save();

          string testName = "Ted Mosley";
          Class testClass = new Class(testName,"Gred1001");
          testClass.Save();

          //Act
          testClass.AddStudent(testStudent);
          testClass.Delete();

          List<Class> resultStudentClasses = testStudent.GetClasses();
          List<Class> testStudentClasses = new List<Class> {};

          //Assert
          Assert.Equal(testStudentClasses, resultStudentClasses);
        }
    [Fact]
    public void Test_Delete_DeletesClassFromDatabase()
    {
      //Arrange
      string name1 = "Buddhism";
      Class testClass1 = new Class(name1, "Gred1001");
      testClass1.Save();

      string name2 = "Basket Weaving";
      Class testClass2 = new Class(name2,"Gred1001");
      testClass2.Save();

      //Act
      testClass1.Delete();
      List<Class> resultClasses = Class.GetAll();
      List<Class> testClassList = new List<Class> {testClass2};

      //Assert
      Assert.Equal(testClassList, resultClasses);
    }

      [Fact]
        public void Dispose()
        {
          Student.DeleteAll();
          Class.DeleteAll();
        }
      }
    }
