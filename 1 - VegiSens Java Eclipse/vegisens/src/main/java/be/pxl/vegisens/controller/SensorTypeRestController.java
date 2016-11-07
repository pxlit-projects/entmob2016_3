package be.pxl.vegisens.controller;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

import be.pxl.vegisens.domain.SensorType;
import be.pxl.vegisens.logging.JMSSender;
import be.pxl.vegisens.service.interfaces.ISensorTypeService;

@RestController
public class SensorTypeRestController 
{    
    
	    @Autowired
	    private ISensorTypeService sensorTypeRepository;
	    	    
	    @Autowired
	    private JMSSender jmsSender;
	    
	    private final String GET_PREFIX = "[GET] ";
	    
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
	    
		@GetMapping("/sensortypes/{sensorTypeId}")
		public SensorType getSensorTypeById(@PathVariable String sensorTypeId)
		{
			int id = Integer.parseInt(sensorTypeId);

			jmsSender.sendInformation(GET_PREFIX + "Request to get sensorType with ID: " + id);

			SensorType sensorType = sensorTypeRepository.getSensorTypeById(id);

			jmsSender.sendInformation(GET_PREFIX + "[SENSORTYPE]: " + sensorType.toString());

			return sensorType;
		}
}
