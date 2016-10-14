package be.pxl.repositories;

import be.pxl.models.GrowableItem;
import org.springframework.data.repository.CrudRepository;

/**
 * Created by aless on 14/10/2016.
 */


public interface IGrowableItemRepositoryCrud extends CrudRepository<GrowableItem, Integer> {



}