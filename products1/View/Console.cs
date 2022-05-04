using System;
using products1.Controller;

namespace products1.View
{
    internal class Console
    {

        private Controller.addproduct products;

        public Console(string path)
        {
            try
            {
                products = new addproduct(path);
                consolepusk();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }

        private void consolem()
        {
            System.Console.WriteLine("commands - список команд");
            System.Console.WriteLine("listproduct - список продуктов");
            System.Console.WriteLine("addproduct - добавить продукты");
            System.Console.WriteLine("exit - завершить ");
        }

        public void consolepusk()
        {
            consolem();
            while (true)
            {
                try
                {
                    switch (Consolestart("Введите команду...").ToLower())
                    {
                        case "commands": consolem(); break;
                        case "listproduct": Listproduct(); break;
                        case "addproduct": AddProduct(); break;
                        case "exit": Environment.Exit(0); break;
                        default:
                            System.Console.WriteLine("неверная команда"); break;
                    }
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
            }
        }

        private void AddProduct()
        {
            string name = Consolestart("Укажите название продукта");
            string calories = Consolestart("Укажите калорийность (например - \"200 ккал\")");
            string price = Consolestart("Укажите стоимость данного продукта (например - \"130 рублей за 1 шт.\")");
            string shelflife = Consolestart("Укажите срок годности продукта (например - \"10.03.2021 - 10.04.2021\")");

            products.Add(name, calories, price, shelflife);
            System.Console.WriteLine("продукт успешно добавлен");
            Listproduct();
        }

        private void Listproduct()
        {
            if (products.Products.Count == 0)
            {
                System.Console.WriteLine("Информации о продукте отсутствует");
                return;
            }

            foreach (var item in products.Products)
            {
                System.Console.WriteLine(item);
            }
        }

        private string Consolestart(string v)
        {
            System.Console.WriteLine(v);
            var s = System.Console.ReadLine();
            if (string.IsNullOrWhiteSpace(s))
            {
                System.Console.WriteLine("некоректный ввод");
                return Consolestart(v);
            }
            return s.TrimStart().TrimEnd();
        }
    }
}