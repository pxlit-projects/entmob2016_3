package controllers;

import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RestController;

import java.util.List;

/**
 * Created by aless on 30/09/2016.
 */

@RestController
@RequestMapping(value = "ws/api/growable-item")
public class ApiController {

    @RequestMapping(value = "all", method = RequestMethod.GET)
    public String getGrowableItems() {
        return "ApiController says hello!";
    }

}