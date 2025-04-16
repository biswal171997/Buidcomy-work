function CounterText(txtCtr, spanVal) {
    //var max = 200;
    //var len = $('#' + txtCtr).val().length;
    //if (len >= max) {
    //    $('#' + spanVal).html(0);
    //} else {
    //    var char = max - len;
    //    $('#' + spanVal).html(char + ' character(s) left.');
    //} 
}


$(document).on('focus', ".datepickermeetdt", function () {
    $(this).datepicker({
        format: "dd-M-yyyy",
        todayBtn: "linked",
        autoclose: true,
        //startDate: '-30d',
        endDate: new Date(),
        todayHighlight: true
    });
});


$(document).on('focus', ".datepickertardt", function () {
    $(this).datepicker({
        format: "dd-M-yyyy",
        todayBtn: "linked",
        autoclose: true,
        startDate: '+1d',       
        todayHighlight: true
    });
});

//Delete Components Coding Begin

$("#CMOMeetinginsert").on('click', '.remove', function ()
{
    
    var row_index = parseInt($(this).parents('tr')[0].rowIndex);
    
    //checl row exist
    if (row_index != 2) {
        var findRowindex = parseInt(row_index) + 1;
        var findtd = $("#cmt_rw_" + findRowindex + "");
        if (findtd.length == 0) {
            var autid = parseInt(row_index) - 2;
            $("#cmt_rw_" + autid + "").show();
        }
    } else {
        $("#cmt_rw_0").show();
        $("#cmt_Drw_0").hide();
    }
    
    $(this).parents('tr').remove();
    
});

    //Delete Components Coding End


//$('#Content-textarea-input0').keyup(function (e) {
//    var max = 200;
//    var len = $(this).val().length;
//    var char = max - len;
//    $('#text-counter').html(char + ' character(s) left.');
//});  


$(document).ready(function () {  
    //$('#tblCMOMeeting').DataTable({
    //    "bStateSave": true
    //});
    $('#Clear').click(function () {
        $('#txtMeetDt').val("");
    });
   
});


$('#fuUploadPoc').on('change', function (e) {
    var file = $('#fuUploadPoc')[0].files[0].name;
    $('#fuUploadPocPrev').text(file);
    if (!ValidateFile('fuUploadPoc', 'Valid Document')) {
        return false;
    };
    if (!CheckFileType('fuUploadPoc', '3')) {
        return false;
    };
});


function findInTable(str, Dept, indexd) {
    var result = "";
    $('#CMOMeetinginsert tbody tr').each(function (index) {        
        var ComponentName = $(this).find("td").eq(0).find("textarea#Content-textarea-input" + index + "").val().trim();
        var DeptId = $(this).find("td").eq(1).find("select#ddlDept").val();
        if (indexd != index) {
            if (ComponentName == str && Dept == DeptId) {
                result = 1;
                return false;
            }
        }
    });
    return result;
}


$('#btnSubmit').click(function () {
    if (validate()) {
        if (validateComponent()) {
            bootbox.confirm({
                size: "medium",
                message: "Are you sure , you want to Submit?",
                callback: function (result) {
                    if (result === true) {
                        var linkDetails = new Array();
                        var fileData = new FormData();
                        $('#CMOMeetinginsert tbody tr').each(function (index) {
                            var ComponentName = $(this).find("td").eq(0).find("textarea#Content-textarea-input" + index+"").val();
                            var Dept = $(this).find("td").eq(1).find("select#ddlDept").val();
                            var TargetDate = $(this).find("td").eq(2).find(":text").val();
                            var linkDetail = {};
                            linkDetail.COMPONENTNAME = ComponentName;
                            linkDetail.DEPTID = Dept;
                            linkDetail.TARGETDATE = TargetDate;
                            linkDetails.push(linkDetail);
                        });
                        if (window.FormData !== undefined) {
                            var fileUpload = $("#fuUploadPoc").get(0);
                           
                            var files = fileUpload.files;
                            for (var i = 0; i < files.length; i++) {
                                fileData.append(files[i].name, files[i]);
                            }
                           
                        }
                        fileData.append("Elements", JSON.stringify(linkDetails));
                        fileData.append("MeetingDate", $('#txtMeetDt_T').val());
                        fileData.append("LetterNo", $('#txtLetterNo').val());
                        AddCMOData(fileData);
                    }
                }
            });
        }
    }
});


