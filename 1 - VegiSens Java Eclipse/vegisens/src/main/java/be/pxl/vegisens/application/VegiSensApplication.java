package be.pxl.vegisens.application;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.context.annotation.ComponentScan;
import org.springframework.data.jpa.repository.config.EnableJpaRepositories;
import org.springframework.jms.annotation.EnableJms;
import org.springframework.security.config.annotation.method.configuration.EnableGlobalMethodSecurity;

@SpringBootApplication//(scanBasePackages = "be.pxl.vegisens")
//@ComponentScan
@EnableJpaRepositories
@EnableGlobalMethodSecurity(securedEnabled=true)
@EnableJms //-> Asynchrone verwerking
public class VegiSensApplication 
{  
	public static void main(String[] args)
	{		
		  SpringApplication.run(VegiSensApplication.class, args);
	}
}

