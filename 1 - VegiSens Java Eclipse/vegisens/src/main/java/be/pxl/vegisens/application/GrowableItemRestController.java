package be.pxl.vegisens.application;


import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;



@RestController
public class GrowableItemRestController 
{    
	    @Autowired
	    private IGrowableItemService growableItemRepository;
	    
	    
	    @GetMapping("/growableItems")	    
	    public List<GrowableItem> getGrowableItems() 
	    {	    		       
	        return growableItemRepository.getAllGrowableItems();
	    }
	    
	    @PostMapping("/add")	    
	    public void addGrowableItems(@RequestBody GrowableItem  growableItem) 
	    {	    	
	    	System.out.println("test");
	        //growableItemRepository.addGrowableITem(growableItem);	        
	    }
}
