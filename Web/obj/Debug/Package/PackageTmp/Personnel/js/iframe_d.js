var iframe_d_header_fun_maxmin_is = false
var iframe_d_list = []

function iframe_d_open(list) {
    iframe_d_list = list
    $(".iframe_d").css({ "display": "flex", "z-index": iframe_d_list.z_index })

    var iframe_d_html =
        "<div class='iframe_d_mask'></div>" + 
        "<div class='iframe_d_form'>" +
            "<div class='iframe_d_header'> " +
                "<div class='iframe_d_header_text'>" + iframe_d_list.title + "</div> " +
                "<div class='iframe_d_header_fun'>"
            
    if (list.maxmin) {
        iframe_d_html +=
                    "<img id='iframe_d_header_fun_maxmin' class='iframe_d_header_fun_img' src='images/放大.png'/>"
    }

    iframe_d_html +=
                    "<img id='iframe_d_header_fun_close' class='iframe_d_header_fun_img' src='images/关闭.png'/>" +
                "</div>" +
            "</div>" +
            "<div class='iframe_d_main'>" +
                "<iframe class='iframe_d_iframe' src='" + iframe_d_list.content + "'></iframe>" +
            "</div>" +
        "</div>";
    $(".iframe_d").append(iframe_d_html)

    $(".iframe_d_mask").css("z-index", iframe_d_list.z_index);
    $(".iframe_d_form").css({ "z-index": iframe_d_list.z_index + 1, "width": iframe_d_list.area.x+"px", "height": iframe_d_list.area.y+"px" })
}

$(function () {
    $(".iframe_d_mask").click(function () {
        if (list.shadeClose) {
            $(".iframe_d").css("display", "none")
            $(this).css("display", "none")
        }
    })

    $("#iframe_d_header_fun_close").click(function () {
        $(".iframe_d").css("display", "none")
        $(".iframe_d_mask").css("display", "none")
    })
    
    $("#iframe_d_header_fun_maxmin").click(function () {
        if (!iframe_d_header_fun_maxmin_is) {
            $(".iframe_d_form").css({ "width": "100%", "height": "98%" })
            $(this).attr("src", "images/缩小.png")
            iframe_d_header_fun_maxmin_is = true
        } else {
            $(".iframe_d_form").css({ "width": iframe_d_list.area.x + "px", "height": iframe_d_list.area.y + "px" })
            $(this).attr("src", "images/放大.png")
            iframe_d_header_fun_maxmin_is = false
        }
    })
})