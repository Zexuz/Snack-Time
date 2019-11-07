using GraphQL.Validation;

namespace SnackTime.GraphQL
{
    public class InputValidationRule : IValidationRule
    {
        public INodeVisitor Validate(ValidationContext context)
        {
            return new EnterLeaveListener(_ =>
            {
            });
        }
    }
}