using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public class Vector2
    {
        public double X;
        public double Y;

        public Vector2(Vector2 v) { this.X = v.X; this.Y = v.Y; }
        public Vector2(double X, double Y) { this.X = X; this.Y = Y; }

        public double Length
        {
            get { return Math.Sqrt(X * X + Y * Y); }
        }

        public void Normalize()
        {
            // Vector3.Length property is under length section
            double length = this.Length;

            X /= length;
            Y /= length;
        }

        public void Scale(double factor)
        {
            X *= factor;
            Y *= factor;
        }

        public void Add(Vector2 other)
        {
            this.X += other.X;
            this.Y += other.Y;
        }

        public void Pow(double e)
        {
            double mouseVectorLen = Math.Sqrt(this.X * this.X + this.Y * this.Y);
            mouseVectorLen = Math.Pow(mouseVectorLen, e);
            this.Normalize();
            this.Scale(mouseVectorLen);
        }

        public static Vector2 operator+(Vector2 first, Vector2 other )
        {
            Vector2 v = new Vector2(other.X, other.Y);
            v.Add(first);
            return v;
        }

        public void Cap(double min, double max)
        {
            if (X < min)
                X = min;
            else if (X > max)
                X = max;

            if (Y < min)
                Y = min;
            else if (Y > max)
                Y = max;
        }

        public void CapX(double min, double max)
        {
            if (X < min)
                X = min;
            else if (X > max)
                X = max;
        }

        public void CapY(double min, double max)
        { 
            if (Y < min)
                Y = min;
            else if (Y > max)
                Y = max;
        }

    }
}
