$(function () {
    getDate_top()
    
})

function getDate_top(){
    var datetime = new Date()
    var year = datetime.getFullYear();
    var month = datetime.getMonth() + 1 < 10 ? "0" + (parseInt(datetime.getMonth()) + 1) : datetime.getMonth() + 1;
    var day = datetime.getDate() < 10 ? "0" + datetime.getDate() : datetime.getDate();
    $(".time_top").text("您好！今天是："+year+"年"+month+"月"+day+"日")
}