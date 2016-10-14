package be.pxl.controllers;

import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

/**
 * Created by aless on 30/09/2016.
 */

@RestController
//@RequestMapping(value = "api/growable-item")
public class ApiController {

    //@RequestMapping(value = "all", method = RequestMethod.GET)
    @RequestMapping("/")
    public String getGrowableItems() {
        return "ApiController says hello!";
    }

}