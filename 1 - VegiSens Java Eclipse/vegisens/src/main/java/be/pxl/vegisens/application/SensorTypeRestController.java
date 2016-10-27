package be.pxl.vegisens.application;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

@RestController
public class SensorTypeRestController 
{    
    
	    @Autowired
	    private ISensorTypeService sensorTypeRepository;
	    	    
	    @Autowired
	    private JMSSender jmsSender;
	    
	    private final String GET_PREFIX = "[GET] ";
	    private final String POST_PREFIX = "[POST] ";
	    private final String PUT_PREFIX = "[PUT] ";
	    
	    @GetMapping("/sensortypes")	    
	    public List<SensorType> getSensorTypes() 
	    {	    
	    	List<SensorType> listOfAllSensorTypes = sensorTypeRepository.getAllSensorTypes();
	    	
	    	jmsSender.sendInformation(GET_PREFIX + "Request to get all sensortypes.");
	    	
	    	for (SensorType sensorType : listOfAllSensorTypes) 
	    	{
	    		jmsSender.sendInformation(GET_PREFIX + sensorType.toString());
			}
	    	
	    	if(listOfAllSensorTypes != null)
	    	{	    	
	    		jmsSender.sendInformation(GET_PREFIX  + "Sensortypes received.");
	    	}
	    	
	        return listOfAllSensorTypes;
	    }
}
