using Microsoft.IdentityModel.Tokens;

public class ValidationDto
{
    public Dictionary<string, string> ValidateCreateInput(CreateDto items)
    {
        var errors = new Dictionary<string, string>();

        if (items == null || string.IsNullOrEmpty(items.Name))
        {
            errors["Name"] = "Name is a required field.";
        }

        if (items == null || string.IsNullOrEmpty(items.Image))
        {
            errors["Image"] = "Image is a required field.";
        }

        return errors;
    }

    public Dictionary<string, string> ValidateUpdateInput(UpdateDto items)
    {
        var errors = new Dictionary<string, string>();

        if (items == null || string.IsNullOrEmpty(items.Name))
        {
            errors["Name"] = "Name is a required field.";
        }

        if (items == null || string.IsNullOrEmpty(items.Image))
        {
            errors["Image"] = "Image is a required field.";
        }

        return errors;
    }

    public Dictionary<string, string> ValidateCreateHistoryInput(CreateHistoryMpp items)
    {
        var errors = new Dictionary<string, string>();

        if (items == null || string.IsNullOrEmpty(items.UserId.ToString()))
        {
            errors["UserId"] = "UserId is a required field.";
        }

        if (items == null || string.IsNullOrEmpty(items.MppId.ToString()))
        {
            errors["MppId"] = "MppId is a required field.";
        }

        if (items == null || string.IsNullOrEmpty(items.Notes))
        {
            errors["Notes"] = "Notes is a required field.";
        }

        return errors;
    }
}