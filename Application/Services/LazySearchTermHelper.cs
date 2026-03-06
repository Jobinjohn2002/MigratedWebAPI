using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public partial class LazySearchTermHelper
    {
        /// <summary>
        /// PopulateConcrete operation
        /// </summary>
        public void PopulateConcrete(SearchTerm concreteSearchTerm, SearchTerm genericSearchTerm)
        {
            concreteSearchTerm.SearchTermId = genericSearchTerm.SearchTermId;
            concreteSearchTerm.ObjectTypeId = genericSearchTerm.ObjectTypeId;
            concreteSearchTerm.ObjectId = genericSearchTerm.ObjectId;
            concreteSearchTerm.ObjectUid = genericSearchTerm.ObjectUid;
            concreteSearchTerm.Text = genericSearchTerm.Text;
        }
    }
}