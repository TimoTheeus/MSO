using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab3
{
    class PaymentFactory
    {
        Dictionary<UIClass, int> classInfo;
        Dictionary<UIDiscount, int> discountInfo;
        Dictionary<UIPayment, PaymentMethods> payMethods;

        public PaymentFactory()
        {
            InitialiseDictionaries();
        }

        private void InitialiseDictionaries()
        {
            classInfo = new Dictionary<UIClass, int>();
            classInfo.Add(UIClass.FirstClass, 3);
            classInfo.Add(UIClass.SecondClass, 0);

            discountInfo = new Dictionary<UIDiscount, int>();
            discountInfo.Add(UIDiscount.FortyDiscount, 2);
            discountInfo.Add(UIDiscount.TwentyDiscount, 1);
            discountInfo.Add(UIDiscount.NoDiscount, 0);

            payMethods = new Dictionary<UIPayment, PaymentMethods>();
            payMethods.Add(UIPayment.Cash, new CoinMachineAdapter());
            payMethods.Add(UIPayment.CreditCard, new CreditCard());
            payMethods.Add(UIPayment.DebitCard, new DebitCard());

        }
        public PaymentMethods GetPaymentMethod(UIInfo info)
        {
            return payMethods[info.Payment];
        }
        public int GetColumn(UIInfo info)
        {
            return classInfo[info.Class] + discountInfo[info.Discount];
        }
    }
}
