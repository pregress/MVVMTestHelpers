using System;
using Caliburn.Micro;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvvmTestHelpers.Test.ViewModels;

namespace MvvmTestHelpers.Test
{
    /// <summary>
    /// Testing different types
    /// </summary>
    [TestClass]
    public class DifferentTypesTest
    {
        private FooViewModel _viewModel;

        /// <summary>
        /// Runs before every test
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            _viewModel = new FooViewModel();
        }

        /// <summary>
        /// Properties when set trigger notify property changed events.
        /// </summary>
        [TestMethod]
        public void Properties_WhenSet_TriggerNotifyPropertyChanged()
        {
            var propertyChangedTester = new NotifyPropertyChangedTester<FooViewModel>(_viewModel);
            propertyChangedTester.ExcludeProperties(new[] { "IsNotifying" }); //Exclude the IsNotifying property
            propertyChangedTester.ExcludeProperties(new Type[] { typeof(IObservableCollection<object>) }); //Exclude all IOsbervable Collections
            propertyChangedTester.Test();
        }

        //Other View Model tests
    }

}
