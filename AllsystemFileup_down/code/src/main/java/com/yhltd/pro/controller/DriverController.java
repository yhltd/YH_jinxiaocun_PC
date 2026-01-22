package com.yhltd.pro.controller;


import com.yhltd.pro.util.*;
import lombok.extern.slf4j.Slf4j;
import org.springframework.web.bind.annotation.*;
import org.springframework.web.multipart.MultipartFile;

import javax.servlet.http.HttpServletRequest;
import java.io.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;


/**
 * @author hui
 * @date 2022/11/29 18:46
 */
@Slf4j
@RestController
@RequestMapping("/file")
public class DriverController {

    /**
     * 上传图片名称匹配修改20240904
     *
     * @return ResultInfo
     */
    @PostMapping("/upload")
    public ResultInfo upload(HttpServletRequest request, @RequestParam("file") MultipartFile file) {
        try {
            // 1. 获取参数
            long kongjian = Long.parseLong(request.getParameter("kongjian"));
            String thisPath = request.getParameter("path");
            String fileName = file.getOriginalFilename();
            String newFileName = request.getParameter("name");

            // 2. 安全校验
            if (thisPath == null || thisPath.contains("..")) {
                return ResultInfo.error("路径参数不合法");
            }

            // 3. 确保路径以斜杠结尾
            if (!thisPath.endsWith("/") && !thisPath.endsWith("\\")) {
                thisPath += "/";
            }

            // 4. 构建完整路径
            String basePath = "C:/iis_jxc/sharepic_path";
            String fullPath = basePath + thisPath + newFileName;
            File dest = new File(fullPath);

            // 5. 创建目录（如果不存在）
            File parentDir = dest.getParentFile();
            if (!parentDir.exists()) {
                if (!parentDir.mkdirs()) {
                    return ResultInfo.error("无法创建目录，请检查权限");
                }
            }

            // 6. 检查磁盘空间（应该在保存前检查）
            File disk = new File("C:/");
            long freeSpace = disk.getFreeSpace() / 1073741824; // GB
            if (freeSpace <= 0) {
                return ResultInfo.error("磁盘空间不足");
            }

            // 7. 检查文件夹大小（如果有大小限制）
            Path folder = Paths.get(basePath + thisPath);
            long size = 0;
            if (Files.exists(folder)) {
                size = Files.walk(folder)
                        .filter(path -> path.toFile().isFile())
                        .mapToLong(path -> path.toFile().length())
                        .sum();
                size = size / 1073741824; // 转换为GB
            }

            // 8. 添加本次文件大小
            long fileSize = file.getSize() / 1073741824;
            if (size + fileSize >= kongjian) {
                return ResultInfo.error("存储空间不足");
            }

            // 9. 保存文件
            file.transferTo(dest);

            // 10. 记录日志
            log.info("文件上传成功: {}, 大小: {} GB", fullPath, fileSize);

            return ResultInfo.success("上传成功", fullPath);

        } catch (NumberFormatException e) {
            return ResultInfo.error("参数格式错误");
        } catch (IOException e) {
            log.error("文件上传失败", e);
            return ResultInfo.error("上传失败: " + e.getMessage());
        }
    }

//    @RequestMapping("/delete")
//    public ResultInfo delete(HttpServletRequest request) throws IOException {
//        //获取原始名称
//        String orderNumber = request.getParameter("order_number");
//        String path = request.getParameter("path");
//
//        // 支持的文件扩展名列表
//        String[] extensions = {"jpg", "jpeg", "png", "pdf", "gif", "bmp", "webp", "tiff", "doc", "docx", "xls", "xlsx", "zip", "rar"};
//
//        // 遍历所有可能的文件编号和扩展名
//        for (int i = 1; i <= 14; i++) {
//            String fileNumber = (i < 10) ? "0" + i : String.valueOf(i);
//
//            for (String ext : extensions) {
//                String filepath = "C:/iis_jxc/sharepic_path" + path + orderNumber + "-" + fileNumber + "." + ext;
//                File file = new File(filepath);
//
//                if (file.isFile() && file.exists()) {
//                    boolean deleted = file.delete();
//                    System.out.println("删除文件 " + filepath + ": " + (deleted ? "成功" : "失败"));
//                }
//            }
//        }
//
//        return ResultInfo.success("删除成功", orderNumber);
//    }
@RequestMapping("/delete")
public ResultInfo delete(HttpServletRequest request) throws IOException {
    //获取原始名称
    String orderNumber = request.getParameter("order_number");
    String path = request.getParameter("path");

    // 支持的文件扩展名列表
    String[] extensions = {"jpg", "jpeg", "png", "pdf", "gif", "bmp", "webp", "tiff",
            "doc", "docx", "xls", "xlsx", "zip", "rar"};

    int deletedCount = 0;
    int failedCount = 0;

    // 方案1：遍历两种格式
    for (int i = 0; i <= 14; i++) {  // 注意：从0开始，0表示不带"-"
        // 生成文件名部分
        String fileNumberPart = "";
        if (i > 0) {
            fileNumberPart = "-" + ((i < 10) ? "0" + i : String.valueOf(i));
        }
        // i=0时：不带"-"部分，如 ABC123.jpg
        // i>0时：带"-"部分，如 ABC123-01.jpg

        for (String ext : extensions) {
            // 构建文件路径
            String filepath = "C:/iis_jxc/sharepic_path" + path +
                    orderNumber + fileNumberPart + "." + ext;
            File file = new File(filepath);

            if (file.isFile() && file.exists()) {
                boolean deleted = file.delete();
                System.out.println("删除文件 " + filepath + ": " + (deleted ? "成功" : "失败"));

                if (deleted) {
                    deletedCount++;
                } else {
                    failedCount++;
                }
            }
        }
    }

    String result = String.format("删除完成。成功: %d 个, 失败: %d 个", deletedCount, failedCount);
    return ResultInfo.success(result, orderNumber);
}



}
