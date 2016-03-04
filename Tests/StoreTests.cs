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
public void Test_AddClass_AddsClassToStudent()
{
  //Arrange
  Store testStore = new Store("Adin Moon",new DateTime (2009,10,01));
  testStore.Save();

  Class testClass = new Class("Seahorse Riding", "SEA2008");
  testClass.Save();

  //Act
  testStudent.AddClass(testClass);

  foreach (var course in Class.GetAll()) {
        Console.WriteLine(course.GetName());
  }

  List<Class> result = testStudent.GetClasses();
  List<Class> testList = new List<Class>{testClass};

  //Assert
  Assert.Equal(testList, result);
}

  [Fact]
  public void Test_GetCategories_ReturnsAllStudentCategories()
  {
    //Arrange
    Student testStudent = new Student("Zach Quinto",new DateTime (2009,10,01));
    testStudent.Save();

    Class testClass1 = new Class("William James", "Phil008");
    testClass1.Save();

    Class testClass2 = new Class("Zach Quinto", "Phil1009");
    testClass2.Save();

    //Act
    testStudent.AddClass(testClass1);
    List<Class> result = testStudent.GetClasses();
    List<Class> testList = new List<Class> {testClass1};

    //Assert
    Assert.Equal(testList, result);
  }

  public void Test_Delete_DeletesStudentAssociationsFromDatabase()
  {
    //Arrange
    Class testClass = new Class("Barrel Slinging", "Gears2001");
    testClass.Save();

    string testDescription = "David Phil";
    DateTime testcompletion = new DateTime (2009,10,01);
    Student testStudent = new Student(testDescription, testcompletion);
    testStudent.Save();

    //Act
    testStudent.AddClass(testClass);
    testStudent.Delete();

    List<Student> resultClassStudents = testClass.GetStudents();
    List<Student> testClassStudents = new List<Student> {};

    //Assert
    Assert.Equal(testClassStudents, resultClassStudents);
  }


    public void Dispose()
    {
      Store.DeleteAll();
      Brand.DeleteAll();
    }
  }
}
