﻿using Auto.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto
{
    public class Program
    {
       public static Connect conn = new Connect();
       public static List<Car> cars = new List<Car>();

        static void feltolt()
        {
            conn.Connection.Open();
            string sql = "SELECT * FROM `cars`";
            MySqlCommand cmd=new MySqlCommand(sql,conn.Connection);
            MySqlDataReader reader=cmd.ExecuteReader();
            while (reader.Read()){
                Car car = new Car();

                car.Id = reader.GetInt32(0);
                car.Brand = reader.GetString(1);
                car.Type = reader.GetString(2);
                car.License = reader.GetString(3);
                car.Date = reader.GetInt32(4);
                cars.Add(car); }
            conn.Connection.Close();
        }
        public static void addNewCar()
        {
            conn.Connection.Open();
            string brand, type,license;
            int date;
            Console.Write("Kérem az autó márkáját:");
            brand =Console.ReadLine();
            Console.Write("Kérem az autó típusát:");
            type = Console.ReadLine();
            Console.Write("Kérem az autó motorszámát:");
            license = Console.ReadLine();
            Console.Write("Kérem az autó gyártási évét:");
            date=int.Parse(Console.ReadLine());
            string sql = $"INSERT INTO `cars`(`Brand`, `Type`, `License`, `Date`) VALUES ('{brand}','{type}','{license}',{date})";
            MySqlCommand cmd = new MySqlCommand(sql,conn.Connection);
            cmd.ExecuteNonQuery();
           
            conn.Connection.Close();
        }
        public static void upDateCar()
        {
            conn.Connection.Open();
            Console.Write("Kérem az autó azonosítóját: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Kérem az autó gyártási évét: ");
            int date = int.Parse(Console.ReadLine());
            string sql = $"UPDATE `cars` SET `Date`='{date}' WHERE `Id` = {id}";
            MySqlCommand cmd = new MySqlCommand(sql, conn.Connection);
            cmd.ExecuteNonQuery();
            conn.Connection.Close();
        }
        public static void delCar()
        {
            conn.Connection.Open();
            Console.Write("Kérem az autó azonosítóját: ");
            int id = int.Parse(Console.ReadLine());
            string sql = $"DELETE FROM `cars` WHERE `Id` = {id}";
            MySqlCommand cmd = new MySqlCommand(sql, conn.Connection);
            cmd.ExecuteNonQuery();
            conn.Connection.Close();
        }

        static void Main(string[] args)
        {
            
            /*feltolt();
            foreach (var item in cars)
            {
                Console.WriteLine("Autó gyártója:" + item.Brand+" | "+"motoszáma:"+item.License);  
            }
            addNewCar();
            upDateCar();*/
            delCar();
            Console.ReadLine();
        }
    }
}
