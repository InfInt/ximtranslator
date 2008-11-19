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
            get
            {
                if (this.Y != 0)
                    return this.Y / Math.Sin(this.Angle);
                else
                    return this.X / Math.Cos(this.Angle);
            }
        }

        public double Angle
        {
            get { return Math.Atan2(this.Y,this.X); }
        }

        public void Normalize()
        {
            // Vector3.Length property is under length section
            double length = this.Length;

            this.X /= length;
            this.Y /= length;
        }

        public void Scale(double factor)
        {
            X *= factor;
            Y *= factor;
        }

        public void Rotate(double angleInRadians)
        {
            Vector2 tmp = new Vector2(this);
            this.X = tmp.X * Math.Cos(angleInRadians) + tmp.Y * Math.Sin(angleInRadians);
            this.Y = tmp.Y * Math.Cos(angleInRadians) - tmp.X * Math.Sin(angleInRadians);          
        }

        public void Add(Vector2 other)
        {
            this.X += other.X;
            this.Y += other.Y;
        }

        public void Pow(double e)
        {
            double mouseVectorLen = Math.Pow(this.Length, e);
            this.Normalize();
            this.Scale(mouseVectorLen);
        }

        public void Log()
        {
            double mouseVectorLen = Math.Log(this.Length);
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

        public void CapLen(double maxLen)
        {
            if (this.Length > maxLen)
            {
                Normalize();
                Scale(maxLen);
            }
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
