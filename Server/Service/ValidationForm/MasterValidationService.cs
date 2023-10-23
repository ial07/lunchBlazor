public class MasterValidationService
{
    public Dictionary<string, string> ValidateCreateDevisiInput(CreateDevisiInput items)
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