//$('#btnUpdate').click(function () {
//    if (validate()) {
//        if (validateComponent()) {
//            bootbox.confirm({
//                size: "medium",
//                message: "Are you sure you want to Update?",
//                callback: function (result) {
//                    if (result === true) {
//                        var linkDetails = new Array();
//                        var fileData = new FormData();
//                        $('#CMOMeetinginsert tbody tr').each(function () {
//                            var ComponentId = $(this).find("td").eq(0).find("#hfComponentId").val();
//                            var ComponentName = $(this).find("td").eq(0).find("textarea#Content-textarea-input").val();
//                            var Dept = $(this).find("td").eq(1).find("select#ddlDept").val();
//                            var TargetDate = $(this).find("td").eq(2).find(":text").val();
//                            var linkDetail = {};
//                            linkDetail.COMPONENTID = ComponentId;
//                            linkDetail.COMPONENTNAME = ComponentName;
//                            linkDetail.DEPTID = Dept;
//                            linkDetail.TARGETDATE = TargetDate;
//                            linkDetails.push(linkDetail);
//                        });
//                        if (window.FormData !== undefined) {
//                            var fileUpload = $("#fuUploadPoc").get(0);
//                            var files = fileUpload.files;
//                            for (var i = 0; i < files.length; i++) {
//                                fileData.append(files[i].name, files[i]);
//                            }
//                        }

//                        fileData.append("Elements", JSON.stringify(linkDetails));
//                        fileData.append("UploadPoc", $('#fuUploadPocPrev').text());
//                        fileData.append("RegdId", $('#hfRegdId').val());
//                        fileData.append("MeetingDate", $('#txtMeetDt').val());
//                        fileData.append("LetterNo", $('#txtLetterNo').val());
//                        UpdateCMOData(fileData);
//                    }
//                }
//            });
//        }
//    }
//});



function validate() {
    if ($('#txtMeetDt_T').val() == '') {
        bootbox.alert("Please Select Meeting Date!", function () {
            $('#txtMeetDt_T').focus();
        });
        return false;
    }
    else if ($('#txtLetterNo').val() == '') {
        bootbox.alert("Please Enter Letter No!", function () {
            $('#txtLetterNo').focus();
        });
        return false;
    }
    else if ($('#fuUploadPocPrev').text() == 'Choose File') {
        bootbox.alert("Please Upload Proceeding!", function () {
            $('#fuUploadPoc').focus();
        });
        return false;
    }
    else {
        return true;
    }
}


function validateComponent() {
    var rowcount = 0;    
    $('#CMOMeetinginsert tbody tr').each(function (index) {
        var ComponentName = $(this).find("td").eq(0).find("textarea#Content-textarea-input" + index+"").val();
        var Dept = $(this).find("td").eq(1).find("select#ddlDept").val();
        var TargetDate = $(this).find("td").eq(2).find(":text").val();
        if (ComponentName == "") {
            //bootbox.alert("Please Enter Components.");
            //bootbox.alert("Please Enter charter.");
            bootbox.alert("Please Enter atleast one charter.");
            $(this).focus();
            rowcount = 0;
            return false;// breaks out of each loop
        }
        else if (Dept == 0) {
            bootbox.alert("Please Select Department.");
            $(this).focus();
            rowcount = 0;
            return false;
        }
        else if (TargetDate == "") {
            bootbox.alert("Please Select Target Date.");
            $(this).focus();
            rowcount = 0;
            return false;// breaks out of each loop
        }
        else if (index > 0) {
            if (findInTable(ComponentName, Dept, index) == "1") {
                bootbox.alert("Component name schould not be duplicate.");
                $(this).find("td").eq(0).find("textarea#Content-textarea-input").val('');
                rowcount = 0;
                return false;// breaks out of each loop
            }
            else {
                rowcount++;
            }
        }
        else {
            rowcount++;
            return true;
        }
    });
    if (rowcount > 0) {
        return true;
    }
    else {
        return false;
    }
    //return true;
}



