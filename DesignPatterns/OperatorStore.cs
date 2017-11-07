using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    class OperatorStore
    {
        private static object _locker = new object();

        private static OperatorStore _instance;
        public static OperatorStore Instance
        {
            get
            {
                lock (_locker)
                {
                    if (_instance == null)
                        _instance = new OperatorStore();
                    return _instance;
                }
            }
        }

        public List<IOperator> Operators { get; set; }

        public OperatorStore()
        {
            // Define operations to do
            Operators = new List<IOperator>();
            var opMove = new OMoveToTarget(100);
            Operators.Add(opMove);
            var opTurn = new OTurnToPi();
            Operators.Add(opTurn);
            var opBeep = new OBeepOnTarget();
            Operators.Add(opBeep);
            var opMoveToOrigin = new OMoveToTarget(0);
            Operators.Add(opMoveToOrigin);
        }
    }
}
