using Fluent.Users.Models;
using FluentValidation;

namespace Fluent.Users.Validation
{
    public class userValidation : AbstractValidator<useValid>
    {
		public userValidation()
		{
			RuleFor(x => x.passWord).Length(0, 3).WithMessage("Name length is not vaild");
			
			RuleFor(x => x.Email).EmailAddress().WithMessage("Email Is Required");
 		}
	}
}
