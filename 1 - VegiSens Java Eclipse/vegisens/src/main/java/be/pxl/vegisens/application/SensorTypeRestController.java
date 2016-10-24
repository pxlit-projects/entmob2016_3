package be.pxl.vegisens.application;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

@RestController
public class SensorTypeRestController 
{    
    
	    @Autowired
	    private ISensorTypeService sensorTypeRepository;
	    	    
	    @GetMapping("/sensortypes")	    
	    public List<SensorType> getSensorTypes() 
	    {	    		       
	        return sensorTypeRepository.getAllSensorTypes();
	    }
}
