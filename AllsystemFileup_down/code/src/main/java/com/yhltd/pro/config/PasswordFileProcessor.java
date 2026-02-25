package com.yhltd.pro.config;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.env.EnvironmentPostProcessor;
import org.springframework.core.env.ConfigurableEnvironment;
import org.springframework.core.env.MapPropertySource;
import org.springframework.core.env.MutablePropertySources;
import org.springframework.stereotype.Component;

import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

@Component
public class PasswordFileProcessor implements EnvironmentPostProcessor {

    @Override
    public void postProcessEnvironment(ConfigurableEnvironment environment, SpringApplication application) {
        try {
            Path passwordPath = Paths.get("C:/zhengshu_iss/keystorePass.txt");
            System.out.println("检查密码文件: " + passwordPath.toAbsolutePath());

            if (Files.exists(passwordPath)) {
                // 读取密码
                List<String> lines = Files.readAllLines(passwordPath, StandardCharsets.UTF_8);
                String password = lines.get(0).trim();  // 取第一行并去除空格
                System.out.println("读取到密码长度: " + password.length());
                System.out.println("读取到的密码是: [" + password + "]");

                // 创建属性Map
                Map<String, Object> props = new HashMap<>();
                props.put("ssl.key-store-password", password);

                // 将属性添加到环境（这一步最重要！）
                MutablePropertySources sources = environment.getPropertySources();
                sources.addFirst(new MapPropertySource("passwordFile", props));

                System.out.println("成功从文件加载SSL密码");
            } else {
                System.err.println("密码文件不存在: " + passwordPath.toAbsolutePath());
            }
        } catch (Exception e) {
            System.err.println("加载密码文件失败: " + e.getMessage());
            e.printStackTrace();
        }
    }
}