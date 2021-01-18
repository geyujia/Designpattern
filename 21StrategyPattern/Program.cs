using System;

#region 场景描述

#endregion

/// <summary>
/// 21-行为型：策略模式
/// </summary>
namespace _21StrategyPattern
{
    #region 基础类构建
    /// <summary>
    /// 步骤 1
    //创建一个接口。
    /// </summary>
    public interface Strategy
    {
        int doOperation(int num1,int num2);
    }
    /// <summary>
    ///    步骤 2
    //创建实现接口的实体类。
    /// </summary>
    public class OperationAdd : Strategy
    {
        public int doOperation(int num1, int num2)
        {
            return num1 + num2;
        }
    }

    public class OperationSubstract : Strategy
    {
        public int doOperation(int num1, int num2)
        {
            return num1 - num2;
        }
    }

    public class OperationMultiply : Strategy
    {
        public int doOperation(int num1, int num2)
        {
            return num1 * num2;
        }
    }
    /// <summary>
    /// 步骤3 创建 Context 类。
    /// </summary>

    public class Context
    {
        private Strategy strategy;

        public Context(Strategy strategy)
        {
            this.strategy = strategy;
        }

        public int executeStrategy(int num1,int num2)
        {
            return strategy.doOperation(num1,num2);
        }
    }




    #endregion

    /// <summary>
    /// 使用 Context 来查看当它改变策略 Strategy 时的行为变化。
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Context context = new Context(new OperationAdd());
            Console.WriteLine("10 + 5 = " + context.executeStrategy(10, 5));

            Context context1 = new Context(new OperationSubstract());
            Console.WriteLine("10 - 5 = " + context1.executeStrategy(10, 5));

            Context context2 = new Context(new OperationMultiply());
            Console.WriteLine("10 * 5 = " + context2.executeStrategy(10, 5));

            Console.ReadKey();
        }
    }


}
