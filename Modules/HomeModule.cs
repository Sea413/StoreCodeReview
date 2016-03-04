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
      return View["stores.cshtml", AllStores];
      };

      Get["/brands"] = _ => {
      List<Brand> AllBrands = Brand.GetAll();
      return View["brands.cshtml", AllBrands];
      };

      Get["/brand/{id}"] = parameters => {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Brand Selectedbrand = Brand.Find(parameters.id);
      List<Store> allStores = Store.GetAll();
      List<Store> BrandStores = Selectedbrand.GetStores();
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
      Post["brand/add_student"] = _ => {
      Brand selectedBrand = Brand.Find(Request.Form["brand-id"]);
      Store store = Store.Find(Request.Form["store-id"]);
      selectedBrand.AddStore(store);
      List<Brand> Allbrands = Brand.GetAll();
      return View["brands.cshtml", Allbrands];
    };
      Post["store/add_brand"] = _ => {
      Store selectedStore = Store.Find(Request.Form["store-id"]);
      Brand brand = Brand.Find(Request.Form["brand-id"]);
      selectedStore.AddBrand(brand);
      List<Store> AllStores = Store.GetAll();
      return View["stores.cshtml", AllStores];
      };
      
      Post["/stores"] = _ => {
      Store newStore = new Store(Request.Form["store-name"]);
      newStore.Save();
      List<Store> AllStores = Store.GetAll();
      return View["stores.cshtml", AllStores];
      };
//
      Post["/brands"] = _ => {
      Brand newBrand = new Brand(Request.Form["brand-name"]);
      newBrand.Save();
      List<Brand> Allbrands = Brand.GetAll();
      return View["brands.cshtml", Allbrands];
      };
    }
  }
}
