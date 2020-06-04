$(document).ready(() => {
    $('#getStudents').on('click', getStudents);
    $('#getStudent').on('click', getStudent);
    $('#loadStudents').on('click', apiLoadStudents);
    $('#loadStudent').on('click', apiLoadStudent);
    $('#loadStudentPageFragment').on('click', loadPartialElementFromControllerAction);

    loadScript();
});

//Load another JS script inside JS
function loadScript() {
    $.getScript('scripts/testFetchScriptWithJS.js');
}

//AJAX API Call + Insert returned data into page - NEW way and OLD way
function getStudents() {
    let ajax = $.ajax({
        url: "/api/studentapi"
    })
    ajax.done(function (data) {
            if (data)
                populateReturnedData(data);
        })
    ajax.fail(
            function () { alert("fail") }
        );
}

function getStudent() {
    var id = $('#getStudentId').val();
    if (id && $.isNumeric(id)) {
        $.ajax({
            url: "/api/studentapi/" + id,
            success: function (data) {
                if (data)
                    populateReturnedData([data]);
                else
                    alert("nodata");
            },
            failure: function () { alert("fail") }
        }
        );
    }
}

//JQuery Load Data from api
function apiLoadStudents() {
    $('#loadStudentData').load("/api/studentapi");
}
function apiLoadStudent() {
    var id = $('#getStudentId').val();
    if (id && $.isNumeric(id)) {
        $('#loadStudentData').load("/api/studentapi/" + id);
    }
}

//Fetch a section of HTML from the returned data
function loadPartialElementFromControllerAction() {
    $('#loadPageFragment').load("/Student table");
}

//Create HTML elements for data
function populateReturnedData(data) {
    let target = $('#getStudentData');
    target.empty();
    var table = $("<table class='table'><tr><th>FirstName</th><th>LastName</th></tr></table>");
    $.each(data, (index, item) => {
        table.append("<tr><td>" + item.FirstMidName + "</td><td>" + item.LastName + "</td></tr>");
    });
    target.append(table);
}