using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using products1.Model;

namespace products1.Controller
{
    internal class addproduct
    {
        public List<Infoproduct> Products { get; set; }
        private string _path;
        public addproduct(string path)
        {
            _path = path;
            Products = gProduct();
        }
        public void file()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                using (FileStream fs = new FileStream(_path, FileMode.OpenOrCreate))
                {
                    formatter.Serialize(fs, Products);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private List<Infoproduct> gProduct()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                using (FileStream fs = new FileStream(_path, FileMode.OpenOrCreate))
                {
                    List<Infoproduct> rec = formatter.Deserialize(fs) as List<Infoproduct>;
                    fs.Close();
                    if (rec != null)
                        return rec;
                    else
                        return new List<Infoproduct>();
                }
            }
            catch (SerializationException)
            {
                return new List<Infoproduct>();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Add(string name, string calories, string price, string shelflife)
        {
            Products.Add(new Infoproduct(name, calories, price, shelflife));
            try
            {
                file();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}