using System.Collections.Generic;
using System.Data.SqlClient;
using System;

namespace Shoes
{
  public class Store
  {
    private int _id;
    private string _name;

    public Store(string Name, int Id = 0)
    {
      _id = Id;
      _name = Name;
    }

  public override bool Equals(System.Object OtherStore)
  {
    if (!(OtherStore is Store))
    {
      return false;
    }
    else {
      Store newStore = (Store) OtherStore;
      bool idEquality = this.GetId() == newStore.GetId();
      bool nameEquality = this.GetName() == newStore.GetName();
      return (idEquality && nameEquality);
    }
  }

  public int GetId()
  {
    return _id;
  }
  public string GetName()
  {
    return _name;
  }
  public void SetName(string newName)
  {
    _name = newName;
  }

  public static List<Store> GetAll()
  {
    List<Store> AllStores = new List<Store>{};

    SqlConnection conn = DB.Connection();
    SqlDataReader rdr = null;
    conn.Open();

    SqlCommand cmd = new SqlCommand("SELECT * FROM stores", conn);
    rdr = cmd.ExecuteReader();

    while(rdr.Read())
    {
      int storeId = rdr.GetInt32(0);
      string storeName = rdr.GetString(1);
      Store newStore = new Store(storeName, storeId);
      AllStores.Add(newStore);
    }
    if (rdr != null)
    {
      rdr.Close();
    }
    if (conn != null)
    {
      conn.Close();
    }
    return AllStores;
  }


  public void Save()
  {
    SqlConnection conn = DB.Connection();
    SqlDataReader rdr;
    conn.Open();

    SqlCommand cmd = new SqlCommand("INSERT INTO stores (name) OUTPUT INSERTED.id VALUES (@StoreName)", conn);

    SqlParameter nameParam = new SqlParameter();
    nameParam.ParameterName = "@StoreName";
    nameParam.Value = this.GetName();

    cmd.Parameters.Add(nameParam);

    rdr = cmd.ExecuteReader();

    while(rdr.Read())
    {
      this._id = rdr.GetInt32(0);
    }
    if (rdr != null)
    {
      rdr.Close();
    }
    if (conn != null)
    {
      conn.Close();
    }
  }

  public List<Brand> GetBrands()
  {
    SqlConnection conn = DB.Connection();
    SqlDataReader rdr;
    conn.Open();

    List<Brand> brands = new List<Brand>{};

    SqlCommand cmd = new SqlCommand("SELECT brands.* FROM stores JOIN brands_stores ON (stores.id = brands_stores.store_id) JOIN brands ON (brands_stores.brand_id = brands.id) WHERE stores.id = @BrandId", conn);

    SqlParameter brandIdParameter = new SqlParameter();
    brandIdParameter.ParameterName = "@BrandId";
    brandIdParameter.Value = this.GetId();
    cmd.Parameters.Add(brandIdParameter);

    rdr = cmd.ExecuteReader();

    while(rdr.Read())
    {
      int thisbrandId = rdr.GetInt32(0);
      string brandName = rdr.GetString(1);
      Brand foundBrand = new Brand(brandName, thisbrandId);
      brands.Add(foundBrand);
    }
    if (rdr != null)
    {
      rdr.Close();
    }
    if (conn != null)
    {
      conn.Close();
    }
    return brands;
  }
  public static void DeleteAll()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlCommand cmd = new SqlCommand("DELETE FROM stores;", conn);
      cmd.ExecuteNonQuery();
    }

  public static Store Find(int id)
  {
    SqlConnection conn = DB.Connection();
    SqlDataReader rdr = null;
    conn.Open();

    SqlCommand cmd = new SqlCommand("SELECT * FROM stores WHERE Id = @StoreId", conn);
    SqlParameter storeIdParameter = new SqlParameter();
    storeIdParameter.ParameterName = "@StoreId";
    storeIdParameter.Value = id.ToString();
    cmd.Parameters.Add(storeIdParameter);
    rdr = cmd.ExecuteReader();

    int foundStoreId = 0;
    string foundStoreName = null;

    while(rdr.Read())
    {
      foundStoreId = rdr.GetInt32(0);
      foundStoreName = rdr.GetString(1);
    }
    Store foundStore = new Store(foundStoreName, foundStoreId);

    if (rdr != null)
    {
      rdr.Close();
    }
    if (conn != null)
    {
      conn.Close();
    }
    return foundStore;
  }
  public void AddBrand(Brand newBrand)
  {
    SqlConnection conn = DB.Connection();
    conn.Open();

    SqlCommand cmd = new SqlCommand("INSERT INTO brands_stores (store_id, brand_id) VALUES (@StoreId, @BrandId);", conn);

    SqlParameter brandIdParameter = new SqlParameter();
    brandIdParameter.ParameterName = "@BrandId";
    brandIdParameter.Value = newBrand.GetId();
    cmd.Parameters.Add(brandIdParameter);

    SqlParameter storeIdParameter = new SqlParameter();
    storeIdParameter.ParameterName = "@StoreId";
    storeIdParameter.Value = this.GetId();
    cmd.Parameters.Add(storeIdParameter);

    cmd.ExecuteNonQuery();

    if (conn != null)
    {
      conn.Close();
    }
  }

  public void UpdateStore(string newName)
  {
    SqlConnection conn = DB.Connection();
    SqlDataReader rdr;
    conn.Open();

    SqlCommand cmd = new SqlCommand("UPDATE stores SET name = @NewName OUTPUT INSERTED.name WHERE id = @StoreId;", conn);

    SqlParameter newNameParameter = new SqlParameter();
    newNameParameter.ParameterName = "@NewName";
    newNameParameter.Value = newName;
    cmd.Parameters.Add(newNameParameter);


    SqlParameter StoreIdParameter = new SqlParameter();
    StoreIdParameter.ParameterName = "@StoreId";
    StoreIdParameter.Value = this.GetId();
    cmd.Parameters.Add(StoreIdParameter);
    rdr = cmd.ExecuteReader();

    while(rdr.Read())
    {
      this._name = rdr.GetString(0);
    }

    if (rdr != null)
    {
      rdr.Close();
    }

    if (conn != null)
    {
      conn.Close();
    }
  }

  public void DeleteStore()
  {
    SqlConnection conn = DB.Connection();
    conn.Open();

    SqlCommand cmd = new SqlCommand("DELETE FROM stores WHERE id = @StoreId; DELETE FROM brands_stores WHERE store_id = @StoreId;", conn);
    SqlParameter storeIdParameter = new SqlParameter();
    storeIdParameter.ParameterName = "@StoreId";
    storeIdParameter.Value = this.GetId();

    cmd.Parameters.Add(storeIdParameter);
    cmd.ExecuteNonQuery();

    if (conn != null)
    {
      conn.Close();
    }
  }
}
}
