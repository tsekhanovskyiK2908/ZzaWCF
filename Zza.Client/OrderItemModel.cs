using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zza.Client
{
    public class OrderItemModel : BindableBase
    {
        private int _productId;
        private string _productName;
        private int _quantity;
        private decimal _totalPrice;

        public int ProductId 
        {
            get
            {
                return _productId;
            }
            set
            {
                SetProperty(ref _productId, value);
            }
        }

        public string ProductName
        {
            get
            {
                return _productName;
            }
            set
            {
                SetProperty(ref _productName, value);
            }
        }

        public int Quantity
        {
            get
            {
                return _quantity;
            }
            set
            {
                SetProperty(ref _quantity, value);
            }
        }

        public decimal TotalPrice
        {
            get
            {
                return _totalPrice;
            }
            set
            {
                SetProperty(ref _totalPrice, value);
            }
        }
    }
}
