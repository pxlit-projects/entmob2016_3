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
	    
	    private int humidity_FK;
	    private int temperature_FK;
	    
	    @GetMapping("/growableItems")	    
	    public List<GrowableItem> getGrowableItems() 
	    {	    		       
	        return growableItemRepository.getAllGrowableItems();
	    }
	    
	    @PostMapping("/growableItems/add")	    
	    public void addGrowableItem(@RequestBody GrowableItem  growableItem) 
	    {	    	
	    	//Add temp and hum, get the keys and put them as FK for the new vegetable
	    	humidity_FK = humidityRepository.addHumidity(growableItem.getHumidity()).getHumidityId();
	    	temperature_FK = temperatureRepository.addTemperature(growableItem.getTemperature()).getTemperatureId();
	    	
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
	    
	    @PutMapping("/growableItems/update")	    
	    public void updateGrowableItem(@RequestBody GrowableItem  growableItem) 
	    {	    	
	    	//Add temp and hum, get the keys and put them as FK for the new vegetable
	    	humidity_FK = humidityRepository.updateHumidity(growableItem.getHumidity()).getHumidityId();
	    	temperature_FK = temperatureRepository.updateTemperature(growableItem.getTemperature()).getTemperatureId();
	    	
	    	//Create entity item
	    	GrowableItemEntity growableItemEntity = new GrowableItemEntity();
	    	
	    	growableItemEntity.setGrowableItemId(growableItem.getGrowableItemId());
	    	growableItemEntity.setDescription(growableItem.getDescription());
	    	growableItemEntity.setImage(growableItem.getImage());
	    	growableItemEntity.setName(growableItem.getName());
	    	growableItemEntity.setHumidity_fk(humidity_FK);
	    	growableItemEntity.setTemperature_fk(temperature_FK);
	    	
	    	//Save entity Item
	        growableItemRepository.addGrowableItem(growableItemEntity);    
	    }
}
