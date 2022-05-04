using System;


namespace products1.Model
{
    [Serializable]
    internal class Infoproduct
    {
        public override string ToString()
        {
            return $"\tНазвание продукта: {Name}\n\tСрок годности: {Shelflife}\n\tКалорийность: {Calories}\n\tСтоимость: {Price}";
        }

        public string Name { get; set; }
        public string Shelflife { get; set; }
        public string Calories { get; set; }
        public string Price { get; set; }



        public Infoproduct(string name, string calories, string price, string shelflife)
        {
            Name = name;
            Calories = calories;
            Price = price;
            Shelflife = shelflife;
        }
    }
}
