package be.pxl.vegisens.application;


import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;



@RestController
public class GrowableItemRestController 
{    
	    @Autowired
	    private IGrowableItemService growableItemRepository;
	    
	    @Autowired
	    private ITemperatureService temperatureRepository;
	    
	    @Autowired
	    private IHumidityService humidityRepository;
	    
	    @GetMapping("/growableItems")	    
	    public List<GrowableItem> getGrowableItems() 
	    {	    		       
	        return growableItemRepository.getAllGrowableItems();
	    }
	    
	    @PostMapping("/growableItems/add")	    
	    public void addGrowableItems(@RequestBody GrowableItem  growableItem) 
	    {	    	
	    	//Add temp and hum, get the keys and put them as FK for the new vegetable
	    	int humidity_FK = humidityRepository.addHumidity(growableItem.getHumidity()).getHumidityId();
	    	int temperature_FK = temperatureRepository.addTemperature(growableItem.getTemperature()).getTemperatureId();
	    	
	    	//Create entity item
	    	GrowableItemEntity growableItemEntity = new GrowableItemEntity();
	    	growableItemEntity.setDescription(growableItem.getDescription());
	    	growableItemEntity.setImage(growableItem.getImage());
	    	growableItemEntity.setName(growableItem.getName());
	    	growableItemEntity.setHumidity_fk(humidity_FK);
	    	growableItemEntity.setTemperature_fk(temperature_FK);
	    	
	    	//Save entity Item
	        growableItemRepository.addGrowableItem(growableItemEntity);    
	    }
}
