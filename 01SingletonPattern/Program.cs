using System;


#region 场景描述
/*
 * 
 * 
 * 
 * 意图：保证一个类仅有一个实例，并提供一个访问它的全局访问点。
 * 主要解决：一个全局使用的类频繁地创建与销毁。
 * 何时使用：当您想控制实例数目，节省系统资源的时候。
 * 如何解决：判断系统是否已经有这个单例，如果有则返回，如果没有则创建。
 * 关键代码：构造函数是私有的。
 * 应用实例： 1、一个党只能有一个主席。 2、Windows 是多进程多线程的，在操作一个文件的时候，就不可避免地出现多个进程或线程同时操作一个文件的现象，所以所有文件的处理必须通过唯一的实例来进行。 3、一些设备管理器常常设计为单例模式，比如一个电脑有两台打印机，在输出的时候就要处理不能两台打印机打印同一个文件。
优点： 1、在内存里只有一个实例，减少了内存的开销，尤其是频繁的创建和销毁实例。 2、避免对资源的多重占用（比如写文件操作）。
缺点：没有接口，不能继承，与单一职责原则冲突，一个类应该只关心内部逻辑，而不关心外面怎么样来实例化。
使用场景： 1、要求生产唯一序列号。 2、WEB 中的计数器，不用每次刷新都在数据库里加一次，用单例先缓存起来。 3、创建的一个对象需要消耗的资源过多，比如 I/O 与数据库的连接等。
注意事项：getInstance() 方法中需要使用同步锁 synchronized (Singleton.class) 防止多线程同时进入造成 instance 被多次实例化。
*/
#endregion
/// <summary>
/// 01-创建型:单例模式
/// </summary>
namespace _01SingletonPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            //test Method
            SingleObject.GetInstance().ShowMessage();
            SingleObject1.GetInstance().ShowMessage();
            Singleton.GetInstance().ShowMessage();
            // Console.WriteLine("Hello World!");
        }
    }

    /// <summary>
    /// 创建一个 Singleton 类（饿汉式）
    /// 这种方式比较常用，但容易产生垃圾对象。
    ///优点：没有加锁，执行效率会提高。
    ///缺点：类加载时就初始化，浪费内存。
    ///它基于 classloder 机制避免了多线程的同步问题，不过，instance 在类装载时就实例化，
    ///虽然导致类装载的原因有很多种，在单例模式中大多数都是调用 getInstance 方法，
    ///但是也不能确定有其他的方式（或者其他的静态方法）导致类装载，这时候初始化 instance 显然没有达到 lazy loading 的效果。
    /// </summary>
    public class SingleObject
    {
        //创建 SingleObject 的一个对象
        private static SingleObject instance = new SingleObject();

        //让构造函数为 private，这样该类就不会被实例化
        private SingleObject() { }

        //获取唯一可用的对象
        public static SingleObject GetInstance()
        {
            return instance;
        }

        public void ShowMessage()
        {
            Console.WriteLine("Hello World 饿汉式!");
        }
    }

    /// <summary>
    /// 创建一个 Singleton 类（懒汉式）
    /// 这种方式具备很好的 lazy loading，能够在多线程中很好的工作，但是，效率很低，99% 情况下不需要同步。
    /// 优点：第一次调用才初始化，避免内存浪费。
    /// 缺点：必须加锁 synchronized 才能保证单例，但加锁会影响效率。
    /// getInstance() 的性能对应用程序不是很关键（该方法使用不太频繁）。
    /// </summary>
    public class SingleObject1
    {
        //创建 SingleObject 的一个对象

        private static SingleObject1 instance;
        //让构造函数为 private，这样该类就不会被实例化

        public  SingleObject1() { }
        //获取唯一可用的对象

        public static SingleObject1 GetInstance()
        {
            if (instance == null)
            {
                instance = new SingleObject1();
            }
            return instance;
        }


        public void ShowMessage()
        {
            Console.WriteLine("Hello World 懒汉式!");
        }
    }
    /// <summary>
    /// Double-Check概念对于多线程开发者来说不会陌生，如代码中所示，我们进行了两次if (singleton == null)检查，这样就可以保证线程安全了。这样，实例化代码只用执行一次，后面再次访问时，判断if (singleton == null)，直接return实例化对象。
    //使用双重检测同步延迟加载去创建单例的做法是一个非常优秀的做法，其不但保证了单例，而且切实提高了程序运行效率
   // 优点：线程安全；延迟加载；效率较高。
    /// </summary>
    public class Singleton
    {
        private static Singleton instance;
        //程序运行时创建一个静态只读的进程辅助对象
        private static readonly object syncRoot = new object();
        private Singleton() { }
        public static Singleton GetInstance()
        {
            //先判断是否存在，不存在再加锁处理
            if (instance == null)
            {
                //在同一个时刻加了锁的那部分程序只有一个线程可以进入
                lock (syncRoot)
                {
                    if (instance == null)
                    {
                        instance = new Singleton();
                    }
                }
            }
            return instance;
        }

        public void ShowMessage()
        {
            Console.WriteLine("Hello World 双重加锁机制!");
        }
    }

}
