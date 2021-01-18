using System;

#region 场景描述

#endregion

/// <summary>
/// 15-行为型：迭代器模式
/// </summary>
namespace _15IteratorPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            NameRepository nameRepository = new NameRepository();

            for (Iterator iter=nameRepository.GetIterator();iter.HasNext();)
            {
                string name = (string)iter.Next();
                Console.WriteLine("Name:"+name);
            }


            Console.ReadKey();

        }
    }

    #region 基础类构建
    /// <summary>
    /// 01 创建接口
    /// </summary>
    public interface Iterator
    {
        bool HasNext();

        object Next();
    }

    public interface Container
    {
        Iterator GetIterator();
    }

    /// <summary>
    /// 步骤 2 创建实现了 Container 接口的实体类。该类有实现了 Iterator 接口的内部类 NameIterator。
    /// </summary>
    public class NameRepository : Container
    {
        public static string[] names = { "Robert", "John", "Julie", "Lora" };
        public Iterator GetIterator()
        {
            return new NameIterator();
        }

        public class NameIterator : Iterator
        {
            int index;
            public bool HasNext()
            {
                if (index < names.Length)
                {
                    return true;
                }
                return false;
            }

            public object Next()
            {
                if (this.HasNext()) 
                {
                    return names[index++];
                }
                return null;
            }
        }
    }

   

    #endregion
}
