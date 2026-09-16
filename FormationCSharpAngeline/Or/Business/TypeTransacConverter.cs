using Or.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Or.Business
{
    public class TypeTransacConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is Transaction transaction)
            {
                Operation operation = Tools.TypeTransaction(transaction.Expediteur, transaction.Destinataire);
                if(operation == Operation.DepotSimple)
                {
                    return "Dépôt";
                }
                else if(operation == Operation.RetraitSimple)
                {
                    return "Retrait";
                }
                else
                {
                    return "Virement";
                }
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
