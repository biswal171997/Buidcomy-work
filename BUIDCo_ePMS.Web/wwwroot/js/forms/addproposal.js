// script.js
$(document).ready(function () {
    BindFyDropdown();
    BindClientDropdown();
    BindCategoryDropdown();
    BindProjectTypeDropdown();
    BindDistrictDropdown();
    BindDirectorDropdown();
    $("#ddlcategory").change(function () {
        BindSubCategoryDropdown($("#ddlcategory").val(), 0);
    });
    $("#ddldistrict").change(function () {
        BindBlockDropdown($("#ddldistrict").val(), 0);
    });
    $("#ddlsiteblock").change(function () {
        BindWardDropdown($("#ddlsiteblock").val(), 0);
    });
    $.validator.addMethod("notEqualTo", function (value, element, param) {
        return this.optional(element) || value != param;
    }, "Please select an option");
    $.validator.addMethod("fileExtension", function (value, element, param) {
        param = typeof param === "string" ? param.replace(/,/g, "|") : "pdf";
        return this.optional(element) || value.match(new RegExp("\\.(" + param + ")$", "i"));
    }, "Only PDF files are allowed");
    $.validator.addMethod("fileSize", function (value, element, param) {
        // Check if the file size is less than param (in bytes)
        return this.optional(element) || (element.files[0] && element.files[0].size <= param);
    }, "File size must be less than 10MB");
    $("#formaddproposal").validate({
        rules: {
            ddlfyyear: { required: true, notEqualTo: "0" },
            ddlclient: { required: true, notEqualTo: "0" },
            txtProposeName: { required: true },
            ddlcategory: { required: true, notEqualTo: "0" },
            ddlsubcategory: { required: true, notEqualTo: "0" },
            ddlprojecttype: { required: true, notEqualTo: "0" },
            ddldistrict: { required: true, notEqualTo: "0" },
            ddldirectorname: { required: true, notEqualTo: "0" },
            ddlblock: { required: true, notEqualTo: "0" },
            txtletternumber: { required: true },
            proposalDate: { required: true, date: true },
            fuproposalletter: {
                required: function () {
                    return $('#hdnproposalid').val() == "0"; // Required only if hdnproposald is 0
                },
                fileExtension: "pdf",
                fileSize: 10 * 1024 * 1024
            },
            txtsubject: { required: true, maxlength: 1000 },
            txtremark: { required: true, maxlength: 200 }
        },
        messages: {
            ddlfyyear: { notEqualTo: "Please select Financial Year" },
            ddlclient: { notEqualTo: "Please select Proposal Submitted By" },
            txtProposeName: { required: "Please enter Proposer Name" },
            ddlcategory: { notEqualTo: "Please select Category" },
            ddlsubcategory: { notEqualTo: "Please select Sub-Category" },
            ddlprojecttype: { notEqualTo: "Please select Project Type" },
            ddldistrict: { notEqualTo: "Please select District" },
            ddldirectorname: { notEqualTo: "Please select Project Director Name" },
            ddlblock: { notEqualTo: "Please select Urban Local Body" },
            txtletternumber: { required: "Please enter Proposal Letter Number" },
            proposalDate: { required: "Please select Proposal Date", date: "Please enter a valid date" },
            fuproposalletter: {
                required: "Please upload Proposal Letter",
                fileExtension: "Only PDF files are allowed",
                fileSize: "File size must be less than 10MB"
            },
            txtsubject: { required: "Please enter Subject", maxlength: "Maximum 1000 characters allowed" },
            txtremark: { required: "Please enter Remark", maxlength: "Maximum 200 characters allowed" }
        },
        submitHandler: function (form) {
            // Form will submit if validation passes
            form.submit();
        },
        errorPlacement: function (error, element) {
            error.css("color", "red");
            error.insertAfter(element.closest(".form-group"));
        },
        highlight: function (element) {
            $(element).removeClass("is-valid");
            $(element).addClass("is-invalid");
            $(element).parent().addClass('error');
        },
        unhighlight: function (element) {
            $(element).removeClass("is-invalid");
            $(element).addClass("is-valid");
            $(element).parent().removeClass('error');
        }
    });
});
function BindFyDropdown() {
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
                $('#ddlfyyear').empty();
                var elements = "<option value='0' selected> Select </option>";
                $.each(data1, function (i, data) {
                    elements += "<option value='" + data.fyId + "'>" + data.fyName + "</option>";
                });
                $('#ddlfyyear').append(elements);
            }
        },
        error: function (Message) {
            alert(Message);
        }
    });
}
function BindSchemeDropdown() {
    $.ajax({
        type: 'Get',
        dataType: 'Json',
        contentType: 'application/json; charset=utf-8',
        data: {},
        url: baseUrl + "Master/Get_Scheme_Master",
        success: function (result) {
            var data1 = JSON.parse(result);
            if (data1.length > 0) {
                $('#ddlscheme').empty();
                var elements = "<option value='0' selected> Select </option>";
                $.each(data1, function (i, data) {
                    elements += "<option value='" + data.schemeId + "'>" + data.SchemeName + "</option>";
                });
                $('#ddlscheme').append(elements);
            }
        },
        error: function (Message) {
            alert(Message);
        }
    });
}
function BindClientDropdown() {
    $.ajax({
        type: 'Get',
        dataType: 'Json',
        contentType: 'application/json; charset=utf-8',
        data: {},
        url: baseUrl + "CommonFunction/GetClient",
        success: function (result) {
            var data1 = JSON.parse(result.data);
            if (data1.length > 0) {
                $('#ddlclient').empty();
                var elements = "<option value='0' selected> Select </option>";
                $.each(data1, function (i, data) {
                    elements += "<option value='" + data.ClientId + "'>" + data.ClientName + "</option>";
                });
                $('#ddlclient').append(elements);
            }
        },
        error: function (Message) {
            alert(Message);
        }
    });
}
function BindCategoryDropdown() {
    $.ajax({
        type: 'Get',
        dataType: 'Json',
        contentType: 'application/json; charset=utf-8',
        data: {},
        url: baseUrl + "CommonFunction/GetCategory",
        success: function (result) {
            var data1 = JSON.parse(result.data);
            if (data1.length > 0) {
                $('#ddlcategory').empty();
                var elements = "<option value='0' selected> Select </option>";
                $.each(data1, function (i, data) {
                    elements += "<option value='" + data.categoryId + "'>" + data.categoryName + "</option>";
                });
                $('#ddlcategory').append(elements);
            }
        },
        error: function (Message) {
            alert(Message);
        }
    });
}
function BindSubCategoryDropdown(categoryId, subcategoryid) {
    $.ajax({
        type: 'Get',
        dataType: 'Json',
        contentType: 'application/json; charset=utf-8',
        data: { Id: categoryId },
        url: baseUrl + "CommonFunction/GetSubCategory",
        success: function (result) {
            var data1 = JSON.parse(result.data);
            $('#ddlsubcategory').empty();
            var elements = "<option value='0' selected> Select </option>";
            if (data1.length > 0) {
                $.each(data1, function (i, data) {
                    if (subcategoryid == data.subCategoryId) {
                        elements += "<option value='" + data.subCategoryId + "' selected>" + data.subCategoryName + "</option>";
                    }
                    else {
                        elements += "<option value='" + data.subCategoryId + "'>" + data.subCategoryName + "</option>";
                    }
                });
                $('#ddlsubcategory').append(elements);
            }
        },
        error: function (Message) {
            alert(Message);
        }
    });
}
function BindProjectTypeDropdown() {
    $.ajax({
        type: 'Get',
        dataType: 'Json',
        contentType: 'application/json; charset=utf-8',
        data: {},
        url: baseUrl + "CommonFunction/GetProjectType",
        success: function (result) {
            var data1 = JSON.parse(result.data);
            if (data1.length > 0) {
                $('#ddlprojecttype').empty();
                var elements = "<option value='0' selected> Select </option>";
                $.each(data1, function (i, data) {
                    elements += "<option value='" + data.typeId + "'>" + data.projectType + "</option>";
                });
                $('#ddlprojecttype').append(elements);
            }
        },
        error: function (Message) {
            alert(Message);
        }
    });
}
function BindDistrictDropdown() {
    $.ajax({
        type: 'Get',
        dataType: 'Json',
        contentType: 'application/json; charset=utf-8',
        data: {},
        url: baseUrl + "CommonFunction/GetDistrict",
        success: function (result) {
            var data1 = JSON.parse(result.data);
            $('#ddldistrict').empty();
            $('#ddlsitedistrict').empty();
            var elements = "<option value='0' selected> Select </option>";
            if (data1.length > 0) {
                $.each(data1, function (i, data) {
                    elements += "<option value='" + data.levelDetailId + "'>" + data.levelName + "</option>";
                    
                });
                $('#ddldistrict').append(elements);
                $('#ddlsitedistrict').append(elements);
            }
        },
        error: function (Message) {
            alert(Message);
        }
    });
}
function BindBlockDropdown(Id, blockid) {
    return new Promise((resolve, reject) => {
        $.ajax({
            type: 'Get',
            dataType: 'Json',
            contentType: 'application/json; charset=utf-8',
            data: { Id: Id },
            url: baseUrl + "CommonFunction/GetBlock",
            success: function (result) {
                var data1 = JSON.parse(result.data);
                $('#ddlddlblock').empty();
                $('#ddlsiteblock').empty();
                var elements = "<option value='0' selected> Select </option>";
                if (data1.length > 0) {
                    $.each(data1, function (i, data) {
                        if (blockid == data.levelDetailId) {
                            elements += "<option value='" + data.levelDetailId + "' selected>" + data.levelName + "</option>";
                        }
                        else {
                            elements += "<option value='" + data.levelDetailId + "'>" + data.levelName + "</option>";
                        }

                    });
                    $('#ddlblock').append(elements);
                    $('#ddlsiteblock').append(elements);
                }
                resolve();
            },
            error: function (Message) {
                alert(Message);
            }
        });
    });
}
function BindWardDropdown(Id, wardid) {
    $.ajax({
        type: 'Get',
        dataType: 'Json',
        contentType: 'application/json; charset=utf-8',
        data: { Id: Id },
        url: baseUrl + "CommonFunction/GetWard",
        success: function (result) {
            debugger
            var data1 = JSON.parse(result.data);
            $('#ddlsiteward').empty();
            var elements = "<option value='0' selected> Select </option>";
            if (data1.length > 0) {
                $.each(data1, function (i, data) {
                    debugger
                    if (wardid == data.levelDetailId) {
                        elements += "<option value='" + data.levelDetailId + "' selected>" + data.levelName + "</option>";
                    }
                    else {
                        elements += "<option value='" + data.levelDetailId + "'>" + data.levelName + "</option>";
                    }

                });
                $('#ddlsiteward').append(elements);
            }
        },
        error: function (Message) {
            alert(Message);
        }
    });
}
function BindDirectorDropdown() {
    $.ajax({
        type: 'Get',
        dataType: 'Json',
        contentType: 'application/json; charset=utf-8',
        data: {},
        url: baseUrl + "CommonFunction/GetDirector",
        success: function (result) {
            var data1 = JSON.parse(result.data);
            $('#ddldirectorname').empty();
            var elements = "<option value='0' selected> Select </option>";
            if (data1.length > 0) {
                $.each(data1, function (i, data) {
                    elements += "<option value='" + data.directorId + "'>" + data.directorname + "</option>";
                });
                $('#ddldirectorname').append(elements);
            }
        },
        error: function (Message) {
            alert(Message);
        }
    });
}
function AddProposal() {
    $('#btnproposalsubmit').text('Submit');
    $('#btnproposalreset').text('Reset');
    $("#formaddproposal").validate().resetForm();
    $("#formaddproposal").find(".is-valid, .is-invalid").removeClass("is-valid is-invalid");
    $("#formaddproposal").find(".error").removeClass("error");
    $('.LengthRemarks').trigger('blur');
    $('#formaddproposal')[0].reset();
    $('#aletterDocPath').hide();
    $('#addProposal').modal('show');
}
function SaveProposalLetter() {
    if ($("#formaddproposal").valid()) {
        var formData = new FormData();

        formData.append("proposalid", $('#hdnproposalid').val());
        formData.append("fyId", $.trim($("#ddlfyyear").val()));
        formData.append("submittedByid", $.trim($("#ddlclient").val()));
        formData.append("proposalName", $.trim($("#txtProposeName").val()));
        formData.append("categoryid", $.trim($("#ddlcategory").val()));
        formData.append("subCategoryid", $.trim($("#ddlsubcategory").val()));
        formData.append("projectTypeid", $.trim($("#ddlprojecttype").val()));
        formData.append("districtid", $.trim($("#ddldistrict").val()));
        formData.append("officerId", $.trim($("#ddldirectorname").val()));
        formData.append("ulbId", $.trim($("#ddlblock").val()));
        formData.append("letterNo", $.trim($("#txtletternumber").val()));
        formData.append("proposalLetterDate", $.trim($("#proposalDate").val()));
        formData.append("letterDocPath", $.trim($("#hdnletterDocPath").val()));
        formData.append("subject", $.trim($("#txtsubject").val()));
        formData.append("remarks", $.trim($("#txtremark").val()));

        // ✅ Append File from input type="file"
        var fileInput = $('#fuproposalletter')[0].files[0];
        if (fileInput) {
            formData.append("letterDocFile", fileInput); // 👈 This is important (property name matches C# property)
        }
        var proposald = $('#hdnproposalid').val() || 0;
        let dynamicMsg = proposald == 0 ? "Save" : "Update";

        Swal.fire({
            title: 'Are you sure?',
            text: "You won't be able to revert this!",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Yes, ' + dynamicMsg + ' it!'
        }).then((result) => {
            if (result.isConfirmed) {
                $.ajax({
                    type: "POST",
                    url: baseUrl + "Proposal/SaveProposal",
                    beforeSend: function (xhr) {
                        xhr.setRequestHeader("XSRF-TOKEN", $('input:hidden[name="__RequestVerificationToken"]').val());
                    },
                    data: formData,
                    processData: false, // **Important for FormData**
                    contentType: false, // **Important for FormData**
                    success: function (result) {
                        Swal.fire({
                            icon: result.sucess ? 'success' : 'error',
                            title: result.responseText,
                            text: result.responseMessage,
                        }).then((result) => {
                            if (result.isConfirmed) {
                                location.href = baseUrl + "Proposal/CreateProposal";
                            }
                        })
                    },
                    error: function (result) {
                        Swal.fire({
                            icon: 'error',
                            title: result.responseText,
                            text: result.responseMessage,
                        });
                    }
                });
            }
        });
    }
}
function EditProposalLetter(proposalid) {
    debugger
    $.ajax({
        type: 'Get',
        dataType: 'Json',
        contentType: 'application/json; charset=utf-8',
        data: { proposalid: proposalid },
        url: baseUrl + "Proposal/GetProposalByID",
        success: function (result) {
            debugger
            var data = JSON.parse(result);
            var data1 = JSON.parse(data.data)
            $('#hdnproposalid').val(data1.proposalid);
            $('#ddlfyyear').val(data1.fyId);
            $('#ddlclient').val(data1.submittedByid);
            $('#txtProposeName').val(data1.proposalName);
            $('#ddlcategory').val(data1.categoryid);
            BindSubCategoryDropdown($('#ddlcategory').val(), data1.subCategoryid);
            $('#ddlsubcategory').val(data1.subCategoryid);
            $('#ddlprojecttype').val(data1.projectTypeid);
            $('#ddldistrict').val(data1.districtid);
            BindBlockDropdown($("#ddldistrict").val(), data1.ulbId);
            $('#ddldirectorname').val(data1.officerId);
            $('#txtletternumber').val(data1.letterNo);
            $('#proposalDate').val(formatDate(data1.proposalLetterDate));
            $('#hdnletterDocPath').val(data1.letterDocPath);
            var url = baseUrl + 'Proposal/DownloadFiles?filename=' + data1.letterDocPath + '&filepath=' + _encodedpath +'';
            $('#aletterDocPath').attr("href", url);
            $('#aletterDocPath').show();
            $('#txtsubject').val(data1.subject);
            $('#txtremark').val(data1.remarks);
        },
        error: function (Message) {
            alert(Message);
        }
    });
    $('#btnproposalsubmit').text('Update');
    $('#btnproposalreset').text('Cancel');
    $("#formaddproposal").validate().resetForm();
    $("#formaddproposal").find(".is-valid, .is-invalid").removeClass("is-valid is-invalid");
    $("#formaddproposal").find(".error").removeClass("error");
    $('.LengthRemarks').trigger('blur');
    $('#addProposal').modal('show');
}
function SubmitProposalLetter() {
    if ($("#formaddproposal").valid()) {
        Swal.fire({
            title: 'Are you sure?',
            text: "You won't be able to revert this!",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Yes, Submit it!'
        }).then((result) => {
            if (result.isConfirmed) {
                var formData = new FormData();

                formData.append("proposalid", $('#hdnsubmitproposalid').val());
                $.ajax({
                    type: "POST",
                    url: baseUrl + "Proposal/SubmitProposal",
                    data: formData,
                    beforeSend: function (xhr) {
                        xhr.setRequestHeader("XSRF-TOKEN", $('input:hidden[name="__RequestVerificationToken"]').val());
                    },
                    data: formData,
                    processData: false, // **Important for FormData**
                    contentType: false, // **Important for FormData**
                    success: function (result) {
                        Swal.fire({
                            icon: result.sucess ? 'success' : 'error',
                            title: result.responseText,
                            text: result.responseMessage,
                        }).then((result) => {
                            if (result.isConfirmed) {
                                location.href = baseUrl + "Proposal/CreateProposal";
                            }
                        })
                    },
                    error: function (result) {
                        Swal.fire({
                            icon: 'error',
                            title: result.responseText,
                            text: result.responseMessage,
                        });
                    }
                });
            }
        });
    }
}
function CancelProposalLetter(proposalid) {
    console.log(proposalid);
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, Cancel it!'
    }).then((result) => {
        if (result.isConfirmed) {
            var formData = new FormData();

            formData.append("proposalid", proposalid);
            $.ajax({
                type: "POST",
                data: formData,
                url: baseUrl + "Proposal/CancelProposal",
                beforeSend: function (xhr) {
                    xhr.setRequestHeader("XSRF-TOKEN", $('input:hidden[name="__RequestVerificationToken"]').val());
                },
                processData: false, // **Important for FormData**
                contentType: false, // **Important for FormData**
                success: function (result) {
                    Swal.fire({
                        icon: result.sucess ? 'success' : 'error',
                        title: result.responseText,
                        text: result.responseMessage,
                    }).then((result) => {
                        if (result.isConfirmed) {
                            location.href = baseUrl + "Proposal/CreateProposal";
                        }
                    })
                },
                error: function (result) {
                    Swal.fire({
                        icon: 'error',
                        title: result.responseText,
                        text: result.responseMessage,
                    });
                }
            });
        }
    });
}
function resetaddproposal(ctrl) {
    debugger
    var $ctrl = $(ctrl);
    if ($ctrl.text().trim() === "Reset") {
        debugger
        $("#formaddproposal").validate().resetForm();
        $("#formaddproposal").find(".is-valid, .is-invalid").removeClass("is-valid is-invalid");
        $("#formaddproposal").find(".error").removeClass("error");
        $("#formaddproposal")[0].reset();
    }
    else {
        $("#addProposal").modal("hide");
    }
}
