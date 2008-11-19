using System;
using System.Collections.Generic;
using Common;

namespace xEmulate
{
    class MouseAlgs
    {

        public enum AxisAlgorithm
        {
            Pow,
            Poly,
        }

        abstract public class Algorithm
        {
            private AxisAlgorithm alg;
            public int Cap { get; set; }
            public double MaxSpeed { get; set; }
            public double MinSpeed { get; set; }
            public int CarryZone { get; set; }

            public Algorithm(AxisAlgorithm alg, int cap, double minspeed, double maxspeed, int carryZone)
            {
                this.alg = alg;
                this.MaxSpeed = maxspeed;
                this.MinSpeed = minspeed;
                this.Cap = cap;
                this.CarryZone = carryZone;
            }

            public abstract double GetPixelCapValue(int deadzone);
            public abstract double CalcOutputDelta(double inputDelta, double otherAxis);

            public AxisAlgorithm GetAlg() { return alg; }
        }

        public class PowerFunction : Algorithm
        {
            public PowerFunction(double speed, double exponent, int cap, double minSpeed, double maxSpeed, int carryZone)
                : base(AxisAlgorithm.Pow, cap, minSpeed, maxSpeed, carryZone)
            {
                this.Speed = speed;
                this.Exp = exponent;
            }
            public double Speed { get; set; }
            public double Exp { get; set; }

            public override double CalcOutputDelta(double inputDelta,double otherAxis)
            {
                Vector2 delta = new Vector2(inputDelta, otherAxis);
                delta.Pow(this.Exp);
                delta.Scale(this.Speed);
                return delta.X;
            }

            public override double GetPixelCapValue(int deadzone)
            {
                return Math.Pow((this.Cap - deadzone) / this.Speed, (double)1 / this.Exp);
            }

        }

        public class StaticFunction : Algorithm
        {
            public StaticFunction(double output, int cap, double minSpeed, double maxSpeed, int carryZone)
                : base(AxisAlgorithm.Pow, cap, minSpeed, maxSpeed, carryZone)
            {
                this.Output = output;
            }
            public double Output { get; set; }

            public override double CalcOutputDelta(double inputDelta, double otherAxis)
            {
                return Math.Sign(inputDelta)* this.Output;
            }

            public override double GetPixelCapValue(int deadzone)
            {
                return 0;
            }

        }

        public class PolynomialFunction : Algorithm
        {
            public PolynomialFunction(double x2Factor, double xFactor, double yIntercept, int cap, double minSpeed, double minspeed, double maxSpeed, int carryZone)
                : base(AxisAlgorithm.Pow, cap, minSpeed, maxSpeed, carryZone)
            {
                this.x2Factor = x2Factor;
                this.xFactor = xFactor;
                this.yIntercept = yIntercept;
            }
            public double x2Factor { get; set; }
            public double xFactor { get; set; }
            public double yIntercept { get; set; }

            public override double CalcOutputDelta(double inputDelta, double otherAxis)
            {
                Vector2 xsquared = new Vector2(inputDelta, otherAxis);
                xsquared.Pow(2);
                xsquared.Scale(this.x2Factor);
                return Math.Sign(inputDelta) * ( xsquared.X + this.xFactor * Math.Abs(inputDelta) + yIntercept ) ;
            }

            public override double GetPixelCapValue(int deadzone)
            {
                return 99999;
            }
        }
        public class LogFunction : Algorithm
        {
            public LogFunction(double lnFactor, double offset, int cap, double minSpeed, double maxSpeed, int carryZone)
                : base(AxisAlgorithm.Pow, cap, minSpeed, maxSpeed, carryZone)
            {
                this.offset = offset;
            }
            public double lnFactor { get; set; }
            public double offset { get; set; }

            public override double CalcOutputDelta(double inputDelta, double otherAxis)
            {
                Vector2 lnx = new Vector2(inputDelta, otherAxis);
                lnx.Log();
                return (lnx.X + this.lnFactor * Math.Abs(inputDelta) + this.offset);
            }

            public override double GetPixelCapValue(int deadzone)
            {
                return 99999;
            }
        }
    }
}
