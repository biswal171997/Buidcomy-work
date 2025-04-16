$(document).ready(function () {
    debugger;
    SearchFyDropdown();
    SearchClientDropdown();
    SearchCategoryDropdown();
    SearchProjectTypeDropdown();
    SearchDistrictDropdown();
    $("#ddlsearch_category").change(function () {
        SearchSubCategoryDropdown($("#ddlsearch_category").val());
    });
    $("#ddlsearch_district").change(function () {
        SearchUlbDropdown($("#ddlsearch_district").val());
    });
});
function SearchFyDropdown() {
    debugger
    $.ajax({
        type: 'Get',
        dataType: 'Json',
        contentType: 'application/json; charset=utf-8',
        data: {},
        url: baseUrl + "CommonFunction/GetFinancialYear",
        success: function (result) {
            console.log(result);
            var data1 = JSON.parse(result.data);
            if (data1.length > 0) {
                $('#ddlsearch_fyyear').empty();
                var elements = "<option value='0' selected> Select </option>";
                $.each(data1, function (i, data) {
                    elements += "<option value='" + data.fyId + "'>" + data.fyName + "</option>";
                });
                $('#ddlsearch_fyyear').append(elements);
            }
        },
        error: function (Message) {
            alert(Message);
        }
    });
}
function SearchClientDropdown() {
    $.ajax({
        type: 'Get',
        dataType: 'Json',
        contentType: 'application/json; charset=utf-8',
        data: {},
        url: baseUrl + "CommonFunction/GetClient",
        success: function (result) {
            var data1 = JSON.parse(result.data);
            if (data1.length > 0) {
                $('#ddlsearch_client').empty();
                var elements = "<option value='0' selected> Select </option>";
                $.each(data1, function (i, data) {
                    elements += "<option value='" + data.ClientId + "'>" + data.ClientName + "</option>";
                });
                $('#ddlsearch_client').append(elements);
            }
        },
        error: function (Message) {
            alert(Message);
        }
    });
}
function SearchCategoryDropdown() {
    $.ajax({
        type: 'Get',
        dataType: 'Json',
        contentType: 'application/json; charset=utf-8',
        data: {},
        url: baseUrl + "CommonFunction/GetCategory",
        success: function (result) {
            var data1 = JSON.parse(result.data);
            if (data1.length > 0) {
                $('#ddlsearch_category').empty();
                var elements = "<option value='0' selected> Select </option>";
                $.each(data1, function (i, data) {
                    elements += "<option value='" + data.categoryId + "'>" + data.categoryName + "</option>";
                });
                $('#ddlsearch_category').append(elements);
            }
        },
        error: function (Message) {
            alert(Message);
        }
    });
}
function SearchSubCategoryDropdown(categoryId) {
    $.ajax({
        type: 'Get',
        dataType: 'Json',
        contentType: 'application/json; charset=utf-8',
        data: { Id: categoryId },
        url: baseUrl + "CommonFunction/GetSubCategory",
        success: function (result) {
            var data1 = JSON.parse(result.data);
            $('#ddlsearch_subcategory').empty();
            var elements = "<option value='0' selected> Select </option>";
            if (data1.length > 0) {
                $.each(data1, function (i, data) {
                    elements += "<option value='" + data.subCategoryId + "'>" + data.subCategoryName + "</option>";
                });
                $('#ddlsearch_subcategory').append(elements);
            }
        },
        error: function (Message) {
            alert(Message);
        }
    });
}
function SearchProjectTypeDropdown() {
    $.ajax({
        type: 'Get',
        dataType: 'Json',
        contentType: 'application/json; charset=utf-8',
        data: {},
        url: baseUrl + "CommonFunction/GetProjectType",
        success: function (result) {
            var data1 = JSON.parse(result.data);
            if (data1.length > 0) {
                $('#ddlsearch_projecttype').empty();
                var elements = "<option value='0' selected> Select </option>";
                $.each(data1, function (i, data) {
                    elements += "<option value='" + data.typeId + "'>" + data.projectType + "</option>";
                });
                $('#ddlsearch_projecttype').append(elements);
            }
        },
        error: function (Message) {
            alert(Message);
        }
    });
}
function SearchDistrictDropdown() {
    $.ajax({
        type: 'Get',
        dataType: 'Json',
        contentType: 'application/json; charset=utf-8',
        data: {},
        url: baseUrl + "CommonFunction/GetDistrict",
        success: function (result) {
            var data1 = JSON.parse(result.data);
            $('#ddlsearch_district').empty();
            var elements = "<option value='0' selected> Select </option>";
            if (data1.length > 0) {
                $.each(data1, function (i, data) {
                    elements += "<option value='" + data.levelDetailId + "'>" + data.levelName + "</option>";
                    
                });
                $('#ddlsearch_district').append(elements);
            }
        },
        error: function (Message) {
            alert(Message);
        }
    });
}
function SearchUlbDropdown(Id) {
    $.ajax({
        type: 'Get',
        dataType: 'Json',
        contentType: 'application/json; charset=utf-8',
        data: { Id: Id },
        url: baseUrl + "CommonFunction/GetBlock",
        success: function (result) {
            var data1 = JSON.parse(result.data);
            $('#ddlsearch_ulb').empty();
            var elements = "<option value='0' selected> Select </option>";
            if (data1.length > 0) {
                $.each(data1, function (i, data) {
                    elements += "<option value='" + data.levelDetailId + "'>" + data.levelName + "</option>";

                });
                $('#ddlsearch_ulb').append(elements);
            }
        },
        error: function (Message) {
            alert(Message);
        }
    });
}

