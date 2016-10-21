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
//import org.springframework.security.crypto.codec.Base64;
import org.springframework.security.access.annotation.Secured;
import org.springframework.web.bind.annotation.*;
import org.springframework.web.client.RestTemplate;

import com.fasterxml.jackson.databind.annotation.JsonSerialize;


@RestController
//@Secured("hasRole('ROLE_ADMIN')")
public class ApiRestController 
{    
	    @Autowired
	    private IGrowableItemService growableItemRepository;
	    
	    @Autowired
	    private ISensorTypeService sensorTypeRepository;
	    
	    @GetMapping("/growableItems")	    
	    public List<GrowableItem> getGrowableItems() 
	    {	    		       
	        return growableItemRepository.getAllGrowableItems();
	    }
	    
	    @GetMapping("/sensortypes")	    
	    public List<SensorType> getSensorTypes() 
	    {	    		       
	        return sensorTypeRepository.getAllSensorTypes();
	    }
}