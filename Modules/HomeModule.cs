using System;
using System.Collections.Generic;
using Nancy;
using Nancy.ViewEngines.Razor;

namespace Shoes
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => {
        return View["index.cshtml"];
      };

      Get["/stores"] = _ => {
      List<Store> AllStores = Store.GetAll();
      return View["students.cshtml", AllStores];
      };

      Get["/brands"] = _ => {
      List<Brand> AllBrands = Brand.GetAll();
      return View["brands.cshtml", AllBrands];
      };

      Get["/brand/{id}"] = parameters => {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Brand Selectedbrand = Brand.Find(parameters.id);
      List<Store> allStores = Store.GetAll();
      List<Store> BrandStores = selectedBrand.GetStudents();
      model.Add("brand", Selectedbrand);
      model.Add("allstores", allStores);
      model.Add("brandstore", BrandStores);
      return View["brand.cshtml", model];
      };
      Get["/store/{id}"] = parameters => {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Store SelectedStore = Store.Find(parameters.id);
      List<Brand> allbrands = Brand.GetAll();
      List<Brand> Storesbrands = SelectedStore.GetBrands();
      model.Add("store", SelectedStore);
      model.Add("allbrands", allbrands);
      model.Add("storebrand", Storesbrands);
      return View["store.cshtml", model];
      };
//
//       Post["class/add_student"] = _ => {
//       Class selectedClass = Class.Find(Request.Form["class-id"]);
//       Student student = Student.Find(Request.Form["student-id"]);
//       selectedClass.AddStudent(student);
//       List<Class> AllClasses = Class.GetAll();
//       return View["classes.cshtml", AllClasses];
//     };
//
//       Post["/students"] = _ => {
//       Student newStudent = new Student(Request.Form["student_name"], Request.Form["student_enrollment"]);
//       newStudent.Save();
//       List<Student> AllStudents = Student.GetAll();
//       return View["students.cshtml", AllStudents];
//       };
//
//       Post["/classes"] = _ => {
//       Class newClass = new Class(Request.Form["class_name"], Request.Form["class_code"]);
//       newClass.Save();
//       List<Class> AllClasses = Class.GetAll();
//       return View["classes.cshtml", AllClasses];
//       };
    }
  }
}
