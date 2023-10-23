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
}