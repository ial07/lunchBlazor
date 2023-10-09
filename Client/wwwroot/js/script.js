window.initializeMultiselect = function (elementId, options,selectedValues)  {
    // Get the DOM element by ID
    const element = document.getElementById(elementId);

    // Initialize the multiselect widget with options
    $(element).multiselect({
        enableFiltering: true,
        maxHeight: 200,
        data: options
    });
};