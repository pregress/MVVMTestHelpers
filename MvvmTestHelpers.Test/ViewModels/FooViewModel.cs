using System;
using System.Collections.Generic;
using Caliburn.Micro;

namespace MvvmTestHelpers.Test.ViewModels
{
    /// <summary>
    /// Demo View model with Caliburn.Micro
    /// </summary>
    public class FooViewModel : PropertyChangedBase
    {
        private int _id;
        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                NotifyOfPropertyChange(() => Id);
            }
        }

        private double _price;
        public double Price
        {
            get { return _price; }
            set
            {
                _price = value;
                NotifyOfPropertyChange(() => Price);
            }
        }

        private float _averagePrice;
        public float AveragePrice
        {
            get { return _averagePrice; }
            set
            {
                _averagePrice = value;
                NotifyOfPropertyChange(() => AveragePrice);
            }
        }

        private decimal _weight;
        public decimal Weight
        {
            get { return _weight; }
            set
            {
                _weight = value;
                NotifyOfPropertyChange(() => Weight);
            }
        }

        private byte _someByte;
        public byte SomeByte
        {
            get { return _someByte; }
            set
            {
                _someByte = value;
                NotifyOfPropertyChange(() => SomeByte);
            }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                NotifyOfPropertyChange(() => Name);
            }
        }

        private DateTime _creationDate;
        public DateTime CreationDate
        {
            get { return _creationDate; }
            set
            {
                _creationDate = value;
                NotifyOfPropertyChange(() => CreationDate);
            }
        }

        private IEnumerable<object> _children;
        public IEnumerable<object> Children
        {
            get { return _children; }
            set
            {
                _children = value;
                NotifyOfPropertyChange(() => Children);
            }
        }

        private ContactType _contactType;
        public ContactType ContactType
        {
            get { return _contactType; }
            set
            {
                _contactType = value;
                NotifyOfPropertyChange(() => ContactType);
            }
        }

        public IObservableCollection<string> Products { get; set; }
        public IObservableCollection<int> Prices { get; set; }
    }

    public enum ContactType
    {
        Phone,
        Mail,
        Email
    }
}
