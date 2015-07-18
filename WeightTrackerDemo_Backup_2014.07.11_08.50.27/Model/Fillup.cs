// ===================================================================================
//  Microsoft Developer Guidance
//  Application Guidance for Windows Phone 7 
// ===================================================================================
//  Copyright (c) Microsoft Corporation.  All rights reserved.
//  THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
//  OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
//  LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
//  FITNESS FOR A PARTICULAR PURPOSE.
// ===================================================================================
//  The example companies, organizations, products, domain names,
//  e-mail addresses, logos, people, places, and events depicted
//  herein are fictitious.  No association with any real company,
//  organization, product, domain name, email address, logo, person,
//  places, or events is intended or should be inferred.
// ===================================================================================

using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace FuelTracker.Model
{
    public class Fillup : INotifyPropertyChanged
    {
        private DateTime _date;
        private string _fuelQuantity;
        private string _odometerReading;
        private string _pricePerFuelUnit;

        public DateTime Date
        {
            get { return _date; }
            set
            {
                if (_date == value) return;
                _date = value;
                NotifyPropertyChanged("Date");
            }
        }

        public string OdometerReading
        {
            get { return _odometerReading; }
            set
            {
                if (_odometerReading == value) return;
                _odometerReading = value;
                NotifyPropertyChanged("Name");
            }
        }

        public string FuelQuantity
        {
            get { return _fuelQuantity; }
            set
            {
                if (_fuelQuantity == value) return;
                _fuelQuantity = value;
                NotifyPropertyChanged("Name");
            }
        }

        public string PricePerFuelUnit
        {
            get { return _pricePerFuelUnit; }
            set
            {
                if (_pricePerFuelUnit == value) return;
                _pricePerFuelUnit = value;
                NotifyPropertyChanged("Name");
            }
        }

        //public float FuelEfficiency
        //{
        //    get { return DistanceDriven / FuelQuantity; }
        //}

        public string DistanceDriven 
        {
            get { return _odometerReading; }
            set
            {
                if (_odometerReading == value) return;
                _odometerReading = value;
                NotifyPropertyChanged("Name");
            }
        }

        public IList<string> Validate()
        {
            var validationErrors = new List<string>();

            //if (OdometerReading <= 0)
            //{
            //    validationErrors.Add("The odometer value must be a number greater than zero.");
            //}

            //if (DistanceDriven <= 0)
            //{ 
            //    validationErrors.Add("The odometer value must be greater than the previous value.");
            //}

            //if (FuelQuantity <= 0) 
            //{
            //   validationErrors.Add("The fuel quantity must be greater than zero.");
            //}

            //if (PricePerFuelUnit <= 0) 
            //{
            //    validationErrors.Add("The fuel price must be greater than zero.");
            //}
            
            return validationErrors;
        }

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
