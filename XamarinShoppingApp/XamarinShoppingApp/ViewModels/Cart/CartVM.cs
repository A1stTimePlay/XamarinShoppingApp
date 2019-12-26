using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;
using XamarinShoppingApp.Models;

namespace XamarinShoppingApp.ViewModels.Cart
{
    class CartVM:BaseViewModel
    {
        private ObservableCollection<Order_Detail> produts;
        private double totalPrice;

        private double discountPrice;

        private double discountPercent;
        private Command placeOrderCommand;

        public Command PlaceOrderCommand
        {
            get { return this.placeOrderCommand ?? (this.placeOrderCommand = new Command(this.PlaceOrderClicked)); }
        }

        private void PlaceOrderClicked(object obj)
        {
            
        }

        public CartVM()
        {
            produts = new ObservableCollection<Order_Detail>(App.CurrentCart);
            UpdatePrice();
        }

        public ObservableCollection<Order_Detail> Products
        {
            get
            {
                return this.produts;
            }

            set
            {
                if (this.produts == value)
                {
                    return;
                }
                this.produts = value;
                this.NotifyPropertyChanged();
                this.UpdatePrice();
            }
        }

        public double TotalPrice
        {
            get
            {
                return this.totalPrice;
            }

            set
            {
                if (this.totalPrice == value)
                {
                    return;
                }

                this.totalPrice = value;
                this.NotifyPropertyChanged();
            }
        }

        public double DiscountPrice
        {
            get
            {
                return this.discountPrice;
            }

            set
            {
                if (this.discountPrice == value)
                {
                    return;
                }

                this.discountPrice = value;
                this.NotifyPropertyChanged();
            }
        }

        public double DiscountPercent
        {
            get
            {
                return this.discountPercent;
            }

            set
            {
                if (this.discountPercent == value)
                {
                    return;
                }

                this.discountPercent = value;
                this.NotifyPropertyChanged();
            }
        }

        private void UpdatePrice()
        {
            this.ResetPriceValue();

            if (this.Products != null && this.Products.Count > 0)
            {
                foreach (Order_Detail order_Detail in this.Products)
                {
                    this.TotalPrice += (order_Detail.ProductDetail.Price * order_Detail.Quantity);
                    this.DiscountPrice += (order_Detail.ProductDetail.DiscountPrice * order_Detail.Quantity);
                }

                this.DiscountPercent = (this.TotalPrice - this.DiscountPrice) / (this.TotalPrice/100);
            }
        }

        private void ResetPriceValue()
        {
            this.TotalPrice = 0;
            this.DiscountPercent = 0;
            this.DiscountPrice = 0;
        }
    }
}
