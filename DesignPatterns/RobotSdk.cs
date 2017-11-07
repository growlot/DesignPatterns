namespace DesignPatterns
{
    interface IRobot
    {
        void Move(double distance);
        void Turn(double angle);
        void Beep();
    }

    // I know I can not change SDK, but I will add some properties of the Robot to implement my simple scenario.
    // Assumed the Robot can move on the straight line only.
    class Robot : IRobot
    {
        public Robot()
        {
            CurrentPosition = 0.0;
            CurrentAngle = 0.0;
        }

        public double CurrentPosition { get; internal set; }
        public double CurrentAngle { get; internal set; }

        public void Beep()
        {
        }

        public void Move(double distance)
        {
            CurrentPosition += distance;
        }

        public void Turn(double angle)
        {
            CurrentAngle += angle;
        }
    }
}
