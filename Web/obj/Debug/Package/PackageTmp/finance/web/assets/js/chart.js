var page = {
    start_date: "",
    stop_date: "",
}

$(function () {
    ajaxUtil({
        url: "web_service/user_management.asmx/quanxianGet",
        loading: true,
    }, function (result) {
        if (result.code == 200) {
            quanxian = result.data
            if (quanxian.znkb_select == "是") {
                $(".chart-item").css({
                    "width": (width - 202) / 2 + 39 + "px",
                    "height": (height - 68) / 2 + "px"
                })
                $(".chart-item1").css({
                    "width": (width - 202) / 2 + 39 + "px",
                })

                $(".chart-item > div").css({
                    "width": $(".chart-item")[0].scrollWidth - 20 + "px",
                    "height": $(".chart-item")[0].scrollHeight - 20 + "px"
                })

                $('#add-voucherDate').datetimebox({
                    okText: '确定',
                    closeText: '关闭',
                    currentText: '当前时间',
                    panelWidth: 318,
                    panelHeight: 280,
                    width: 318,
                    height: 38
                });

                //年初余额
                getAccounting();

                //凭证金额
                getSummary();

                //科目余额
                getAccountingBalance();

                //资产负债
                getLiabilities();

                //利润合计
                getProfit();

                //现金流量
                getFlow();
            } else {
                $.messager.alert('Warning', '无权限');
            }
        }
    });
    
})

function getAccounting() {
    var myChart = echarts.init(document.getElementById("accounting"), 'shine');
    
    myChart.showLoading({
        text: '加载中',
        color: '#95B8E7',
        textColor: '#000',
        maskColor: 'rgba(255, 255, 255,0.3)',
        zlevel: 0,
    });

    ajaxUtil({
        url: "web_service/chart.asmx/getAccounting",
        data: {
            start_date: page.start_date,
            stop_date:page.stop_date
        },
        loading: false
    }, function (result) {
        if (result.code == 200) {
            data = result.data;
            var daijin_sum = 0
            var jiejin_sum = 0;
            for (var i = 0; i < data.sum_borrowed.length; i++) {
                daijin_sum += data.sum_borrowed[i];
            }
            for (var i = 0; i < data.sum_load.length; i++) {
                jiejin_sum += data.sum_load[i];
            }
            document.getElementById("jiejinheji").innerText = jiejin_sum;
            document.getElementById("daijinheji").innerText = daijin_sum;
            var options = {
                title: {
                    text: "年初余额"
                },
                legend: {
                    type: 'plain'
                },
                tooltip: {
                    trigger: "axis",
                    axisPointer: {
                        type: "shadow"
                    }
                },
                grid: {
                    containLabel: 'true',
                    left: 10,
                    bottom: 10,
                    right: 10,
                },
                xAxis: [{
                    type: "category",
                    data: ["资产类", "负债类", "权益类", "成本类", "损益类", ],
                    axisTick: {
                        alignWithLabel: true
                    }
                }],
                yAxis: [{
                    type: "value",
                    splitNumber: "5"
                }],
                series: [{
                    name: "年初借金",
                    type: "bar",
                    label: {
                        show: "true",
                        position: "top"
                    },
                    data: data.sum_load
                }, {
                    name: "年初贷金",
                    type: "bar",
                    label: {
                        show: "true",
                        position: "top"
                    },
                    data: data.sum_borrowed
                }],

            }

            myChart.setOption(options);
        }
    }, function () {
        myChart.hideLoading();
    })
}

function getSummary(data) {
    var myChart = echarts.init(document.getElementById("summary"), 'shine');
    
    myChart.showLoading({
        text: '加载中',
        color: '#95B8E7',
        textColor: '#000',
        maskColor: 'rgba(255, 255, 255,0.3)',
        zlevel: 0,
    });

    ajaxUtil({
        url: "web_service/chart.asmx/getSummary",
        data: {
            start_date: page.start_date,
            stop_date: page.stop_date
        },
        loading: false
    }, function (result) {
        if (result.code == 200) {
            data = result.data;

            var options = {
                title: {
                    text: "凭证金额"
                },
                legend: {
                    type: 'plain'
                },
                tooltip: {
                    trigger: "axis",
                    axisPointer: {
                        type: "shadow"
                    }
                },
                grid: {
                    containLabel: 'true',
                    left: 10,
                    bottom: 10,
                    right: 40,
                },
                xAxis: [{
                    type: "value",
                    splitNumber: "5"
                }],
                yAxis: [{
                    type: "category",
                    data: ["金额"],
                    axisTick: {
                        alignWithLabel: true
                    }
                }],
                series: [{
                    name: "贷方金额",
                    type: "bar",
                    label: {
                        show: "true",
                        position: "right"
                    },
                    data: [data.sum_borrowed]
                }, {
                    name: "借方金额",
                    type: "bar",
                    label: {
                        show: "true",
                        position: "right"
                    },
                    data: [data.sum_load]
                }]
            }

            myChart.setOption(options);
        }
        else if (result.code == 500) {
            $.messager.alert({
                title: "错误",//标题

                msg: "凭证金额图表未查询到数据",//信息

                icon: "error",//图标类型：error-错误；warning-警告; 或其他

            });
        }

    },
    function () {
        myChart.hideLoading();
    })
}

