#region Copyright
// *******************************************************************************
// Copyright (c) 2010-2011 Paul Stancer.
// All rights reserved. This program and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html
//
// Contributors:
//     Paul Stancer - initial implementation
// *******************************************************************************
#endregion
#region using
using System;
using System.Collections;
using System.Collections.Generic;
using Ximura;
#endregion 
namespace Stancer.GTFSEngine.Entities
{
    /// <summary>
    /// This struct defines fare information for a transit organization's routes. 
    /// </summary>
    public struct FareAttribute
    {
        #region Static constructor and properties
        private static readonly string[] sHeaders;
        private static readonly bool[] sHeaderOptional;

        /// <summary>
        /// This is an enumeration of the header name and its mandatory status.
        /// </summary>
        public static IEnumerable<KeyValuePair<string,bool>> Headers
        {
            get
            {
                for (int i=0; i < sHeaders.Length; i++)
                    yield return new KeyValuePair<string, bool>(sHeaders[i],sHeaderOptional[i]);
            }
        }

        static FareAttribute()
        {
            sHeaders = new string[] {  
              "fare_id"
            , "price"
            , "currency_type"
            , "payment_method"
            , "transfers"
            , "transfer_duration"
            };

            sHeaderOptional = new bool[] {  
              false //"fare_id"
            , false //"price"
            , false //"currency_type"
            , false //"payment_method"
            , false // "transfers"
            , true  //"transfer_duration"
            };
        }
        #endregion 
        #region Declarations
        string mFareID;
        decimal mPrice;
        string mCurrencyType;
        PaymentMethodType mPaymentMethod;
        TransferType mTransfers;
        int? mTransferDuration;
        #endregion 
        
        #region Constructor
        public FareAttribute(CSVRowItem item)
        {
            mFareID = item.ValidateNotEmptyOrNull("fare_id");
            mPrice = decimal.Parse(item["price"]);
            mCurrencyType = item.ValidateNotEmptyOrNull("currency_type");

            mPaymentMethod = item["payment_method"].ToPaymentMethodType();
            mTransfers = item["transfers"].ToTransferType();

            int tDur;
            mTransferDuration = int.TryParse(item["transfer_duration"], out tDur) ? tDur : (int?)null;
        }
        /// <summary>
        /// This is the default constructor.
        /// </summary>
        /// <param name="FareID"></param>
        /// <param name="Price"></param>
        /// <param name="CurrencyType"></param>
        /// <param name="PaymentMethod"></param>
        /// <param name="Transfers"></param>
        /// <param name="TransferDuration"></param>
        public FareAttribute(
            string FareID,
            decimal Price,
            string CurrencyType,
            PaymentMethodType PaymentMethod,
            TransferType Transfers,
            int? TransferDuration
            )
        {
            mFareID= FareID;
            mPrice= Price;
            mCurrencyType= CurrencyType;
            mPaymentMethod= PaymentMethod;
            mTransfers= Transfers;
            mTransferDuration= TransferDuration;
        }
        #endregion  

        /// <summary>
        /// Required. The fare_id field contains an ID that uniquely identifies a fare class. The fare_id is dataset unique.
        /// </summary>
        public string FareID
        {
            get { return mFareID; }
        }
        /// <summary>
        /// Required. The price field contains the fare price, in the unit specified by currency_type. 
        /// </summary>
        public decimal Price
        {
            get { return mPrice; }
        }
        /// <summary>
        /// Required. The currency_type field defines the currency used to pay the fare.
        /// </summary>
        public string CurrencyType
        {
            get { return mCurrencyType; }
        }
        /// <summary>
        /// Required. The payment_method field indicates when the fare must be paid. 
        /// </summary>
        public PaymentMethodType PaymentMethod
        {
            get { return mPaymentMethod; }
        }
        /// <summary>
        /// Required. The transfers field specifies the number of transfers permitted on this fare.
        /// </summary>
        public TransferType Transfers
        {
            get { return mTransfers; }
        }
        /// <summary>
        /// Optional. The transfer_duration field specifies the length of time in seconds before a transfer expires. 
        /// </summary>
        public int? TransferDuration
        {
            get { return mTransferDuration; }
        }
    }
}
