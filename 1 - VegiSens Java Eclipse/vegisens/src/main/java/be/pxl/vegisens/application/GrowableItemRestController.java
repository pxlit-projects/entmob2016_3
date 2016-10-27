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
	    
	    @Autowired
	    private JMSSender jmsSender;
	    	    
	    private int humidity_FK;
	    private int temperature_FK;
	    
	    private final String GET_PREFIX = "[GET] ";
	    private final String POST_PREFIX = "[POST] ";
	    private final String PUT_PREFIX = "[PUT] ";
	    
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
