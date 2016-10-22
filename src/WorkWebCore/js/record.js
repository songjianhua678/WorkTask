var id = 0;
$(document).ready(function () {
$("#mytable #checkall").click(function () {
        if ($("#mytable #checkall").is(':checked')) {
            $("#mytable input[type=checkbox]").each(function () {
                $(this).prop("checked", true);
            });

        } else {
            $("#mytable input[type=checkbox]").each(function () {
                $(this).prop("checked", false);
            });
        }
    });
    
$("[data-toggle=tooltip]").tooltip();

$(".btn-primary").click(function () {
    id = $(this).parent('p').parent('td').parent('tr').find('td').find('#HiddenId').val();
    $("#datestart").val($(this).parent('p').parent('td').parent('tr').find('td').eq(4).text());//开始时间
    $("#dateend").val($(this).parent('p').parent('td').parent('tr').find('td').eq(5).text());//结束时间
    $("#display_name").val($(this).parent('p').parent('td').parent('tr').find('td').eq(1).text());//项目名称

    var txtJobProcess = $(this).parent('p').parent('td').parent('tr').find('td').eq(7).text();//工作进度
    var txtJobLeverl = $(this).parent('p').parent('td').parent('tr').find('td').eq(6).text();//工作级别



    $("#JobProcess option").attr("selected", false);
    $("#JobLeverl option").attr("selected", false);
    if (txtJobProcess == $('#JobProcess option:eq(0)').text()) {
        $("#JobProcess option:eq(0)").attr("selected", true);
    } else if (txtJobProcess == $('#JobProcess option:eq(1)').text()) {
        $("#JobProcess option:eq(1)").attr("selected", true);
    } else if (txtJobProcess == $('#JobProcess option:eq(2)').text()) {
        $("#JobProcess option:eq(2)").attr("selected", true);
    }
    $('#JobProcess').val($('#JobProcess option[selected]').val());
    //$("#JobProcess option:eq(0)").text(txtJobProcess);

    if (txtJobLeverl == $('#JobLeverl option:eq(0)').text()) {
        $("#JobLeverl option:eq(0)").attr("selected", true);
    } else if (txtJobLeverl == $('#JobLeverl option:eq(1)').text()) {
        $("#JobLeverl option:eq(1)").attr("selected", true);
    } else if (txtJobLeverl == $('#JobLeverl option:eq(2)').text()) {
        $("#JobLeverl option:eq(2)]").attr("selected", true);
    }
    $('#JobLeverl').val($('#JobLeverl option[selected]').val());
    //$("#JobLeverl option:eq(0)").text(txtJobLeverl);

    $("#mark").val($(this).parent('p').parent('td').parent('tr').find('td').eq(3).text());//工作备注
});


});


function turnPage(curr_page) {
    var h = window.location.href;
    window.location.href = h.substring(0, h.indexOf("x") + 1) + "?page=" + curr_page;
}

function updatework() {
    var txtWorkName = $.trim($("#display_name").val());
    var txtJobProcess = $('#JobProcess').val();
    var txtJobLeverl = $('#JobLeverl').val();
    var txtWorkMark = $.trim($("#mark").val());
    var txtStartTime = $.trim($("#datestart").val());
    var txtEndTime = $.trim($("#dateend").val());

    if (txtStartTime == '开始时间' || txtStartTime == '') {
        alert("请填写开始时间");
        return false;
    }
    if (txtEndTime == '结束时间' || txtEndTime == '') {
        alert("请填写结束时间");
        return false;
    }
    if (txtWorkName == '项目名称' || txtWorkName == '') {
        alert("请填写项目名称");
        return false;
    }
    if (txtJobProcess == '--请选择项目进度--') {
        alert("请选择项目进度");
        return false;
    }
    if (txtJobLeverl == '--请选择项目级别--') {
        alert("请选择项目级别");
        return false;
    }
    if (txtWorkMark == '备注') {
        txtWorkMark = "";
    }


    $.post("../Record/SaveUpdate", { "Id": id, "WorkName": txtWorkName, "WorkProcess": txtJobProcess, "WorkLevel": txtJobProcess, "WorkMark": txtWorkMark, "StartTime": txtStartTime, "EndTime": txtEndTime }, function (result) {
        if (result > 0) {
            alert("添加成功！");
            window.location.href = window.location.href;
        } else {
            alert("添加失败！");
        }
    }, "json");

}

