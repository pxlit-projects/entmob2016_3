package be.pxl.vegisens.application;

import java.util.Arrays;
import java.util.List;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.EnableAutoConfiguration;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.context.annotation.ComponentScan;
import org.springframework.context.annotation.Configuration;
import org.springframework.data.jpa.repository.config.EnableJpaRepositories;
import org.springframework.http.HttpEntity;
import org.springframework.http.HttpHeaders;
import org.springframework.http.HttpMethod;
import org.springframework.http.MediaType;
import org.springframework.http.ResponseEntity;
//import org.springframework.security.config.annotation.method.configuration.EnableGlobalMethodSecurity;
//import org.springframework.security.crypto.codec.Base64;
import org.springframework.security.config.annotation.method.configuration.EnableGlobalMethodSecurity;
import org.springframework.web.client.RestTemplate;

@SpringBootApplication
@ComponentScan
@EnableJpaRepositories
@EnableGlobalMethodSecurity(securedEnabled=true)
public class VegiSensApplication {

	 public static final String REST_SERVICE_URI = "http://localhost:8081/vegisens";
    /*
     * Add HTTP Authorization header, using Basic-Authentiscation to send user-credentials.
     */
    /*private static HttpHeaders getHeaders()
    {
        String plainCredentials="arno:pxl123";
        String base64Credentials = new String(Base64.encode(plainCredentials.getBytes()));
         
        HttpHeaders headers = new HttpHeaders();
        headers.add("Authorization", "Basic " + base64Credentials);
        headers.setAccept(Arrays.asList(MediaType.APPLICATION_JSON));
        return headers;
    }
    
    public static void getAllGrowableItems()
    {
        RestTemplate restTemplate = new RestTemplate(); 
        
        HttpEntity<String> request = new HttpEntity<String>(getHeaders());
        
        ResponseEntity<List> response = restTemplate.exchange(REST_SERVICE_URI+"/api/", HttpMethod.GET, request, List.class);
                
		List<GrowableItem>listOfGrowableItems = (List<GrowableItem>)response.getBody();
		
		for (GrowableItem growableItem : listOfGrowableItems) 
		{
			System.out.println(growableItem.getName());
		}
    }*/
    
	public static void main(String[] args)
	{		
		SpringApplication.run(VegiSensApplication.class, args);
		
		
		//getAllGrowableItems();
	}
}

