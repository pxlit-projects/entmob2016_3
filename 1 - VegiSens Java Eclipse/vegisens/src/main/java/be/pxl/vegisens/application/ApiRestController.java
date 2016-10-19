package be.pxl.vegisens.application;

import java.util.Arrays;
import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.context.annotation.ComponentScan;
import org.springframework.http.HttpEntity;
import org.springframework.http.HttpHeaders;
import org.springframework.http.HttpMethod;
import org.springframework.http.MediaType;
import org.springframework.http.ResponseEntity;
import org.springframework.security.crypto.codec.Base64;
import org.springframework.web.bind.annotation.*;
import org.springframework.web.client.RestTemplate;


@RestController
public class ApiRestController 
{
   
    

    
    /*private static void listAllUsers()
    {
        RestTemplate restTemplate = new RestTemplate(); 
         
        HttpEntity<String> request = new HttpEntity<String>(getHeaders());
        
        ResponseEntity<List> response = restTemplate.exchange(REST_SERVICE_URI+"/api/", HttpMethod.GET, request, List.class);
        
        List<LinkedHashMap<String, Object>> usersMap = (List<LinkedHashMap<String, Object>>)response.getBody();
         
        if(usersMap!=null)
        {
            for(LinkedHashMap<String, Object> map : usersMap)
            {
                System.out.println("User : id="+map.get("id")+", Name="+map.get("name")+", Age="+map.get("age")+", Salary="+map.get("salary"));;
            }
        }
        else
        {
            System.out.println("No user exist----------");
        }
    }*/
    
	    @Autowired
	    private IGrowableItemService repository;
	    
	    
	    @GetMapping("/api")
	    public List<GrowableItem> getGrowableItems1() 
	    {	    		       
	        return repository.getAllGrowableItems();
	    }
	    	    
}
