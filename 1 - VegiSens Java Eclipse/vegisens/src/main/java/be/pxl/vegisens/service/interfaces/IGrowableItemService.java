package be.pxl.vegisens.service.interfaces;

import java.util.List;

import be.pxl.vegisens.controller.entity.GrowableItemEntity;
import be.pxl.vegisens.domain.GrowableItem;

public interface IGrowableItemService {

	List<GrowableItem> getAllGrowableItems();
	void addGrowableItem(GrowableItemEntity growableItemToAdd);
	GrowableItem getGrowableItemById(int id);
}
