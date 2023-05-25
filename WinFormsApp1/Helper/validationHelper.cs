﻿using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1.Helper
{
    public class validationHelper
    {

        // Checking if the device is connected to internet
        public static bool internetAvailability()
        {
            try
            {
                Ping myPing = new Ping();
                String host = "portal.azure.com";
                byte[] buffer = new byte[32];
                int timeout = 1000;
                PingOptions pingOptions = new PingOptions();
                PingReply reply = myPing.Send(host, timeout, buffer, pingOptions);
                return (reply.Status == IPStatus.Success);
            }
            catch (Exception)
            {
                return false;
            }
        }

        // Checks guna2textbox for text,
        public static bool textBoxValidation_Alpha(Guna2TextBox tb, String name, ErrorProvider errorProvider)
        {
            String nullField = "is required. Please complete this field to continue";
            String symNumNotAllowed = "is invalid (Symbols and numbers are not allowed)";
            tb.BorderColor = Color.IndianRed;
            tb.BorderThickness = 5;

            //Checks if its empty
            if (validationHelper.checkFieldBlank(tb.Text))
            {
                errorProvider.SetError(tb, $"{name} {nullField}");
                return false;
            }
            // Checks if its alpha only
            else if (!validationHelper.checkFieldAlpha(tb.Text))
            {
                errorProvider.SetError(tb, $"{name} {symNumNotAllowed}");
                return false;
            }
            // Clears the error
            tb.BorderThickness = 1;
            tb.BorderColor = Color.FromArgb(213, 218, 223);
            errorProvider.SetError(tb, null);
            return true;
        }

        // Checks guna2combobox if it user changed the value
        public static bool comboBoxValidation(Guna2ComboBox cb, String validation, ErrorProvider ep)
        {
            if (validationHelper.comboBoxCheck(validation, cb) == false)
            {
                validation = validation.First() + validation.Substring(1, validation.Length - 1);
                ep.SetError(cb, $"{validation} is invalid. Please choose a correct option");
                if (!comboBoxFirstLoad)
                {
                    cb.BorderColor = Color.IndianRed;
                }
                return false;
            }

            cb.BorderColor = Color.FromArgb(213, 218, 223);
            ep.SetError(cb, null);
            return true;
        }

        public static bool comboBoxFirstLoad { get; set; }
        public static bool textBoxValidation_Numeric(Guna2TextBox tb, String name, ErrorProvider errorProvider)
        {
            String nullField = "is required. Please complete this field to continue";
            String symLetter = "is invalid (Only numbers are allowed)";
            tb.BorderColor = Color.IndianRed;
            //Checks if its empty
            if (validationHelper.checkFieldBlank(tb.Text))
            {
                errorProvider.SetError(tb, $"{name} {nullField}");
                return false;
            }
            // Checks if its numeric only
            else if (!validationHelper.checkFieldNumeric(tb.Text))
            {
                errorProvider.SetError(tb, $"{name} {symLetter}");
                return false;
            }
            // Clears the error
            tb.BorderColor = Color.FromArgb(213, 218, 223);
            errorProvider.SetError(tb, null);
            return true;
        }


        //Checks if user changed combobox value
        public static bool comboBoxCheck(String value, Guna2ComboBox cb)
        {
            if(value.ToLower() == cb.Text.ToLower())
                return false;
            else
                return true;
        }

        

        // Checking if user entered a value in required field
        public static bool checkFieldBlank(String tb)
        {
            if (string.IsNullOrEmpty(tb))
            {
                return true;
            }
            return false;
        }

        // Check if user entered alphabets only
        public static bool checkFieldAlpha(String tb)
        {
            if (Regex.IsMatch(tb, "^[a-zA-Z\\s]+$"))
            {
                return true;
            }
            return false;
        }

        // Checks if user entered alphabets and numbers only
        public static bool checkFieldAlphaNumeric(String tb)
        {
            if (Regex.IsMatch(tb, "^[a-zA-Z0-9\\s]+$"))
            {
                return true;
            }
            return false;
        }

        // Check if user entered numbers only
        public static bool checkFieldNumeric(String tb)
        {
            if (Regex.IsMatch(tb, "^[0-9]+$"))
            {
                return true;
            }
            return false;
        }
    }
}
