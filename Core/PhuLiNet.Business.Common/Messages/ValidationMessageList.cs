using System;
using System.Collections.Generic;

namespace PhuLiNet.Business.Common.Messages
{
    [Serializable()]
    public class ValidationMessageList : List<IValidationMessage>, ICloneable
    {
        public ValidationMessageList()
        {
        }

        /// <summary>
        /// Gets the number of messages in
        /// the list that have a severity
        /// of Error.
        /// </summary>
        /// <value>An integer value.</value>
        public int CountError
        {
            get
            {
                int errorCount = 0;

                foreach (IValidationMessage message in this)
                {
                    if (message.Severity == MessageSeverity.Error)
                    {
                        errorCount++;
                    }
                }

                return errorCount;
            }
        }

        /// <summary>
        /// Gets the number of messages in
        /// the list that have a severity
        /// of Warning.
        /// </summary>
        /// <value>An integer value.</value>
        public int CountWarning
        {
            get
            {
                int warningCount = 0;

                foreach (IValidationMessage message in this)
                {
                    if (message.Severity == MessageSeverity.Warning)
                    {
                        warningCount++;
                    }
                }

                return warningCount;
            }
        }

        /// <summary>
        /// Gets the number of messages in
        /// the list that have a severity
        /// of Information.
        /// </summary>
        /// <value>An integer value.</value>
        public int CountInformation
        {
            get
            {
                int infoCount = 0;

                foreach (IValidationMessage message in this)
                {
                    if (message.Severity == MessageSeverity.Information)
                    {
                        infoCount++;
                    }
                }

                return infoCount;
            }
        }

        #region ICloneable Members

        object ICloneable.Clone()
        {
            return GetClone();
        }

        #endregion

        public ValidationMessageList Clone()
        {
            return GetClone();
        }

        private ValidationMessageList GetClone()
        {
            var clone = new ValidationMessageList();

            foreach (ValidationMessage message in this)
            {
                clone.Add(message.Clone());
            }

            return clone;
        }
    }
}