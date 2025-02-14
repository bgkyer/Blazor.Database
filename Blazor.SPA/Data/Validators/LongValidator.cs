﻿/// =================================
/// Author: Shaun Curtis, Cold Elm
/// License: MIT
/// ==================================

using Microsoft.AspNetCore.Components.Forms;

namespace Blazor.SPA.Data
{
    public class LongValidator : Validator<long>
    {
        #region Public

        /// <summary>
        /// Class Contructor
        /// </summary>
        /// <param name="value"></param>
        /// <param name="fieldName"></param>
        /// <param name="model"></param>
        /// <param name="validationMessageStore"></param>
        /// <param name="message"></param>
        public LongValidator(long value, string fieldName, object model, ValidationMessageStore validationMessageStore, string message) : base(value, fieldName, model, validationMessageStore, message) { }

        /// <summary>
        /// Check of the value is greater than test
        /// </summary>
        /// <param name="test"></param>
        /// <returns></returns>
        public LongValidator LessThan(long test, string message = null)
        {
            if (!(this.Value < test))
            {
                Trip = true;
                LogMessage(message);
            }
            return this;
        }

        /// <summary>
        /// Check if the value is less than
        /// </summary>
        /// <param name="test"></param>
        /// <returns></returns>
        public LongValidator GreaterThan(long test, string message = null)
        {
            if (!(this.Value > test))
            {
                Trip = true;
                LogMessage(message);
            }
            return this;
        }

        #endregion
    }
    
    public static class LongValidatorExtensions
    {
        /// <summary>
        /// String Validation Extension
        /// </summary>
        /// <param name="value"></param>
        /// <param name="fieldName"></param>
        /// <param name="model"></param>
        /// <param name="validationMessageStore"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static LongValidator Validation(this long value, string fieldName, object model, ValidationMessageStore validationMessageStore, string message = null)
        {
            var validation = new LongValidator(value, fieldName, model, validationMessageStore, message);
            return validation;
        }
    }

}
