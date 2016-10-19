package be.pxl.vegisens.application;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.context.annotation.ComponentScan;
import org.springframework.web.bind.annotation.*;


@RestController
public class ApiRestController 
{
	    @Autowired
	    private IGrowableItemService repository;

	    @GetMapping("/api")
	    public String getGrowableItems() 
	    {
	    	List<GrowableItem> growableItemList = repository.getAllGrowableItems();
	    	
	         return (growableItemList.get(0)).getDescription();
	    }
	    
	    @GetMapping("/api2")
	    public List<GrowableItem> getGrowableItems2() 
	    {	    	
	         return repository.getAllGrowableItems();
	    }
	    	    
	    //@GetMapping("/text")
	    @RequestMapping(value="/text", method= RequestMethod.GET)
	    public String getString()
	    {
	    	return "It Works";
	    }
}
