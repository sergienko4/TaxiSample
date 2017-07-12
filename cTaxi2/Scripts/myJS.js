$(document).ready(function() {
    var drivers = $('[name="driver"]');
    $.each(drivers, function(index, driver) {

        var parts = driver.childNodes[8].nextSibling.innerText.split("/");
        let dateFromForm = new Date(parts[2], parts[1] - 1, parts[0])

        var diff = monthDiff(dateFromForm, new Date(Date.now()));

        if (diff >= 5) {
            if (diff > 5) {
                $('#' + driver.id).css("background-color", "red");
            } else
                $('#' + driver.id).css("background-color", "blue");
        }
    }, this);

});

function monthDiff(d1, d2) {
    var months = 0;
    months = (d2.getFullYear() - d1.getFullYear()) * 12;
    months += (d2.getMonth() + 1);
    months -= (d1.getMonth() + 1);
    if (months > 0)
        return months;
    return 0;
}