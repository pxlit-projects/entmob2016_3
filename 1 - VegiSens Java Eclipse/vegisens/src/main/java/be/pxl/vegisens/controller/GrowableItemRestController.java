package be.pxl.vegisens.controller;


import static be.pxl.vegisens.logging.LogColor.GET_PREFIX;
import static be.pxl.vegisens.logging.LogColor.POST_PREFIX;
import static be.pxl.vegisens.logging.LogColor.PUT_PREFIX;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

import be.pxl.vegisens.controller.entity.GrowableItemEntity;
import be.pxl.vegisens.domain.GrowableItem;
import be.pxl.vegisens.logging.JMSSender;
import be.pxl.vegisens.service.interfaces.IGrowableItemService;
import be.pxl.vegisens.service.interfaces.IHumidityService;
import be.pxl.vegisens.service.interfaces.ITemperatureService;


@RestController
public class GrowableItemRestController 
{    
	    @Autowired
	    private IGrowableItemService growableItemRepository;
	    
	    @Autowired
	    private ITemperatureService temperatureRepository;
	    
	    @Autowired
	    private IHumidityService humidityRepository;
	    
	    @Autowired
	    private JMSSender jmsSender;
	    		    
	    private int humidity_FK;
	    private int temperature_FK;
	    
	    
	    @GetMapping("/growableItems")	    
	    public List<GrowableItem> getGrowableItems() 
	    {	    
	    	jmsSender.sendInformation(GET_PREFIX + "Request to get all growbaleitems.");
	    	
	    	List<GrowableItem> allGrowableItems = growableItemRepository.getAllGrowableItems();
	    	
	    	for (GrowableItem growableItem : allGrowableItems)
	    	{
	    		jmsSender.sendInformation(GET_PREFIX + "[GROWABLEITEM]: " + growableItem.toString());
			}
	    	
	    	if(allGrowableItems != null)
	    	{	    	
	    		jmsSender.sendInformation(GET_PREFIX + "Growbaleitems received.");
	    	}
	    	      
	        return allGrowableItems;
	    }

		@GetMapping("/growableItems/{growableItemId}")
		public GrowableItem getGrowableItemById(@PathVariable String growableItemId)
		{
			int id = Integer.parseInt(growableItemId);

			jmsSender.sendInformation(GET_PREFIX + "Request to get growable item with ID: " + id);

			GrowableItem growableItem = growableItemRepository.getGrowableItemById(id);

			jmsSender.sendInformation(GET_PREFIX + "[GROWABLEITEM]: " + growableItem.toString());
					
			return growableItem;
		}
	    
	    @PostMapping("/growableItems/add")	    
	    public void addGrowableItem(@RequestBody GrowableItem  growableItem) 
	    {	    	
	    	jmsSender.sendInformation(POST_PREFIX + "Request to add a growbaleitem");
	    		    	
	    	//Create entity item
	    	GrowableItemEntity growableItemEntity = new GrowableItemEntity();
	    	jmsSender.sendInformation(POST_PREFIX + "Created new GrowableItemEntity.");
	    	
	    	//Add temp and hum, get the keys and put them as FK for the new vegetable
	    	humidity_FK = humidityRepository.addHumidity(growableItem.getHumidity()).getHumidityId();   	
	    	temperature_FK = temperatureRepository.addTemperature(growableItem.getTemperature()).getTemperatureId();
    	
	    	growableItemEntity.setDescription(growableItem.getDescription());   	    	
	    	growableItemEntity.setImage(growableItem.getImage());  	    	
	    	growableItemEntity.setName(growableItem.getName());
    	
	    	growableItemEntity.setHumidity_fk(humidity_FK);
	    	growableItemEntity.setTemperature_fk(temperature_FK);
	    	
    		jmsSender.sendInformation(POST_PREFIX + "[GROWABLEITEM_ENTITY]: " + growableItemEntity.toString());
	    	
	    	//Save entity Item
	        growableItemRepository.addGrowableItem(growableItemEntity);    
	        
	        jmsSender.sendInformation(POST_PREFIX + "GrowableItemEntity inserted.");
	    }
	    
	    @PutMapping("/growableItems/update")	    
	    public void updateGrowableItem(@RequestBody GrowableItem  growableItem) 
	    {	    
	    	jmsSender.sendInformation(PUT_PREFIX + "Request to update a growbaleitem");
	    	    	
	    	//Create entity item
	    	GrowableItemEntity growableItemEntity = new GrowableItemEntity();
	    	jmsSender.sendInformation(PUT_PREFIX + "Created new GrowableItemEntity.");
	    	
	    	//Add temp and hum, get the keys and put them as FK for the new vegetable
	    	humidity_FK = humidityRepository.updateHumidity(growableItem.getHumidity()).getHumidityId();
	    	temperature_FK = temperatureRepository.updateTemperature(growableItem.getTemperature()).getTemperatureId();
   	    	
	    	growableItemEntity.setGrowableItemId(growableItem.getGrowableItemId());   	    	
	    	growableItemEntity.setDescription(growableItem.getDescription());   	    	
	    	growableItemEntity.setImage(growableItem.getImage());  	    	
	    	growableItemEntity.setName(growableItem.getName());
   	    	
	    	growableItemEntity.setHumidity_fk(humidity_FK);
	    	growableItemEntity.setTemperature_fk(temperature_FK);
	    	
	    	jmsSender.sendInformation( PUT_PREFIX+ "[GROWABLEITEM_ENTITY]: " + growableItemEntity.toString());
	    	
	    	//Save entity Item
	        growableItemRepository.addGrowableItem(growableItemEntity);   
	        
	        jmsSender.sendInformation(PUT_PREFIX + "Growbaleitem updated");
	    }
}
