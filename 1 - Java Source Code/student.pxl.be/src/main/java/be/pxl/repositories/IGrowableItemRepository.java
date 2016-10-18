package be.pxl.repositories;

import be.pxl.models.GrowableItem;

/**
 * Created by aless on 14/10/2016.
 */
public interface IGrowableItemRepository 
{
    GrowableItem getGrowableItemById(int id);
}