using System;
using System.Collections.Generic;

/// <summary>
/// 04-创建型:建造者模式
/// </summary>
namespace _04Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("建造者模式演示....");
            MealBuilder mealBuilder = new MealBuilder();

            Meal vegMeal = mealBuilder.PrepareVegMeal();
            Console.WriteLine("Veg Meal");
            vegMeal.ShowItems();
            Console.WriteLine("Total Cost: " + vegMeal.GetCost());
            Console.ReadKey();
        }
    }

    #region 基础类构建

   
    /// <summary>
    /// 步骤 1  创建一个表示食物条目和食物包装的接口
    /// </summary>
    public interface Item
    {
        /// <summary>
        /// 名称
        /// </summary>
        /// <returns></returns>
        string Name();
        /// <summary>
        /// 单价
        /// </summary>
        /// <returns></returns>
        float Price();
        /// <summary>
        /// 包装
        /// </summary>
        /// <returns></returns>
        Packing Packing();


    }
    /// <summary>
    /// 包装接口
    /// </summary>
    public interface Packing
    {
        string Pack();
    }
    /// <summary>
    /// 步骤 2 创建实现 Packing 接口的实体类
    /// </summary>
    public class Wrapper : Packing
    {
        public string Pack()
        {
            return "Wrapper";
        }
    }
    public class Bottle : Packing
    {
        public string Pack()
        {
            return "Bottle";
        }
    }
    /// <summary>
    /// 步骤 3 创建实现 Item 接口的抽象类，该类提供了默认的功能。
    /// </summary>
    public abstract class Burger : Item
    {
        public abstract string Name();

        public abstract float Price();

        public Packing Packing()
        {
          return  new Wrapper();
        }
    }
    public abstract class ColdDrink : Item
    {
        public abstract string Name();

        public abstract float Price();

        public Packing Packing()
        {
            return new Bottle();
        }
    }

    /// <summary>
    /// 步骤 4  创建扩展了 Burger 和 ColdDrink 的实体类。
    /// </summary>
    public class VegBurger : Burger
    {
        public override float Price()
        {
            return 25.0f;
        }

        public override string Name()
        {
            return "Veg Burger";
        }
    }

    public class ChickenBurger : Burger
    {
        public override float Price()
        {
            return 50.5f;
        }

        public override string Name()
        {
            return "Chicken Burger";
        }
    }

    public class Coke : ColdDrink
    {
        public override float Price()
        {
            return 30.0f;
        }

        public override string Name()
        {
            return "Coke";
        }
    }

    public class Pepsi : ColdDrink
    {
        public override float Price()
        {
            return 35.0f;
        }

        public override string Name()
        {
            return "Pepsi";
        }
    }

    /// <summary>
    /// 步骤 5  创建一个 Meal 类，带有上面定义的 Item 对象。
    /// </summary>
    /// 
    public class Meal
    {
        private List<Item> items = new List<Item>();

        public void AddItem(Item item)
        {
            items.Add(item);
        }

        public float GetCost()
        {
            float cost = 0.0f;
            foreach (Item item in items)
            {
                cost += item.Price();
            }
            return cost;
        }

        public void ShowItems()
        {
            foreach (Item item in items)
            {
                Console.Write("Item : " + item.Name());
                Console.Write(", Packing : " + item.Packing().Pack());
                Console.WriteLine(", Price : " + item.Price());
            }
        }
    }

    /// <summary>
    /// 步骤 6  创建一个 MealBuilder 类，实际的 builder 类负责创建 Meal 对象。
    /// </summary>
    public class MealBuilder
    {
        public Meal PrepareVegMeal()
        {
            Meal meal = new Meal();
            meal.AddItem(new VegBurger());
            meal.AddItem(new Coke());
            return meal;
        }

        //public Meal PrepareNonVegMeal()
        //{
        //    Meal meal = new Meal();
        //    meal.AddItem(new ChickenBurger());
        //    meal.AddItem(new Pepsi());
        //    return meal;
        //}
    }

    #endregion
}
