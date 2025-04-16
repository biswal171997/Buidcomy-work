function PrintPage(pageheader,divId,tableID) {
    
    $('#'+tableID+'_length').hide();
    $('#'+tableID+'_filter').hide();
    $('#'+tableID+'_info').hide();
    $('#'+tableID+'_paginate').hide();

    var curDate;
    //*******************************************************
    //Set Weedday against current day in numeric
    var WeekDay = new Array(7);
    WeekDay[0] = "Sunday";
    WeekDay[1] = "Monday";
    WeekDay[2] = "Tuesday";
    WeekDay[3] = "Wednesday";
    WeekDay[4] = "Thursday";
    WeekDay[5] = "Friday";
    WeekDay[6] = "Saturday";

    //Set month Name against current Month in numeric 
    var monthName = new Array("Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec")

    var CurDateTime = new Date();
    var curDay = CurDateTime.getDay();
    var curDate = CurDateTime.getDate();
    var curMonth = CurDateTime.getMonth();
    var curYear = CurDateTime.getFullYear();
    var curHH = CurDateTime.getHours();
    var curMM = CurDateTime.getMinutes();
    var curSS = CurDateTime.getSeconds();
    if (curHH >= 12) {
        curHH = curHH - 12;
        var Hour = "PM";
    }
    else
        var Hour = "AM";

    if (curMM < 10)
        curMM = '0' + curMM;
    if (curSS < 10)
        curSS = '0' + curSS;

    var date = WeekDay[curDay] + ", " + curDate + "-" + monthName[curMonth] + "-" + curYear + "  " + curHH + ":" + curMM + ":" + curSS + " " + Hour;
    //*******************************************************
    curDate = date;


    // alert(document.getElementById('viewTable').getElementsByTagName("table")[0])
    var result = 0;
    var pageHeader = pageheader;
    var divIdPrint = "." + divId + "";
  
    $(divIdPrint).find("table").each(function () {
        if ($.trim($(this).find("tr td").text()) == "" || $.trim($(this).find("tr td").text()) == "-") {
            alert("No Print Content available")
            result = 1
            return false;
        }

    });
    if (document.getElementById(divId).getElementsByTagName("table")[0] == undefined) {
        alert("No Print Content available")
        return false;
    }
    if (result != 1) {
        var lable1
        var lable2
        var lable3
        var lable4
        if (document.getElementById('lbl1')) {
            lable1 = document.getElementById('lbl1').innerHTML
        }
        if (document.getElementById('lbl2')) {
            lable2 = document.getElementById('lbl2').innerHTML
        }

        if (document.getElementById('lbl3')) {
            lable3 = document.getElementById('lbl3').innerHTML
        }
        if (document.getElementById('lbl4')) {
            lable4 = document.getElementById('lbl4').innerHTML
        }

        var sOption = "menubar=yes,scrollbars=yes,width=750,height=600,left=100,top=25,resizable=yes";
        var sWinHTML = document.getElementById(divId).innerHTML;
        var winprint = window.open("", "", sOption);
        winprint.document.open();

        winprint.document.write('<html><head><link  href="../../assets/css/Print.css?v=3.4.2"  rel=Stylesheet /><title> ' + pageHeader + ' </title><script src="../../assets/js/jquery.min.js"></script><script>$("document").ready(function () { $("#'+tableID+'").removeAttr("style");});</script></head><body>');
        winprint.document.write('<html><head><link href="../../assets/css/Print.css?v=3.4.2" rel=stylesheet /><title>' + 'PSNPPortal' + '</title></head><body onload="window.print();">'); /// <reference path="../img/" />

        winprint.document.write('<div id="header"><div style="float:left;" width="220"><img src=../../assets/images/Logoblue.png alt=PSNP /></div><div style="float:right" align="right"><span class="txtbold">' + 'Productive Safety Net Programme' + '</span><br />Government of Ethiopia<br /><div align="right" id="printDate">' + curDate + '</div></div><div style="clear:both"></div></div>')
        winprint.document.write('<table Width="100%"> ');
        winprint.document.write('<div style="padding: 2px 0px 2px 0px;">' + pageheader + '</div> ');

        if (lable1) {
            winprint.document.write('<strong>' + lable1 + '</strong>' + "</br>");
        }
        if (lable2) {
            winprint.document.write('<strong>' + lable2 + '</strong>' + "</br>");
        }
        if (lable3) {
            winprint.document.write('<strong>' + lable3 + '</strong>' + "</br>");
        }
        if (lable4) {
            winprint.document.write('<strong>' + lable4 + '</strong>' + "</br>");
        }
        winprint.document.write('</table>');
        winprint.document.write('<div class="viewTable">');
        winprint.document.write(sWinHTML);
        winprint.document.write('</div>');
        winprint.document.write('</body></html>');
        winprint.document.close();
        winprint.focus();
        $('#' + tableID + '_length').show();
        $('#' + tableID + '_filter').show();
        $('#' + tableID + '_info').show();
        $('#' + tableID + '_paginate').show();
    }
}