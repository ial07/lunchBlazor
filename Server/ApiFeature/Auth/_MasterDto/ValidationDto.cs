public class ValidationAuthDto
{
    public Dictionary<string, string> ValidateCreateInput(LoginDto items)
    {
        var errors = new Dictionary<string, string>();

        if (items == null || string.IsNullOrEmpty(items.UserID))
        {
            errors["UserID"] = "UserID is a required field.";
        }

        if (items == null || string.IsNullOrEmpty(items.Password))
        {
            errors["Password"] = "Password is a required field.";
        }

        return errors;
    }
}