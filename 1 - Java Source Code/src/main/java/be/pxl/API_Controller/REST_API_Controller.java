package be.pxl.API_Controller;

import org.springframework.web.bind.annotation.*;


public class REST_API_Controller {
	
	@RestController
	@RequestMapping(value = "/hello", method = RequestMethod.GET)
	public class RESTApiController 
	{
	    @RequestMapping(method = RequestMethod.GET)
	    public String getGrowableItems() 
	    {
	    	System.out.println("Hello!");
	        return "ApiController says hello!";
	    }
	}
}