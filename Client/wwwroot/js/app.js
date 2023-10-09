
window.clickElementById = function (elementId) {
    console.log(elementId);
    var element = document.getElementById(elementId);
    if (element) {
        element.click();
    }
};

