$(document).ready(function(){
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

    $("#datestart").val($(this).parent('p').parent('td').parent('tr').find('td').eq(4).text());//开始时间
    $("#dateend").val($(this).parent('p').parent('td').parent('tr').find('td').eq(5).text());//结束时间
    $("#display_name").val($(this).parent('p').parent('td').parent('tr').find('td').eq(1).text());//项目名称

    var txtJobProcess = $(this).parent('p').parent('td').parent('tr').find('td').eq(7).text();//工作进度
    var txtJobLeverl = $(this).parent('p').parent('td').parent('tr').find('td').eq(6).text();//工作级别

    $("#JobProcess option").attr("selected", false);
    $("#JobLeverl option").attr("selected", false);
    if (txtJobProcess == $('#JobProcess option:eq(1)').text()) {
        $("#JobProcess option:eq(1)").attr("selected", true);
    } else if (txtJobProcess == $('#JobProcess option:eq(2)').text()) {
        $("#JobProcess option:eq(2)").attr("selected", true);
    } else if (txtJobProcess == $('#JobProcess option:eq(3)').text()) {
        $("#JobProcess option:eq(3)").attr("selected", true);
    }
    $("#JobProcess option:eq(0)").text(txtJobProcess);

    if (txtJobLeverl == $('#JobLeverl option:eq(1)').text()) {
        $("#JobLeverl option:eq(1)").attr("selected", true);
    } else if (txtJobLeverl == $('#JobLeverl option:eq(2)').text()) {
        $("#JobLeverl option:eq(2)").attr("selected", true);
    } else if (txtJobLeverl == $('#JobLeverl option:eq(3)').text()) {
        $("#JobLeverl option:eq(3)]").attr("selected", true);
    }
    $("#JobLeverl option:eq(0)").text(txtJobLeverl);

    $("#mark").val($(this).parent('p').parent('td').parent('tr').find('td').eq(3).text());//工作备注
});


});


function turnPage(curr_page) {
    var h = window.location.href;
    window.location.href = h.substring(0, h.indexOf("x") + 1) + "?page=" + curr_page;
}
   


