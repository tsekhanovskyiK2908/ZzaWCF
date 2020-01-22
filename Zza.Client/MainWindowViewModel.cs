using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.ServiceModel.Description;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Zza.Client.ZzaServices;
using Zza.Entities;

namespace Zza.Client
{
    public class MainWindowViewModel : BindableBase
    {
        private ObservableCollection<Product> _products;
        private ObservableCollection<Customer> _customers;
        private ObservableCollection<OrderItem> _orderItems;
        private ObservableCollection<OrderItemModel> _items = new ObservableCollection<OrderItemModel>();
        private Order _currentOrder = new Order();
        private ObservableCollection<OrderItem> _currentOrderItems;

        public DelegateCommand SubmitOrderCommand { get; set; }
        public DelegateCommand<Product> AddOrderItemCommand { get; set; }
        public ObservableCollection<Product> Products 
        { 
            get
            {
                return _products;
            }
            set
            {
                SetProperty(ref _products, value);
            }
        }

        public ObservableCollection<Customer> Customers
        {
            get
            {
                return _customers;
            }
            set
            {
                SetProperty(ref _customers, value);
            }
        }

        public ObservableCollection<OrderItem> OrderItems
        {
            get
            {
                return _orderItems;
            }
            set
            {
                SetProperty(ref _orderItems, value);
            }
        }

        public ObservableCollection<OrderItemModel> Items
        {
            get
            {
                return _items;
            }
            set
            {
                SetProperty(ref _items, value);
            }
        }

        public Order CurrentOrder
        {
            get
            {
                return _currentOrder;
            }
            set
            {
                SetProperty(ref _currentOrder, value);
            }
        }

        public ObservableCollection<OrderItem> CurrentOrderItems
        {
            get
            {
                return _currentOrderItems;
            }
            set
            {
                SetProperty(ref _currentOrderItems, value);
            }
        }

        public MainWindowViewModel()
        {
            _currentOrder.OrderDate = DateTime.Now;
            _currentOrder.OrderStatusId = 1;
            SubmitOrderCommand = new DelegateCommand(OnSubmitOrder);
            AddOrderItemCommand = new DelegateCommand<Product>(OnAddItem);

            if(!DesignerProperties.GetIsInDesignMode(new DependencyObject()))
            {
                LoadProductsAndCustomers();
            }

        }

        private void OnAddItem(Product product)
        {
            var existingOrderItem = _orderItems.Where(oi => oi.ProductId == product.Id).FirstOrDefault();
            var existingOrderItemModel = _items.Where(i => i.ProductId == product.Id).FirstOrDefault();

            if(existingOrderItem != null && existingOrderItemModel != null)
            {
                existingOrderItem.Quantity++;
                existingOrderItemModel.Quantity++;
                existingOrderItem.TotalPrice = existingOrderItem.UnitPrice * existingOrderItem.Quantity;
                existingOrderItemModel.TotalPrice = existingOrderItemModel.TotalPrice;
            }
            else
            {
                var orderItem = new OrderItem
                {
                    ProductId = product.Id,
                    Quantity = 1,
                    UnitPrice = 9.99M,
                    TotalPrice = 9.99M,
                    OrderId = _currentOrder.Id
                };

                _currentOrderItems.Add(orderItem);

                Items.Add(new OrderItemModel
                {
                    ProductId = product.Id,
                    ProductName = product.Name,
                    Quantity = orderItem.Quantity,
                    TotalPrice = orderItem.TotalPrice
                });
            }
        }

        private void OnSubmitOrder()
        {
            if(_currentOrder.CustomerId != Guid.Empty && _currentOrderItems.Count > 0)
            {
                ZzaServiceClient proxy = new ZzaServiceClient("NetTcpBinding_IZzaService");

                try
                {
                    proxy.SubmitOrder(_currentOrder);
                    CurrentOrder = new Order();
                    CurrentOrder.OrderDate = DateTime.Now;
                    CurrentOrder.OrderStatusId = 1;
                    Items = new ObservableCollection<OrderItemModel>();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error saving order");
                }
                finally
                {
                    proxy.Close();
                }
            }
            else
            {
                MessageBox.Show("Select cutomer and add at least one item to the order");
            }
        }

        private async void LoadProductsAndCustomers()
        {
            //ZzaServiceClient proxy = new ZzaServiceClient("NetTcpBinding_IZzaService");
            ZzaProxy proxy = new ZzaProxy("NetTcpBinding_IZzaService");
            //proxy.ClientCredentials.Windows.ClientCredential.UserName = "DESKTOP-32D7OLF\\test";
            //proxy.ClientCredentials.Windows.ClientCredential.Password = "777";

            try
            {
                Products = await proxy.GetProductsAsync();
                Customers = await proxy.GetCustomersAsync();
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load server data." + ex.Message);
            }
            finally
            {
                proxy.Close();
            }

        }
    }
}