function CheckFileType(cntr, ftype) {
    var userImg = '@Url.Content("~/imgs/no_user.png")';
    // Get the file upload control file extension
    var extn = $('#' + cntr).val().split('.').pop().toLowerCase();
    if (extn != '') {

        // Create array with the files extensions to upload
        var fileListToUpload;
        if (parseInt(ftype) == 1)
            fileListToUpload = new Array('pdf', 'jpg', 'jpeg');
        else if (parseInt(ftype) == 2)
            fileListToUpload = new Array('jpg', 'jpeg');
        else
            fileListToUpload = new Array('pdf');

        //Check the file extension is in the array.
        var isValidFile = $.inArray(extn, fileListToUpload);

        // isValidFile gets the value -1 if the file extension is not in the list.
        if (isValidFile == -1) {
            if (parseInt(ftype) == 1) {
                bootbox.alert('Please upload a valid document of type pdf/jpg/jpeg.!!!');
                $('#' + cntr).replaceWith($('#' + cntr).val('').clone(true));
                $('#' + cntr).focus();
            }
            else if (parseInt(ftype) == 2) {
                bootbox.alert('Please upload a valid document of type jpg/jpeg.!!!');
                $('#showPhoto').attr('src', userImg);
                $('#' + cntr).replaceWith($('#' + cntr).val('').clone(true));
                $('#' + cntr).focus()
            }
            else if (parseInt(ftype) == 3) {
                bootbox.alert("<strong>Please upload a valid pdf file</strong>");
                $('#fuUploadPocPrev').text("Choose File");
                $('#' + cntr).replaceWith($('#' + cntr).val('').clone(true));
                $('#' + cntr).focus();
            }
            else {
                bootbox.alert('Please Upload a valid document !!!');
                $('#' + cntr).replaceWith($('#' + cntr).val('').clone(true));
                $('label[id*="' + cntr + '"]').text('');
                $('#' + cntr).focus();
            }
        }
        else {
            // Restrict the file size to 2MB(1024 * 5120;)
            if ($('#' + cntr).get(0).files[0].size > (5242880)) {
                bootbox.alert("<strong>Proceeding file size should not exceed 5MB.!!!</strong>");
                $('#fuUploadPocPrev').text("Choose File");
                $('#' + cntr).replaceWith($('#' + cntr).val('').clone(true));
                $('#' + cntr).focus();
            }
            if ($('#' + cntr).get(0).files[0].name.length > 100) {
                bootbox.alert("<strong>Proceeding file Name should be maximum 100 Characters!</strong>");
                $('#fuUploadPocPrev').text("Choose File");
                $('#' + cntr).replaceWith($('#' + cntr).val('').clone(true));
                $('label[id*="' + cntr + '"]').text('');
                $('#' + cntr).focus();
            }
            else
                return true;
        }
    }
    else
        return true;
}



function ValidateFile(cntr, strText) {
    var strValue = $('#' + cntr).get(0).files.length;
    if (strValue == "0") {
        bootbox.alert("Please upload " + strText);
        $('#fuUploadPocPrev').text("Choose File");
        return false;
    }
    else
        return true;
}


function SpecialCharacterValidation(e) {
    
    var k;
    document.all ? k = e.keyCode : k = e.which;
    return ((k > 64 && k < 91) || (k > 96 && k < 123) || k == 8 || k == 32 || k == 47 || (k >= 48 && k <= 57) || k == 13);
}


function SpecialCharacterValidationforletter(e) {
   
    var k;
    document.all ? k = e.keyCode : k = e.which;
    return ((k > 64 && k < 91) || (k > 96 && k < 123) || k == 8 || k == 32 || k == 47 || (k >= 48 && k <= 57) || k == 38);
}


function clean(t) {

    t.value = t.value.toString().replace(/[^a-zA-Z 0-9\n\r]+/g, '');

}

