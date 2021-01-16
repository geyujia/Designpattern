using System;

#region 场景描述

#endregion

/// <summary>
/// 08-结构型：装饰器模式
/// </summary>
namespace _08DecoratorPattern
{
    class Program
    {
        /// <summary>
        /// 使用 RedShapeDecorator 来装饰 Shape 对象。
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Shape circle = new Circle();//里氏替换原则
            Shape redCircle = new RedShapeDecorator(new Circle());
            Shape redRectangle = new RedShapeDecorator(new Rectangle());

            Console.WriteLine("Circle with normal border");
            circle.Draw();

            Console.WriteLine("\nCircle of red border");
            redCircle.Draw();

            Console.WriteLine("\nRectangle of red border");
            redRectangle.Draw();

            Console.ReadKey();
        }
    }

    #region 基础类构建
    /// <summary>
    /// 步骤 1 创建形状抽象类。
    /// </summary>
    public abstract class Shape
    {
        public abstract void Draw();
    }
    /// <summary>
    /// 步骤 2 创建实现接口的实体类。
    /// </summary>
    public class Rectangle : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("Shape:Rectangle.");

        }
    }

    public class Circle : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("Shape:Circle.");

        }
    }
    /// <summary>
    /// 步骤 3 创建实现了 Shape 接口的抽象装饰类。
    /// </summary>
    public abstract class ShapeDecorator : Shape
    {
        protected Shape decoratedShape;

        public ShapeDecorator(Shape shape)
        {
            this.decoratedShape = shape;
        }
        public override void Draw()
        {
            decoratedShape.Draw();
        }
    }
    /// <summary>
    /// 步骤 4 创建扩展了 ShapeDecorator 类的实体装饰类。
    /// </summary>
    public class RedShapeDecorator : ShapeDecorator
    {
        public RedShapeDecorator(Shape decoratedShape) :base(decoratedShape)
        {
            
        }

        public override void Draw()
        {
            decoratedShape.Draw();
            setRedBorder(decoratedShape);

        }

        private void setRedBorder(Shape decoratedShape)
        {
            Console.WriteLine("Border Color: Red");
        }
    }
    #endregion
}
