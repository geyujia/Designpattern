using System;
using System.Collections.Generic;

#region 场景描述

#endregion

/// <summary>
/// 17-行为型:观察者模式
/// </summary>
namespace _17ObserverPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Subject subject = new Subject();

            new HexaObserver(subject);
            new OctalObserver(subject);
            new BinaryObserver(subject);

            Console.WriteLine("First state change: 15");
            subject.SetState(15);
            Console.WriteLine("Second state change: 10");
            subject.SetState(10);

            Console.ReadKey();
        }
    }

    #region 基础类构建

    /// <summary>
    /// 步骤 1 创建 Subject 类。
    /// </summary>
    public class Subject
    {
        public List<Observer> observers = new List<Observer>();
        private int state;

        public int GetState()
        {
            return state;
        }

        public void SetState(int state)
        {
            this.state = state;
            this.NotifyAllObservers();
        }

        public void Attach(Observer observer)
        {
            observers.Add(observer);
        }

        public void NotifyAllObservers()
        {
            foreach (Observer observer in observers)
            {
                observer.Update();
            }
        }

    }

    /// <summary>
    ///  步骤 2 创建 Observer 类。
    /// </summary>
    public abstract class Observer
    {
        protected Subject subject;

        public abstract void Update();
    }

    /// <summary>
    /// 步骤 3 创建实体观察者类.
    /// </summary>
    public class BinaryObserver : Observer
    {
        public BinaryObserver(Subject subject)
        {
            this.subject = subject;
            this.subject.Attach(this);
        }

        public override void Update()
        {
            Console.WriteLine("Binary string: " + Convert.ToString(subject.GetState(), 2));
        }
    }
    public class OctalObserver : Observer
    {
        public OctalObserver(Subject subject)
        {
            this.subject = subject;
            this.subject.Attach(this);
        }
        public override void Update()
        {
            Console.WriteLine("Octal string: " + Convert.ToString(subject.GetState(), 8));
        }
    }

    public class HexaObserver : Observer
    {
        public HexaObserver(Subject subject)
        {
            this.subject = subject;
            this.subject.Attach(this);
        }
        public override void Update()
        {
            Console.WriteLine("Hex string: " + Convert.ToString(subject.GetState(), 16).ToUpper());
        }
    }

    #endregion
}
