using System.Collections.Generic;
using System.Data.SqlClient;
using System;

namespace Shoes
{
  public class Brand
  {
    private int _id;
    private string _name;


    public Brand(string Name, int Id = 0)
    {
      _id = Id;
      _name = Name;
    }

    public override bool Equals(System.Object otherBrand)
    {
        if (!(otherBrand is Brand))
        {
          return false;
        }
        else
        {
          Brand newBrand = (Brand) otherBrand;
          bool idEquality = this.GetId() == newBrand.GetId();
          bool nameEquality = this.GetName() == newBrand.GetName();
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

    public void AddStore(Student newStore)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("INSERT INTO stores_brands (brand_id, store_id) VALUES (@BrandId, @StoreId)", conn);
      SqlParameter brandIdParameter = new SqlParameter();
      brandIdParameter.ParameterName = "@BrandId";
      brandIdParameter.Value = this.GetId();
      cmd.Parameters.Add(brandIdParameter);

      SqlParameter brandIdParameter = new SqlParameter();
      brandIdParameter.ParameterName = "@StoreId";
      brandIdParameter.Value = newStudent.GetId();
      cmd.Parameters.Add(brandIdParameter);

      cmd.ExecuteNonQuery();

      if (conn != null)
      {
        conn.Close();
      }
    }
    public static List<Brand> GetAll()
    {
      List<Brand> allBrands = new List<Brand>{};

      SqlConnection conn = DB.Connection();
      SqlDataReader rdr = null;
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM brands;", conn);
      rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        int brandId = rdr.GetInt32(0);
        string brandName = rdr.GetString(1);
        Brand newBrand = new Brand(brandId, brandName);
        allBrands.Add(newBrand);
      }

      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }

      return allBrands;
    }

    public void Save()
    {
      SqlConnection conn = DB.Connection();
      SqlDataReader rdr;
      conn.Open();

      SqlCommand cmd = new SqlCommand("INSERT INTO brands (name) OUTPUT INSERTED.id VALUES (@brandName)", conn);

      SqlParameter nameParameter = new SqlParameter();
      nameParameter.ParameterName = "@brandName";
      nameParameter.Value = this.GetName();
      cmd.Parameters.Add(nameParameter);

      rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        this._id = rdr.GetInt32(0);
      }
      if (rdr != null)
      {
        rdr.Close();
      }
      if(conn != null)
      {
        conn.Close();
      }
    }

    public static void DeleteAll()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlCommand cmd = new SqlCommand("DELETE FROM brands;", conn);
      cmd.ExecuteNonQuery();
    }

    public static Brand Find(int id)
    {
      SqlConnection conn = DB.Connection();
      SqlDataReader rdr = null;
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM brands WHERE id = @BrandId;", conn);
      SqlParameter BrandIdParameter = new SqlParameter();
      BrandIdParameter.ParameterName = "@BrandId";
      BrandIdParameter.Value = id.ToString();
      cmd.Parameters.Add(BrandIdParameter);
      rdr = cmd.ExecuteReader();

      int foundBrandId = 0;
      string foundBrandName = null;

      while(rdr.Read())
      {
        foundBrandId = rdr.GetInt32(0);
        foundBrandName = rdr.GetString(1);
      }
      Brand foundBrand = new Class(foundBrandName, foundBrandId);

      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
      return foundBrand;
    }
    public List<Store> GetStores()
    {
      SqlConnection conn = DB.Connection();
      SqlDataReader rdr = null;
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT store_id FROM stores_brands WHERE brand_id = @BrandId;", conn);
      SqlParameter BrandIdParameter = new SqlParameter();
      BrandIdParameter.ParameterName = "@BrandId";
      BrandIdParameter.Value = this.GetId();
      cmd.Parameters.Add(BrandIdParameter);

      rdr = cmd.ExecuteReader();

      List<int> storeIds = new List<int> {};
      while(rdr.Read())
      {
        int storeId = rdr.GetInt32(0);
        storeIds.Add(storeId);
      }
      if (rdr != null)
      {
        rdr.Close();
      }

      List<Store> stores = new List<Store> {};
      foreach (int storeId in storesIds)
      {
        SqlDataReader queryReader = null;
        SqlCommand studentQuery = new SqlCommand("SELECT * FROM stores WHERE id = @StoreId;", conn);

        SqlParameter storeIdParameter = new SqlParameter();
        storeIdParameter.ParameterName = "@StoreId";
        storeIdParameter.Value = studentId;
        studentQuery.Parameters.Add(storeIdParameter);

        queryReader = studentQuery.ExecuteReader();
        while(queryReader.Read())
        {
              int thisStoreID = queryReader.GetInt32(0);
              string storeName = queryReader.GetString(1);
              Store foundStore = new Store(storeName, thisStoreID);
              stores.Add(foundStore);
        }
        if (queryReader != null)
        {
          queryReader.Close();
        }
      }
      if (conn != null)
      {
        conn.Close();
      }
      return stores;
    }
    public void Update(string newName)
    {
      SqlConnection conn = DB.Connection();
      SqlDataReader rdr;
      conn.Open();

      SqlCommand cmd = new SqlCommand("UPDATE brands SET name = @NewName OUTPUT INSERTED.name WHERE id = @BrandId;", conn);

      SqlParameter newNameParameter = new SqlParameter();
      newNameParameter.ParameterName = "@NewName";
      newNameParameter.Value = newName;
      cmd.Parameters.Add(newNameParameter);


      SqlParameter BrandIdParameter = new SqlParameter();
      BrandIdParameter.ParameterName = "@BrandId";
      BrandIdParameter.Value = this.GetId();
      cmd.Parameters.Add(BrandIdParameter);
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
    public void Delete()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("DELETE FROM brands WHERE id = @BrandId; DELETE FROM stores_brands WHERE brand_id = @BrandId;", conn);
      SqlParameter brandIdParameter = new SqlParameter();
      brandIdParameter.ParameterName = "@BrandId";
      brandIdParameter.Value = this.GetId();

      cmd.Parameters.Add(brandIdParameter);
      cmd.ExecuteNonQuery();

      if (conn != null)
      {
        conn.Close();
      }
    }
  }
}
