$(function () {
    $(".chart-item").css({
        "width": (width-202) / 2 + 39+ "px",
        "height": (height-68) / 2 + "px"
    })

    $(".chart-item > div").css({
        "width": $(".chart-item")[0].scrollWidth - 20 + "px",
        "height": $(".chart-item")[0].scrollHeight - 20 + "px"
    })

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

    $.ajax({
        type: 'Post',
        timeout: 5000,
        url: "web_service/chart.asmx/getAccounting",
        dataType: "xml",
        success: function (data) {
            myChart.hideLoading();

            data = getJson(data).data

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
        },
        error: function (err) {
            myChart.hideLoading();
            alert("错误！")
        },
        complete: function (XMLHttpRequest, status) {
            if (status == 'timeout') {
                alert("网络超时，请稍后再试。");
            }
        }
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

    $.ajax({
        type: 'Post',
        timeout: 5000,
        url: "web_service/chart.asmx/getSummary",
        dataType: "xml",
        success: function (data) {
            myChart.hideLoading();

            data = getJson(data).data;
            
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
        },
        error: function (err) {
            myChart.hideLoading();
            alert("错误！");
        },
        complete: function (XMLHttpRequest, status) {
            if (status == 'timeout') {
                alert("网络超时，请稍后再试。");
            }
        }
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

    $.ajax({
        type: 'Post',
        timeout: 5000,
        url: "web_service/chart.asmx/getAccountingBalance",
        dataType: "xml",
        success: function (data) {
            myChart.hideLoading();

            data = getJson(data).data;

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
        },
        error: function (err) {
            myChart.hideLoading();
            alert("错误！")
        },
        complete: function (XMLHttpRequest, status) {
            if (status == 'timeout') {
                alert("网络超时，请稍后再试。");
            }
        }
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

    $.ajax({
        type: 'Post',
        timeout: 5000,
        url: "web_service/chart.asmx/getLiabilities",
        dataType: "xml",
        success: function (data) {
            myChart.hideLoading();

            data = getJson(data).data;

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
        },
        error: function (err) {
            myChart.hideLoading();
            alert("错误！")
        },
        complete: function (XMLHttpRequest, status) {
            if (status == 'timeout') {
                alert("网络超时，请稍后再试。");
            }
        }
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

    $.ajax({
        type: 'Post',
        timeout: 5000,
        url: "web_service/chart.asmx/getProfit",
        dataType: "xml",
        success: function (data) {
            myChart.hideLoading();

            data = getJson(data).data;

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
                    name: "本月",
                    type: "bar",
                    label: {
                        show: "true",
                        position: "right"
                    },
                    data: data.sumMonth
                }, {
                    name: "本年",
                    type: "bar",
                    label: {
                        show: "true",
                        position: "right"
                    },
                    data: data.sumYear
                }]
            }

            myChart.setOption(options);
        },
        error: function (err) {
            myChart.hideLoading();
            alert("错误！")
        },
        complete: function (XMLHttpRequest, status) {
            if (status == 'timeout') {
                alert("网络超时，请稍后再试。");
            }
        }
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

    $.ajax({
        type: 'Post',
        timeout: 5000,
        url: "web_service/chart.asmx/getFlow",
        dataType: "xml",
        success: function (data) {
            myChart.hideLoading();

            data = getJson(data).data;

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
                    name: "本月",
                    type: "bar",
                    label: {
                        show: "true",
                        position: "top"
                    },
                    data: data.sumMonth
                }, {
                    name: "本年",
                    type: "bar",
                    label: {
                        show: "true",
                        position: "top"
                    },
                    data: data.sumYear
                }]
            }

            myChart.setOption(options);
        },
        error: function (err) {
            myChart.hideLoading();
            alert("错误！")
        },
        complete: function (XMLHttpRequest, status) {
            if (status == 'timeout') {
                alert("网络超时，请稍后再试。");
            }
        }
    })
}