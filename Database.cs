using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using BasketApp.Model;
using SQLite;

namespace BasketApp
{
    class Database
    {
        SQLiteConnection db;
        //string folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

        public Database()
        {
            string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "medicines.db3");
            db = new SQLiteConnection(dbPath);

            //string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "photo_attendance.db3");
            try
            {

                db.CreateTable<BasketModel>();
            }
            catch (Exception e)
            {

            }
        }
        public int insertIntoTable(BasketModel basket1)
        {
            int i = 0;
            try
            {

                bool result = checkIntoTable(basket1.Id);
                //i = db.Insert(med1);
                if (result)
                {
                    updateIntoTable(basket1);
                    return i;
                }
                else
                {
                    BasketModel basket = new BasketModel();
                    basket.Type = basket1.Type;
                    basket.Id = basket1.Id;
                    basket.Name = basket1.Name;
                    basket.OriginalPrice = basket1.OriginalPrice;
                    basket.NewPrice = basket1.NewPrice;
                    basket.Quant = basket1.Quant;
                    i = db.Insert(basket);
                    return i;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return 0;
            }
        }

        public bool checkIntoTable(Int64 id)
        {
            try
            {
                var check = db.Query<BasketModel>("SELECT * FROM MedicineTable Where Id = " + id);

                if (check.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }

        public int InsertMedicineList(BasketModel med)
        {
            int i = 0;
            try
            {
                var data1 = db.Query<BasketModel>("SELECT * from [MedicineTable] where [Id]=" + med.Id);
                if (data1.Count <= 0)
                {
                    BasketModel tbl = new BasketModel();
                    tbl.Id = med.Id;
                    tbl.Type = med.Type;
                    tbl.Name = med.Name;
                    tbl.OriginalPrice = med.OriginalPrice;
                    tbl.NewPrice = med.NewPrice;
                    tbl.Quant = 0;
                    i = db.Insert(tbl);
                }
                return i;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public List<BasketModel> getMedicineData()
        {
            //List<MedicineListMaster> data = new List<MedicineListMaster>();
            try
            {
                var data1 = db.Query<BasketModel>("SELECT * FROM MedicineTable");
                return data1;
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return null;
            }
        }
        public Int64 DeleteEntry(Int64 id)
        {
            try
            {
                var data1 = db.Delete<BasketModel>("SELECT * FROM MedicineTable Where Id = " + id);
                return data1;
            }
            catch
            {
                return 0;
            }

        }
        public Int64 updateIntoTable(BasketModel basket1)
        {

            try
            {
                var data = db.Table<BasketModel>();

                var data1 = (from values in data
                             where values.Id == basket1.Id
                             select values).FirstOrDefault();
                data1.Quant = basket1.Quant;

                long i = db.Update(data1);
                return i;
            }
            catch (Exception ex)
            {
                return 0;

            }
        }
    }
}