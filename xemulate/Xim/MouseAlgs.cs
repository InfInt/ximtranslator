using System;
using System.Collections.Generic;
using System.Text;

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
            public int CarryZone { get; set; }

            public Algorithm(AxisAlgorithm alg, int cap, double maxspeed, int carryZone)
            {
                this.alg = alg;
                this.MaxSpeed = maxspeed;
                this.Cap = cap;
                this.CarryZone = carryZone;
            }

            public abstract double GetPixelCapValue(int deadzone);
            public abstract double CalcOutputDelta(double inputDelta);

            public AxisAlgorithm GetAlg() { return alg; }
        }

        public class PowerFunction : Algorithm
        {
            public PowerFunction(double speed, double exponent, int cap, double maxSpeed, int carryZone)
                : base(AxisAlgorithm.Pow, cap, maxSpeed, carryZone)
            {
                this.Speed = speed;
                this.Exp = exponent;
            }
            public double Speed { get; set; }
            public double Exp { get; set; }

            public override double CalcOutputDelta(double inputDelta)
            {
                double output;
                // Transform by the found linearize formula delta^exp * speed + deadzone
                output = Math.Sign(inputDelta) * Math.Pow(Math.Abs(inputDelta), this.Exp);
                output = output * this.Speed;
                return output;
            }

            public override double GetPixelCapValue(int deadzone)
            {
                return Math.Pow((this.Cap - deadzone) / this.Speed, (double)1 / this.Exp);
            }

        }

        public class PolynomialFunction : Algorithm
        {
            public PolynomialFunction(double x2Factor, double xFactor, double yIntercept, int cap, double maxSpeed, int carryZone)
                : base(AxisAlgorithm.Pow, cap, maxSpeed, carryZone)
            {
                this.x2Factor = x2Factor;
                this.xFactor = xFactor;
                this.yIntercept = yIntercept;
            }
            public double x2Factor { get; set; }
            public double xFactor { get; set; }
            public double yIntercept { get; set; }

            public override double CalcOutputDelta(double inputDelta)
            {
                int sign = Math.Sign(inputDelta);
                double val = Math.Abs(inputDelta);
                return sign * (x2Factor * (val * val) + xFactor * val + yIntercept);
            }

            public override double GetPixelCapValue(int deadzone)
            {
                return 99999;
            }
        }
    }
}
