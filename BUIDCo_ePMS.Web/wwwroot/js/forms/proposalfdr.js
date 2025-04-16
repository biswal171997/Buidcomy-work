$(document).ready(function () {
    BindConsultantDropdown();
    $("#formfdr").validate({
        rules: {
            ddlfdrpreparedby: { required: true, notEqualTo: "0" },
            txtfdrSubmitteddate: { required: true },
            txtfdragencyname: { required: true },
            txtfdrloaDate: { required: true },
            txtfdrloaNo: { required: true },
            txtfdrduration: { required: true },
            fufdrloaletter: {
                required: function () {
                    return $('#hdnfdrId').val() == "0"; // Required only if hdnproposald is 0
                },
                fileExtension: "pdf",
                fileSize: 10 * 1024 * 1024
            },
            fufdrppt: {
                required: function () {
                    return $('#hdnfdrId').val() == "0"; // Required only if hdnproposald is 0
                },
                fileExtension: "pdf",
                fileSize: 10 * 1024 * 1024
            },
            fufdrestimate: {
                required: function () {
                    return $('#hdnfdrId').val() == "0"; // Required only if hdnproposald is 0
                },
                fileExtension: "pdf",
                fileSize: 10 * 1024 * 1024
            },
            fufdrmap: {
                required: function () {
                    return $('#hdnfdrId').val() == "0"; // Required only if hdnproposald is 0
                },
                fileExtension: "pdf",
                fileSize: 10 * 1024 * 1024
            },
            fufdrdesign: {
                required: function () {
                    return $('#hdnfdrId').val() == "0"; // Required only if hdnproposald is 0
                },
                fileExtension: "pdf",
                fileSize: 10 * 1024 * 1024
            },
        },
        messages: {
            ddlfdrpreparedby: { notEqualTo: "Please select FDR Prepared by" },
            txtfdrSubmitteddate: { required: "Please select FDR submitted/Approved Date" },
            txtfdragencyname: { required: "Please enter Name of Agency/Consultant" },
            txtfdrloaDate: { required: "Please enter LOA Date" },
            txtfdrloaNo: { required: "Please enter LOA Letter No." },
            txtfdrduration: { required: "Please enter Work duration (In days)" },
            fufdrloaletter: {
                required: "Please upload Upload LOA letter",
                fileExtension: "Only PDF files are allowed",
                fileSize: "File size must be less than 10MB"
            },
            fufdrppt: {
                required: "Please Upload Presentation PPT",
                fileExtension: "Only PDF files are allowed",
                fileSize: "File size must be less than 10MB"
            },
            fufdrestimate: {
                required: "Please Upload PDF of Estimation and FDR",
                fileExtension: "Only PDF files are allowed",
                fileSize: "File size must be less than 10MB"
            },
            fufdrmap: {
                required: "Please Upload Map Layout",
                fileExtension: "Only PDF files are allowed",
                fileSize: "File size must be less than 10MB"
            },
            fufdrdesign: {
                required: "Please Upload Design Layout",
                fileExtension: "Only PDF files are allowed",
                fileSize: "File size must be less than 10MB"
            },
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
function BindConsultantDropdown() {
    $.ajax({
        type: 'Get',
        dataType: 'Json',
        contentType: 'application/json; charset=utf-8',
        data: {},
        url: baseUrl + "CommonFunction/GetConsultant",
        success: function (result) {
            var data1 = JSON.parse(result.data);
            console.log(data1);
            if (data1.length > 0) {
                $('#ddlfdrpreparedby').empty();
                var elements = "<option value='0' selected> Select </option>";
                $.each(data1, function (i, data) {
                    elements += "<option value='" + data.ID + "'>" + data.consultantName + "</option>";
                });
                $('#ddlfdrpreparedby').append(elements);
            }
        },
        error: function (Message) {
            alert(Message);
        }
    });
}
function AddFDR(proposalid, fdrid) {
    $('#hdnfdrproposalid').val(proposalid);
    $('#hdnfdrId').val(fdrid);
    $('#btnfdrsubmit').text('Submit');
    $('#btnfdrreset').text('Reset');
    $("#formfdr").validate().resetForm();
    $("#formfdr").find(".is-valid, .is-invalid").removeClass("is-valid is-invalid");
    $("#formfdr").find(".error").removeClass("error");
    $('#formfdr')[0].reset();
    $('#fdrmodal').modal('show');
    $('#afdrloaletterfile').hide();
    $('#afdrpptfile').hide();
    $('#afdrmapfile').hide();
    $('#afdrdesignfile').hide();
    $('#afdrestimatefile').hide();
}
function EditFDR(proposalid, fdrid) {
    debugger
    $.ajax({
        type: 'Get',
        dataType: 'Json',
        contentType: 'application/json; charset=utf-8',
        data: { Id: fdrid },
        url: baseUrl + "Proposal/GetProposalFDRByID",
        success: function (result) {
            debugger
            var data = JSON.parse(result);
            var data1 = JSON.parse(data.data)
            $('#hdnfdrproposalid').val(data1.proposalId);
            $('#hdnfdrId').val(data1.fdrId);
            $('#ddlfdrpreparedby').val(data1.preparedBy);
            $('#txtfdrSubmitteddate').val(formatDate(data1.submittedOn));
            $('#txtfdragencyname').val(data1.agencyName);
            $('#txtfdrloaDate').val(formatDate(data1.loaDate));
            $('#txtfdrloaNo').val(data1.loaNo);
            $('#txtfdrduration').val(data1.duration);

            $('#afdrloaletterfile').attr("href", baseUrl + 'Proposal/DownloadFiles?filename=' + data1.loaLetterPath + '&filepath=' + _encodedpath + '');
            $('#hdrfdrloaletterfile').val(data1.loaLetterPath);
            $('#afdrloaletterfile').show();

            $('#afdrpptfile').attr("href", baseUrl + 'Proposal/DownloadFiles?filename=' + data1.pptPath + '&filepath=' + _encodedpath + '');
            $('#hdrfdrpptfile').val(data1.pptPath);
            $('#afdrpptfile').show();

            $('#afdrmapfile').attr("href", baseUrl + 'Proposal/DownloadFiles?filename=' + data1.mapPath + '&filepath=' + _encodedpath + '');
            $('#hdrfdrmapfile').val(data1.mapPath);
            $('#afdrmapfile').show();

            $('#afdrdesignfile').attr("href", baseUrl + 'Proposal/DownloadFiles?filename=' + data1.designLayout + '&filepath=' + _encodedpath + '');
            $('#hdrfdrdesignfile').val(data1.designLayout);
            $('#afdrdesignfile').show();

            $('#afdrestimatefile').attr("href", baseUrl + 'Proposal/DownloadFiles?filename=' + data1.fdrPath + '&filepath=' + _encodedpath + '');
            $('#hdrfdrestimatefile').val(data1.fdrPath);
            $('#afdrestimatefile').show();

            $('#btnfdrsubmit').text('Update');
            $('#btnfdrreset').text('Cancel');
            $("#formfdr").validate().resetForm();
            $("#formfdr").find(".is-valid, .is-invalid").removeClass("is-valid is-invalid");
            $("#formfdr").find(".error").removeClass("error");
            $('#fdrmodal').modal('show');
            $('#afdrloaletterfile').show();
            $('#afdrpptfile').show();
            $('#afdrmapfile').show();
            $('#afdrdesignfile').show();
            $('#afdrestimatefile').show();
        },
        error: function (Message) {
            alert(Message);
        }
    });
}
function SaveFDR() {
    if ($("#formfdr").valid()) {
        var formData = new FormData();
        formData.append("proposalId", $.trim($("#hdnfdrproposalid").val()));
        formData.append("fdrId", $.trim($("#hdnfdrId").val()));
        formData.append("preparedBy", $.trim($("#ddlfdrpreparedby").val()));
        formData.append("submittedOn", $.trim($("#txtfdrSubmitteddate").val()));
        formData.append("agencyName", $.trim($("#txtfdragencyname").val()));
        formData.append("loaDate", $.trim($("#txtfdrloaDate").val()));
        formData.append("loaNo", $.trim($("#txtfdrloaNo").val()));
        formData.append("duration", $.trim($("#txtfdrduration").val()));
        formData.append("LoaLetterFile", $('#fufdrloaletter')[0].files[0]);
        formData.append("PPTFile", $('#fufdrppt')[0].files[0]);
        formData.append("FdrEstimateFile", $('#fufdrestimate')[0].files[0]);
        formData.append("MaplayoutFile", $('#fufdrmap')[0].files[0]);
        formData.append("DesignLayoutFile", $('#fufdrdesign')[0].files[0]);
        var fdrid = $('#hdnfdrId').val() || 0;
        let dynamicMsg = fdrid == 0 ? "Save" : "Update";
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
                    url: baseUrl + "Proposal/SaveFDRDetails",
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
                                window.location.reload();
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
function ResetFDR(ctrl) {
    var $ctrl = $(ctrl);
    if ($ctrl.text().trim() === "Reset") {
        $("#formfdr").validate().resetForm();
        $("#formfdr").find(".is-valid, .is-invalid").removeClass("is-valid is-invalid");
        $("#formfdr").find(".error").removeClass("error");
        $("#formfdr")[0].reset();
    }
    else {
        $("#fdrmodal").modal("hide");
    }
}