function getAccountingBalance(data) {

    var myChart = echarts.init(document.getElementById("accountingBalance"), 'shine');

    myChart.showLoading({
        text: '加载中',
        color: '#95B8E7',
        textColor: '#000',
        maskColor: 'rgba(255, 255, 255,0.3)',
        zlevel: 0,
    });

    ajaxUtil({
        url: "web_service/chart.asmx/getAccountingBalance",
        data: {
            start_date: page.start_date,
            stop_date: page.stop_date
        },
        loading: false
    }, function (result) {
        if (result.code == 200) {
            data = result.data;
            var aa = document.getElementById("jiefangheji")
            var jiefang_sum = 0;
            var daifang_sum = 0;
            for (var i = 0; i < data.sum_borrowed.length; i++) {
                jiefang_sum += data.sum_borrowed[i];
            }
            for (var i = 0; i < data.sum_load.length; i++) {
                daifang_sum += data.sum_load[i];
            }

            document.getElementById("jiefangheji").innerText = jiefang_sum;
            document.getElementById("daifangheji").innerText = daifang_sum;

            var options = {
                title: {
                    text: '科目余额'
                },
                legend: {
                    type: 'plain'
                },
                tooltip: {
                    trigger: "axis",
                    axisPointer: {
                        type: "shadow"
                    }
                },
                grid: {
                    containLabel: 'true',
                    left: 10,
                    bottom: 10,
                    right: 10,
                },
                xAxis: [{
                    type: "category",
                    data: ["资产类", "负债类", "权益类", "成本类", "损益类"],
                    axisTick: {
                        alignWithLabel: true
                    }
                }],
                yAxis: [{
                    type: "value",
                    splitNumber: "5"
                }],
                series: [{
                    name: "贷方",
                    type: "bar",
                    label: {
                        show: "true",
                        position: "top"
                    },
                    data: data.sum_load
                }, {
                    name: "借方",
                    type: "bar",
                    label: {
                        show: "true",
                        position: "top"
                    },
                    data: data.sum_borrowed
                }]
            }

            myChart.setOption(options);
        }
    }, function () {
        myChart.hideLoading();
    })
}

function getLiabilities(data) {

    var myChart = echarts.init(document.getElementById("liabilities"), 'shine');

    myChart.showLoading({
        text: '加载中',
        color: '#95B8E7',
        textColor: '#000',
        maskColor: 'rgba(255, 255, 255,0.3)',
        zlevel: 0,
    });

    ajaxUtil({
        url: "web_service/chart.asmx/getLiabilities",
        data: {
            start_date: page.start_date,
            stop_date: page.stop_date
        },
        loading: false
    }, function (result) {
        if (result.code == 200) {
            data = result.data;

            var options = {
                title: {
                    text: '资产负债'
                },
                legend: {
                    type: 'plain'
                },
                tooltip: {
                    trigger: "axis",
                    axisPointer: {
                        type: "shadow"
                    }
                },
                grid: {
                    containLabel: 'true',
                    left: 10,
                    bottom: 10,
                    right: 10,
                },
                xAxis: [{
                    type: "category",
                    data: ["资产类", "负债类", "权益类"],
                    axisTick: {
                        alignWithLabel: true
                    }
                }],
                yAxis: [{
                    type: "value",
                    splitNumber: "5"
                }],
                series: [{
                    name: "年初",
                    type: "bar",
                    label: {
                        show: "true",
                        position: "top"
                    },
                    data: data.yearStart
                }, {
                    name: "年末",
                    type: "bar",
                    label: {
                        show: "true",
                        position: "top"
                    },
                    data: data.yearEnd
                }]
            }

            myChart.setOption(options);
        }
    }, function () {
        myChart.hideLoading();
    })
}

