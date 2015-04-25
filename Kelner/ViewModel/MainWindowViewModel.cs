﻿namespace Kelner.ViewModel
{
    using System.Collections.ObjectModel;

    using Kelner.Model;

    public class MainWindowViewModel : ViewModelBase
    {
        private string waiterName;

        private string firstSectionData;

        private WaiterWorker waiter;

        private ObservableCollection<Section> sections;

        public MainWindowViewModel()
        {
            this.Waiter = new WaiterWorker();
            this.StartWaiterWorkCommand = new RelayCommand(this.StartWork);
            this.StopWaiterWorkCommand = new RelayCommand(this.StopWork);
            this.WriteNewOrderCommand = new RelayCommand(this.WriteNewOrder);
            this.GiveWrittenOrdersToKitchenCommand = new RelayCommand(this.GiveNewOrdersToKitchen);
            this.TakeOrderFromKitchenCommand = new RelayCommand(this.TakeOrderFromKitchen);
            this.GiveOrdersToClientsCommand = new RelayCommand(this.GiveOrdersToClients);
        }

        public RelayCommand StartWaiterWorkCommand { get; set; }

        public RelayCommand StopWaiterWorkCommand { get; set; }

        public RelayCommand WriteNewOrderCommand { get; set; }

        public RelayCommand GiveWrittenOrdersToKitchenCommand { get; set; }

        public RelayCommand TakeOrderFromKitchenCommand { get; set; }

        public RelayCommand GiveOrdersToClientsCommand { get; set; }

        public ObservableCollection<Section> Sections
        {
            get
            {
                return this.sections;
            }

            set
            {
                this.sections = value;
                
            }
        }

        public WaiterWorker Waiter
        {
            get
            {
                return this.waiter;
            }

            set
            {
                this.waiter = value;
                this.RaisePropertyChanged("Waiter");
            }
        }

        private void StartWork()
        {
            this.Waiter.StartWork();
        }

        private void StopWork()
        {
            this.Waiter.StopWork();
        }

        /// <summary>
        /// Zapisz nowe zamówienie od klientów
        /// </summary>
        private void WriteNewOrder()
        {
            var newOrder = new Order { OrderState = Order.State.New, TableNumber = 2 };
            this.Waiter.WrittenOrders.Add(newOrder);
            this.Waiter.RefreshInformations();
        }

        private void GiveNewOrdersToKitchen()
        {
            this.Waiter.GiveOrdersToKitchen();
            this.Waiter.RefreshInformations();
        }

        private void TakeOrderFromKitchen()
        {
            this.Waiter.TakeOrderFromKitchen();
            this.Waiter.RefreshInformations();
        }

        private void GiveOrdersToClients()
        {
            this.Waiter.GiveOrdersToClients();
            this.Waiter.RefreshInformations();
        }

        //private void CreateSections()
        //{
        //    this.Sections = new ObservableCollection<Section>();

        //    for (int i = 0; i < 10; i++)
        //    {
        //        for (int j = 0; j < 10; j++)
        //        {
        //            var section = new Section { X = i * 25, Y = j * 25 };
        //            this.Sections.Add(section);
        //        }
        //    }
        //}
    }
}
