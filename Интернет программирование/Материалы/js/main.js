function fillSelect(selectElement, values) {
    $(selectElement).html("");
    $.each(values, function (key, value) {
        $(selectElement).append(
            "<option value=\"" + value.id + "\">" + value.name + "</option>"
        );
    });
}

function createInputWithLabel(labelText, inputId) {
    return $("<div> class='form-group'")
        .append("<label>" + labelText + "</label>")
        .append("<input class='form-control' type='text' id = '" + inputId + "'/>")
}

function get(url, callBack) {
    $.ajax({
        url: url,
        cache: false,
        success: function (response) {
            if (!isEmpty(callBack)) {
                callBack(response);
            }
        }
    });
}

function post(url, postData, callBack) {
    $.ajax({
        url: url,
        cache: false,
        dataType: "json",
        data: JSON.stringify(postData),
        contentType: "application/json; charset=utf-8",
        processData: false,
        method: "POST",
        complete: function (data) {
            if (!isEmpty(callBack)) {
                callBack(data.responseText);
            }
        }
    });
}

function isEmpty(value) {
    if (typeof  value === "function") {
        return false;
    }
    return (value == null || value.length === 0);
}