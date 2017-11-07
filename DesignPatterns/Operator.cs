using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    interface IOperator
    {
        bool Do(IRobot robot);
    }

    class OMoveToTarget : IOperator
    {
        public double TargetPosition { get; set; }

        public OMoveToTarget(double targetPosition)
        {
            TargetPosition = targetPosition;
        }

        public bool Do(IRobot robot)
        {
            Robot obj = robot as Robot;

            if (obj == null)
                return false;

            try
            {
                double distance = TargetPosition - obj.CurrentPosition;
                obj.Move(distance);

                /////
                // Wait for ending of move
                /////

                if (obj.CurrentPosition != TargetPosition)
                    throw new Exception("Failed to move to target");
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
    }

    class OTurnToPi : IOperator
    {
        private const double PI = 3.1415927; // Also this will be target angle

        public bool Do(IRobot robot)
        {
            Robot obj = robot as Robot;

            if (obj == null)
                return false;

            try
            {
                double angle = PI - obj.CurrentAngle;
                obj.Turn(angle);

                /////
                // Wait for ending of trun
                /////

                if (obj.CurrentAngle != PI)
                    throw new Exception("Failed to trun to PI");
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
    }

    class OBeepOnTarget : IOperator
    {
        public bool Do(IRobot robot)
        {
            Robot obj = robot as Robot;

            if (obj == null)
                return false;

            try
            {
                obj.Beep();

                /////
                // Wait for ending of beep
                /////
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
    }
}
