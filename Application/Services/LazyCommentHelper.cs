using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyCommentHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(Comment concreteComment, Comment genericComment)
        {
					
			concreteComment.CommentId = genericComment.CommentId;			
			concreteComment.CreatedOn = genericComment.CreatedOn;			
			concreteComment.CreatedBy = genericComment.CreatedBy;			
			concreteComment.CommentContext = genericComment.CommentContext;			
			concreteComment.Text = genericComment.Text;
		}
	}
}
		