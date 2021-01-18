using System;
#region 场景描述
/*
 在模板模式（Template Pattern）中，一个抽象类公开定义了执行它的方法的方式/模板。它的子类可以按需要重写方法实现，但调用将以抽象类中定义的方式进行。这种类型的设计模式属于行为型模式。
 */
#endregion

/// <summary>
/// 13-行为型：模板方法模式
/// </summary>
namespace _13TemplateMethod
{
    class Program
    {
        /// <summary>
        ///  步骤 3
        ///使用 Game 的模板方法 play() 来演示游戏的定义方式。
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Game game = new Cricket();
            game.play();
            Console.WriteLine("......................");
            game = new Football();
            game.play();
            Console.ReadKey();
        }
    }
    #region 基础类构建
    /// <summary>
    /// 创建一个抽象类，它的模板方法被设置为 final。
    /// </summary>
    public abstract class Game
    {
        public abstract void initialize();

        public abstract void startPlay();

        public abstract void endPlay();

        //模板
        public void play()
        {
            //初始化游戏
            initialize();

            //开始游戏
            startPlay();

            //结束游戏
            endPlay();
        }
    }
    /// <summary>
    /// 步骤 2
    ///创建扩展了上述类的实体类
    /// </summary>
    public class Cricket : Game
    {
        public override void endPlay()
        {
            Console.WriteLine("Cricket Game Finished!");
        }

        public override void initialize()
        {
            Console.WriteLine("Cricket Game Initialized! Start playing.");
        }

        public override void startPlay()
        {
            Console.WriteLine("Cricket Game Started. Enjoy the game!");
        }
    }

    public class Football : Game
    {
        public override void endPlay()
        {
            Console.WriteLine("Football Game Finished!");
        }

        public override void initialize()
        {
            Console.WriteLine("Football Game Initialized! Start playing.");
        }

        public override void startPlay()
        {
            Console.WriteLine("Football Game Started. Enjoy the game!");
        }
    }
    #endregion
}
