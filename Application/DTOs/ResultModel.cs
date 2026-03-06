using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// ValidationModel
    /// </summary>
    public class ValidationModel<TValidationError>
    {
        public ValidationModel()
        {
            Errors = new List<TValidationError>();
        }

        public ValidationModel(TValidationError validationError)
        {
            Errors = new List<TValidationError>();
            AddError(validationError);
        }

        public bool Success => Errors.Count == 0;

        /// <summary>
        /// Gets or sets Errors
        /// </summary>
        public List<TValidationError> Errors { get; set; }

        /// <summary>
        /// AddError operation
        /// </summary>
        public ValidationModel<TValidationError> AddError(TValidationError validationError)
        {
            Errors.Add(validationError);
            return this;
        }

        /// <summary>
        /// AddErrors operation
        /// </summary>
        public ValidationModel<TValidationError> AddErrors(IEnumerable<TValidationError> validationErrors)
        {
            Errors.AddRange(validationErrors);
            return this;
        }
    }

    /// <summary>
    /// ResultModel
    /// </summary>
    public class ResultModel<TResult, TValidationError> : ValidationModel<TValidationError>
    {
        public ResultModel()
        {
            Errors = new List<TValidationError>();
        }

        public ResultModel(TResult result)
        {
            Errors = new List<TValidationError>();
            Result = result;
        }

        /// <summary>
        /// Gets or sets Result
        /// </summary>
        public TResult Result { get; set; }

        /// <summary>
        /// AddError operation
        /// </summary>
        public ResultModel<TResult, TValidationError> AddError(TValidationError validationError)
        {
            base.AddError(validationError);
            return this;
        }

        /// <summary>
        /// AddErrors operation
        /// </summary>
        public ResultModel<TResult, TValidationError> AddErrors(IEnumerable<TValidationError> validationErrors)
        {
            base.AddErrors(validationErrors);
            return this;
        }
    }
}
