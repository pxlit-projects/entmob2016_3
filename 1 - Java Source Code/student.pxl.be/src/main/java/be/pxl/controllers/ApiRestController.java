package be.pxl.controllers;

import be.pxl.models.GrowableItem;
import be.pxl.repositories.GrowableItemRepository;
import be.pxl.repositories.IGrowableItemRepositoryCrud;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RestController;

import java.util.List;

/**
 * Created by aless on 30/09/2016.
 */

@RestController
@RequestMapping(value = "api/growable-item")
public class ApiRestController {

    @Autowired
    private IGrowableItemRepositoryCrud repo;

    @RequestMapping(value = "all", method = RequestMethod.GET)
    public List<GrowableItem> getGrowableItems() 
    {
        return (List<GrowableItem>)repo.findAll();
        // return "ApiRestController works";
    }
}