function getProfit(data) {

    var myChart = echarts.init(document.getElementById("profit"), 'shine');

    myChart.showLoading({
        text: '加载中',
        color: '#95B8E7',
        textColor: '#000',
        maskColor: 'rgba(255, 255, 255,0.3)',
        zlevel: 0,
    });
    
    ajaxUtil({
        url: "web_service/chart.asmx/getProfit",
        data: {
            start_date: page.start_date,
            stop_date: page.stop_date
        },
        loading: false
    }, function (result) {
        if (result.code == 200) {
            data = result.data;

            var options = {
                title: {
                    text: '利润合计'
                },
                legend: {
                    type: 'plain'
                },
                tooltip: {
                    trigger: "axis",
                    axisPointer: {
                        type: "shadow"
                    }
                },
                grid: {
                    containLabel: 'true',
                    left: 10,
                    bottom: 10,
                    right: 40,
                },
                xAxis: [{
                    type: "value",
                    splitNumber: "5"
                }],
                yAxis: [{
                    type: "category",
                    data: ["收入", "支出"],
                    axisTick: {
                        alignWithLabel: true
                    }
                }],
                series: [{
                    name: "月",
                    type: "bar",
                    label: {
                        show: "true",
                        position: "right"
                    },
                    data: data.sumMonth
                }, {
                    name: "年",
                    type: "bar",
                    label: {
                        show: "true",
                        position: "right"
                    },
                    data: data.sumYear
                }]
            }

            myChart.setOption(options);
        }
    }, function () {
        myChart.hideLoading();
    })
}

function getFlow(data) {

    var myChart = echarts.init(document.getElementById("flow"), 'shine');

    myChart.showLoading({
        text: '加载中',
        color: '#95B8E7',
        textColor: '#000',
        maskColor: 'rgba(255, 255, 255,0.3)',
        zlevel: 0,
    });

    ajaxUtil({
        url: "web_service/chart.asmx/getFlow",
        data: {
            start_date: page.start_date,
            stop_date: page.stop_date
        },
        loading: false
    }, function (result) {
        if (result.code == 200) {
            data = result.data;

            var options = {
                title: {
                    text: '现金流量'
                },
                legend: {
                    type: 'plain'
                },
                tooltip: {
                    trigger: "axis",
                    axisPointer: {
                        type: "shadow"
                    }
                },
                grid: {
                    containLabel: 'true',
                    left: 10,
                    bottom: 10,
                    right: 10,
                },
                xAxis: [{
                    type: "category",
                    data: ["投资结余", "筹资结余", "经营结余"],
                    axisTick: {
                        alignWithLabel: true
                    }
                }],
                yAxis: [{
                    type: "value",
                    splitNumber: "5"
                }],
                series: [{
                    name: "月",
                    type: "bar",
                    label: {
                        show: "true",
                        position: "top"
                    },
                    data: data.sumMonth
                }, {
                    name: "年",
                    type: "bar",
                    label: {
                        show: "true",
                        position: "top"
                    },
                    data: data.sumYear
                }]
            }

            myChart.setOption(options);
        }
    }, function () {
        myChart.hideLoading();
    })
}

function selectBtn() {
    ajaxUtil({
        url: "web_service/user_management.asmx/quanxianGet",
        loading: true,
    }, function (result) {
        if (result.code == 200) {
            quanxian = result.data
            if (quanxian.znkb_select == "是") {
                page.start_date = $("#start_date").textbox('getText');
                page.stop_date = $("#stop_date").textbox('getText');
                console.log(page.start_date);
                console.log(page.stop_date);
                if (page.start_date == "" || page.stop_date == "") {
                    $.messager.alert({
                        title: "错误",//标题

                        msg: "请输入开始日期和结束日期",//信息

                        icon: "error",//图标类型：error-错误；warning-警告; 或其他

                    });
                }
                else if (page.start_date != "" && page.stop_date == "") {
                    $.messager.alert({
                        title: "错误",//标题

                        msg: "必须同时输入开始日期和结束日期",//信息

                        icon: "error",//图标类型：error-错误；warning-警告; 或其他

                    });
                }
                else if (page.start_date > page.stop_date) {
                    $.messager.alert({
                        title: "错误",//标题

                        msg: "开始日期不能大于结束日期",//信息

                        icon: "error",//图标类型：error-错误；warning-警告; 或其他

                    });
                }
                else {
                    //年初余额
                    getAccounting();

                    //凭证金额
                    getSummary();

                    //科目余额
                    getAccountingBalance();

                    //资产负债
                    getLiabilities();

                    //利润合计
                    getProfit();

                    //现金流量
                    getFlow();
                }
            } else {
                $.messager.alert('Warning', '无权限');
            }
        }
    });
    
}