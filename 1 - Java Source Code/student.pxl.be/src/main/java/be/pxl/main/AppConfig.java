package be.pxl.main;

import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.context.annotation.ComponentScan;
import org.springframework.security.config.annotation.method.configuration.EnableGlobalMethodSecurity;

/**
 * Created by aless on 14/10/2016.
 */

@SpringBootApplication // Equivalent to @Configuration, @EnableAutoConfiguration and @ComponentScan
@ComponentScan("be.pxl")
// @EnableGlobalMethodSecurity(securedEnabled = true) // @Secured annotations enabled or not.
public class AppConfig {



}