using System;

#region 场景描述

#endregion

/// <summary>
/// 23-行为型：状态模式
/// </summary>
namespace _23StatePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Context context = new Context();

            StartState startState = new StartState();
            startState.doAction(context);
            Console.WriteLine(context.getState().ToString());

            StopState stopState = new StopState();
            stopState.doAction(context);

            Console.WriteLine(context.getState().ToString());
            Console.ReadKey();
        }
    }
    #region 基础类构建
    //    步骤 1
    //创建一个接口。
    public interface State
    {
        void doAction(Context context);
    }

    //    步骤 2
    //创建实现接口的实体类。
    public class StartState : State
    {
        public void doAction(Context context)
        {
            Console.WriteLine("Player is in start state");
            context.setState(this);
        }

        public override string ToString()
        {
            return "Start State";
        }
    }

    public class StopState : State
    {
        public void doAction(Context context)
        {
            Console.WriteLine("Player is in stop state");
            context.setState(this);
        }

        public override string ToString()
        {
            return "Stop State";
        }
    }

    //    步骤 3
    //创建 Context 类。
    public class Context
    {
        private State state;

        public Context()
        {
            state = null;
        }

        public void setState(State state)
        {
            this.state = state;
        }

        public State getState()
        {
            return state;
        }
    }
    #endregion
}
