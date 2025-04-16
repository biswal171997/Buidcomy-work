$(document).ready(function () {
    $("#ddlsitedistrict").change(function () {
        BindBlockDropdown($("#ddlsitedistrict").val(), 0);
    });
    $("#formsite").validate({
        rules: {
            txtsitearea: { required: true },
            fusitenocPath: {
                required: function () {
                    return $('#hdnsitelandid').val() == "0"; // Required only if hdnproposald is 0
                },
                fileExtension: "pdf",
                fileSize: 10 * 1024 * 1024
            },
            fusiteplannedMap: {
                required: function () {
                    return $('#hdnsitelandid').val() == "0"; // Required only if hdnproposald is 0
                },
                fileExtension: "pdf",
                fileSize: 10 * 1024 * 1024
            },
            ddlsitedistrict: { required: true, notEqualTo: "0" },
            ddlsiteblock: { required: true, notEqualTo: "0" },
            ddlsiteward: { required: true, notEqualTo: "0" },
            txtsiteaddress: { required: true },
            txtsitelattitude: { required: true },
            txtsitelongitude: { required: true },
            txtsitekhataNo: { required: true },
            txtsitekhesraNo: { required: true },
            fusitedocs: {
                required: function () {
                    return $('#hdnsitelandid').val() == "0"; // Required only if hdnproposald is 0
                },
                fileExtension: "pdf",
                fileSize: 10 * 1024 * 1024
            },
        },
        messages: {
            txtsitearea: { required: "Please enter Req. Construction Area" },
            fusitenocPath: {
                required: "Please upload Land NOC Document",
                fileExtension: "Only PDF files are allowed",
                fileSize: "File size must be less than 10MB"
            },
            fusiteplannedMap: {
                required: "Please Upload Plan MAP",
                fileExtension: "Only PDF files are allowed",
                fileSize: "File size must be less than 10MB"
            },
            ddlsitedistrict: { notEqualTo: "Please select District" },
            ddlsiteblock: { notEqualTo: "Please select ULB" },
            ddlsiteward: { notEqualTo: "Please select Ward No" },
            txtsiteaddress: { required: "Please enter Address" },
            txtsitelattitude: { required: "Please enter Lattitude" },
            txtsitelongitude: { required: "Please enter Longitude" },
            txtsitekhataNo: { required: "Please enter Khata No" },
            txtsitekhesraNo: { required: "Please enter Khesra No" },
            fusitedocs: {
                required: "Please upload Documents",
                fileExtension: "Only .png, .jpg files are allowed",
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
    document.getElementById('fusitedocs').addEventListener('change', function (e) {
        const files = e.target.files;
        const fileListContainer = document.getElementById('fileListContainer');

        // Clear existing files
        fileListContainer.innerHTML = '';

        Array.from(files).forEach((file, index) => {
            const fileSize = formatFileSize(file.size);
            const fileId = `file-${index}`;

            const fileHtml = `
                        <div class="col-xxl-6 col-xl-6 col-lg-6 col-md-6 col-12 mb-2" id="${fileId}">
                            <div class="mb-1 fs-7">
                                <div class="d-flex justify-content-between">
                                    <div>
                                        <a href="#" class="description" title="${file.name}"> ${file.name} </a>
                                        <span class="text-secondary border-start ps-3 ms-3"> ${fileSize} </span>
                                    </div>
                                    <div class="text-success d-none" id="success-${fileId}">
                                        <i class="bi bi-check-circle-fill"></i>
                                    </div>
                                </div>
                            </div>
                            <div class="progress">
                                <div class="progress-bar" id="progress-bar-${fileId}" role="progressbar" aria-valuenow="0" aria-valuemin="0" aria-valuemax="100" style="width: 0%;">
                                </div>
                            </div>
                        </div>
                    `;

            fileListContainer.insertAdjacentHTML('beforeend', fileHtml);

            // Simulate upload progress (replace this with actual AJAX upload if needed)
            simulateUpload(fileId);
        });
    });
});
function AddProposalSite(proposalid, landid) {
    $('#hdnsiteproposalid').val(proposalid);
    $('#hdnsitelandid').val(landid);
    $('#btnsitesubmit').text('Submit');
    $('#btnsitereset').text('Reset');
    $("#formsite").validate().resetForm();
    $("#formsite").find(".is-valid, .is-invalid").removeClass("is-valid is-invalid");
    $("#formsite").find(".error").removeClass("error");
    $('#formsite')[0].reset();
    $('#projectSite').modal('show');
}
function EditProposalSite(landid) {
    debugger
    $.ajax({
        type: 'Get',
        dataType: 'Json',
        contentType: 'application/json; charset=utf-8',
        data: { Id: landid },
        url: baseUrl + "Proposal/GetProposalSiteByID",
        success: function (result) {
            debugger
            var data = JSON.parse(result);
            var data1 = JSON.parse(data.data)
            console.log('site data');
            console.log(data1);
            $('#hdnsiteproposalid').val(data1.proposalId);
            $('#hdnsitelandid').val(data1.landId);
            $('#txtsitearea').val(data1.area);
            $('#asitenocPath').attr("href", baseUrl + 'Proposal/DownloadFiles?filename=' + data1.nocPath + '&filepath=' + _encodedpath + '');
            $('#hdrsitenocPath').val(data1.nocPath);
            $('#asitenocPath').show();

            $('#asiteplannedMap').attr("href", baseUrl + 'Proposal/DownloadFiles?filename=' + data1.plannedMap + '&filepath=' + _encodedpath + '');
            $('#hdrsiteplannedMap').val(data1.plannedMap);
            $('#asiteplannedMap').show();

            $('#ddlsitedistrict').val(data1.districtId);
            BindBlockDropdown($("#ddlsitedistrict").val(), data1.blockId)
                .then(() => {
                    BindWardDropdown($("#ddlsiteblock").val(), data1.Wardid);
                })
                .catch(error => {
                    console.error("Error:", error);
                });
            $('#txtsiteaddress').val(data1.address);
            $('#txtsitelattitude').val(data1.lattitude);
            $('#txtsitelongitude').val(data1.longitude);
            $('#txtsitekhataNo').val(data1.khataNo);
            $('#txtsitekhesraNo').val(data1.khesraNo);
            var docelements = '';
            $.each(data1.proposalsitedocs, function (i, docsdata) {
                debugger
                docelements += '<a href="' + baseUrl + 'Proposal/DownloadFiles?filename=' + docsdata.docPath + '&filepath=' + _encodedpath +'" data-bs-toggle="tooltip" title="Document ' + (i+1) +'"> <i class="bi bi-file-earmark-pdf me-2 text-danger"> </i> Document '+(i+1)+' </a>';
            });
            $('#dvsitedocsmultpledownload').empty();
            $('#dvsitedocsmultpledownload').append(docelements);

            $('#btnsitesubmit').text('Update');
            $('#btnsitereset').text('Cancel');
            $("#formsite").validate().resetForm();
            $("#formsite").find(".is-valid, .is-invalid").removeClass("is-valid is-invalid");
            $("#formsite").find(".error").removeClass("error");
            $('#projectSite').modal('show');
            $('#asiteplannedMap').show();
        },
        error: function (Message) {
            alert(Message);
        }
    });
}
function SaveProposalSite() {
    if ($("#formsite").valid()) {
        var formData = new FormData();
        formData.append("landId", $.trim($("#hdnsitelandid").val()));
        formData.append("proposalId", $.trim($("#hdnsiteproposalid").val()));
        formData.append("area", $.trim($("#txtsitearea").val()));
        formData.append("LandNocFile", $('#fusitenocPath')[0].files[0]);
        formData.append("MapplanFile", $('#fusiteplannedMap')[0].files[0]);
        formData.append("districtId", $.trim($("#ddlsitedistrict").val()));
        formData.append("blockId", $.trim($("#ddlsiteblock").val()));
        formData.append("Wardid", $.trim($("#ddlsiteward").val()));
        formData.append("address", $.trim($("#txtsiteaddress").val()));
        formData.append("lattitude", $.trim($("#txtsitelattitude").val()));
        formData.append("longitude", $.trim($("#txtsitelongitude").val()));
        formData.append("khataNo", $.trim($("#txtsitekhataNo").val()));
        formData.append("khesraNo", $.trim($("#txtsitekhesraNo").val()));
        var files = $('#fusitedocs')[0].files;
        for (var i = 0; i < files.length; i++) {
            formData.append("SiteDocFiles", files[i]); // Appends each file with the same key name "SiteDocFiles"
        }
        //formData.append("SiteDocFiles", $('#fusitedocs')[0].files[0]);
        var landid = $('#hdnsitelandid').val() || 0;
        let dynamicMsg = landid == 0 ? "Save" : "Update";
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
                    url: baseUrl + "Proposal/SaveProposalSite",
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
                                if (dynamicMsg == 'Save') {
                                    location.href = baseUrl + 'Proposal/CreateProposal';
                                }
                                else {
                                    window.location.reload();
                                }
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
function DeleteProposalSite(landid) {
    if (landid) {
        var formData = new FormData();
        formData.append("landId", landid);
        Swal.fire({
            title: 'Are you sure?',
            text: "You won't be able to revert this!",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Yes, Delete it!'
        }).then((result) => {
            if (result.isConfirmed) {
                $.ajax({
                    type: "POST",
                    url: baseUrl + "Proposal/DeleteProposalSite",
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
function ResetProposalSite(ctrl) {
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
function simulateUpload(fileId) {
    const progressBar = document.getElementById(`progress-bar-${fileId}`);
    const successIcon = document.getElementById(`success-${fileId}`);
    let progress = 0;

    const interval = setInterval(() => {
        progress += 10;
        progressBar.style.width = progress + '%';
        progressBar.setAttribute('aria-valuenow', progress);

        if (progress >= 100) {
            clearInterval(interval);
            successIcon.classList.remove('d-none');
        }
    }, 300);
}
function formatFileSize(size) {
    if (size < 1024) return size + ' B';
    if (size < 1024 * 1024) return (size / 1024).toFixed(0) + ' KB';
    return (size / (1024 * 1024)).toFixed(2) + ' MB';
}