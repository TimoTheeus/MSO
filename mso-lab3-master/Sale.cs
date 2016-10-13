using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab3
{
    class Sale
    {
        PaymentFactory payFactory;
        //Handle the payment
        public Sale(UIInfo info)
        {
            payFactory = new PaymentFactory();
            // Compute the column in the table based on choices
            int tableColumn = payFactory.GetColumn(info);

            // Get price
            float price = calcPrice(info, tableColumn);

            // Pay
            MakePayment(payFactory.GetPaymentMethod(info), price);
        }

        private void MakePayment(PaymentMethods c, float price)
        {
            c.Connect();
            int dcid = c.BeginTransaction(price);
            c.EndTransaction(dcid);
        }

        private float calcPrice(UIInfo info, int tableColumn)
        {
            float price = 0;

            // Get number of tariefeenheden
            int tariefeenheden = Tariefeenheden.getTariefeenheden(info.From, info.To);

            price = PricingTable.getPrice(tariefeenheden, tableColumn);

            if (info.Way == UIWay.Return)
            {
                price *= 2;
            }
            // Add 50 cent if paying with credit card
            if (info.Payment == UIPayment.CreditCard)
            {
                price += 0.50f;
            }
            return price;
        }
    }
}
