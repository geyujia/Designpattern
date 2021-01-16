using System;

#region 场景描述

#endregion

/// <summary>
/// 07-结构型：桥接模式
/// </summary>
namespace _07BridgePattern
{
    class Program
    {
        /// <summary>
        /// 桥接模式演示
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //TEST
            Shape redCircle = new Circle(100, 100, 200, new RedCircle());
            Shape greenCircle = new Circle(100, 100, 200, new GreenCircle());
            redCircle.Draw();
            greenCircle.Draw();
            Console.ReadKey();
        }
    }

    #region 基础类构建
    /// <summary>
    /// 步骤 1 创建桥接实现接口。
    /// </summary>
    public interface DrawAPI
    { 
        void DrawCircle(int radius, int x, int y);
    }
    /// <summary>
    /// 步骤 2  创建实现了 DrawAPI 接口的实体桥接实现类。
    /// </summary>
    public class RedCircle : DrawAPI
    {
        public void DrawCircle(int radius, int x, int y)
        {
            Console.WriteLine("Drawing Circle[ color: red, radius: " + radius + ", x: " + x + ", y:" + y + "]");
        }
    }

    public class GreenCircle : DrawAPI
    {
        public void DrawCircle(int radius, int x, int y)
        {
            Console.WriteLine("Drawing Circle[ color: green, radius: " + radius + ", x: " + x + ",y: " + y + "]");
        }
    }

    /// <summary>
    /// 步骤 3 使用 DrawAPI 接口创建抽象类 Shape。
    /// </summary>
    public abstract class Shape
    {
        protected  DrawAPI drawAPI;

        public Shape(DrawAPI drawAPI)
        {
            this.drawAPI = drawAPI;
        }

        public abstract void Draw();
    }
    /// <summary>
    /// 步骤 4 创建实现了 Shape 接口的实体类。
    /// </summary>
    public class Circle:Shape
    {
        private int x, y, radius;

        public Circle(int x, int y, int radius, DrawAPI drawAPI) : base(drawAPI)
        {
            this.x = x;
            this.y = y;
            this.radius = radius;
        }

        public override void Draw()
        {
            drawAPI.DrawCircle(radius,x,y);
        }
    }

    #endregion
}
