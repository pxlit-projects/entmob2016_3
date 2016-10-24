package be.pxl.vegisens.application;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.context.annotation.ComponentScan;
import org.springframework.data.jpa.repository.config.EnableJpaRepositories;
import org.springframework.security.config.annotation.method.configuration.EnableGlobalMethodSecurity;

@SpringBootApplication
@ComponentScan
@EnableJpaRepositories
@EnableGlobalMethodSecurity(securedEnabled=true)
public class VegiSensApplication 
{  
	public static void main(String[] args)
	{		
		SpringApplication.run(VegiSensApplication.class, args);
	}
}

