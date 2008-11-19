using System;
using System.Collections.Generic;
using System.Text;
using Common;

namespace xEmulate
{
    public abstract class MouseAlgorithm
    {
        public abstract void CalcOutputDelta(double delayInMs, Vector2 angVelocity, ref Vector2 outputDelta, ref Vector2 outputCarry);
    }

    public class XYLinkedAlgorithm : MouseAlgorithm
    {
        private XYLinkedTrans[] transFuncs;

        public XYLinkedAlgorithm(XYLinkedTrans[] transFuncs)
        { 
            this.transFuncs = transFuncs;
        }

        public override void CalcOutputDelta(double delayInMs, Vector2 angVelocity, ref Vector2 outputDelta, ref Vector2 outputCarry)
        {
            double veloLen = angVelocity.Length;
            XYLinkedTrans transAlg = this.transFuncs[0];
            bool clearRest = false;
            foreach (XYLinkedTrans alg in this.transFuncs)
            {
                if (clearRest)
                {
                    alg.TimeInOrAboveTrans = 0;
                }
                else
                {
                    if (veloLen < alg.MinSpeed)
                    {
                        alg.TimeInOrAboveTrans = 0;
                        clearRest = true;
                        continue;
                    }

                    transAlg = alg;

                    alg.AddTimeInOrAboveTrans(delayInMs);

                    if (veloLen < alg.MaxSpeed)
                    {
                        clearRest = true;
                        continue;
                    }
                }
            }

            if (veloLen > transAlg.MaxSpeed)
            {
                Vector2 angCarry = new Vector2(angVelocity);
                angCarry.Normalize();
                angCarry.Scale(transAlg.MaxSpeed);
                outputCarry.X = angVelocity.X - angCarry.X;
                outputCarry.Y = angVelocity.Y - angCarry.Y;
                angVelocity = angCarry;
            }

            transAlg.CalcOutputDelta(angVelocity, ref outputDelta);
        }
    }

    public abstract class XYLinkedTrans
    {
        protected TransAcceleration accel;
        public XYLinkedTrans(TransAcceleration accel){ this.accel = accel; this.TimeInOrAboveTrans = 0; }
        public double TimeInOrAboveTrans{ get; set; }
        public void AddTimeInOrAboveTrans(double value) { TimeInOrAboveTrans = TimeInOrAboveTrans + value; }        public abstract void CalcOutputDelta(Vector2 angVelocity, ref Vector2 outputDelta);
        public abstract double MinSpeed { get; }
        public abstract double MaxSpeed { get; }
    }

    public class XYLinkedPowerTrans : XYLinkedTrans
    {
        private double coeff;
        private double exponent;
        private double minSpeed;
        private double maxSpeed;

        public XYLinkedPowerTrans(
            TransAcceleration accel,
            double coeff,
            double exponent,
            double minSpeed,
            double maxSpeed) 
            : base(accel)
        {
            this.coeff = coeff;
            this.exponent = exponent;
            this.minSpeed = minSpeed;
            this.maxSpeed = maxSpeed;
        }

        public override double MinSpeed 
        {
            get { return minSpeed * this.accel.GetAccelCoeff(this.TimeInOrAboveTrans); }
        }

        public override double MaxSpeed
        {
            get { return maxSpeed * this.accel.GetAccelCoeff(this.TimeInOrAboveTrans); }
        }

        public override void CalcOutputDelta(Vector2 angVelocity, ref Vector2 outputDelta)
        {
            Vector2 delta = new Vector2(angVelocity);
            delta.Pow(this.exponent);
            delta.Scale(this.coeff);
            delta.Scale(this.accel.GetAccelCoeff(this.TimeInOrAboveTrans));
            outputDelta = delta;
        }
    }

    public class TransAcceleration
    {
        private double accelPerSecond;
        private double timeToMax;

        public TransAcceleration(double accelPerSecond, double timeToMax)
        {
            this.accelPerSecond = accelPerSecond;
            this.timeToMax = timeToMax;
        }

        public double GetAccelCoeff(double timeIn)
        {
            if (this.accelPerSecond == 0 || timeToMax == 0)
                return 1;

            double timeInSeconds = timeIn / 1000;
            if ( timeInSeconds > this.timeToMax)
                return 1.0 + this.accelPerSecond;
            else return 1.0 + timeInSeconds / this.accelPerSecond;
        }
    }
}
