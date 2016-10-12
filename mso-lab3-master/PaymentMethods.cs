using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab3
{
    interface PaymentMethods : ICard
    {
        void Connect();
        void Disconnect();
        int BeginTransaction(float amount);
        bool EndTransaction(int id);
        void CancelTransaction(int id);

    }

    class CoinMachineAdapter : ICard
    {
        IKEAMyntAtare2000 coinMachine = new IKEAMyntAtare2000(); 

        public void Connect()
        {
            coinMachine.starta();
        }

        public void Disconnect()
        {
            
        }

        public int BeginTransaction(float amount)
        {
            coinMachine.betala((int)Math.Round(amount * 100));
            return 1;
        }

        public bool EndTransaction(int id)
        {
            coinMachine.stoppa();
            return true;
        }

        public void CancelTransaction(int id)
        {

        }


    }

}
